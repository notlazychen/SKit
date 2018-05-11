using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
using Newtonsoft.Json.Linq;
using protocol;
using SKit;
using SKit.Common;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class DrawRaffleCommand : GameCommand<LotteryDrawRequest>
    {
        PlayerModule _playerModule;
        RaffleModule _lotteryModule;
        PkgModule _pkgModule;
        CampModule _campModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _lotteryModule = Server.GetModule<RaffleModule>();
            _pkgModule = Server.GetModule<PkgModule>();
            _campModule = Server.GetModule<CampModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        private DRaffle Rand(int lotteryId, int vip)
        {
            var group = _lotteryModule.DRaffles[lotteryId];

            switch (vip)
            {
                case 0:
                    return MathUtils.RandomElement(group, g=>g.w_0);
                case 1:
                    return MathUtils.RandomElement(group, g => g.w_1);
                case 2:
                    return MathUtils.RandomElement(group, g => g.w_2);
            }
            return null;
        }

        public override int ExecuteCommand()
        {
            var response = new LotteryDrawResponse();
            response.once = Request.once;
            response.type = Request.type;
            response.rewardInfo = new RewardInfo { res = new List<ResInfo>(), items = new List<RewardItem>(), units = new List<UnitInfo>() };

            var p = _playerModule.QueryPlayer(Session.PlayerId);
            var l = _lotteryModule.QueryRaffle(Session.PlayerId, Request.type);
            DateTime now = DateTime.Now;
            
            var dg = _lotteryModule.DRaffleGroups[l.Type];
            if (Request.once)
            {
                string reason = $"摇奖{Request.type}";
                //先判断是否免费
                if (l.FreeNextTime <= now)
                {
                    l.FreeNextTime = now.AddDays(1);
                }
                else
                {
                    //续付费
                    bool ok = _pkgModule.TrySubItem(p, dg.cost_item, 1, reason, out var item);
                    if (!ok)
                    {
                        return (int)GameErrorCode.道具不足;
                    }
                }

                l.BaseNumb--;
                DRaffle r = null;
                // 发奖励
                if(l.UsedNumb == 0 && dg.first_drop != 0)
                {
                    r = this.Rand(dg.first_drop, p.VIP);
                }
                else if (l.BaseNumb == 0)
                {
                    r = this.Rand(dg.base_drop, p.VIP);
                    l.BaseNumb = dg.base_numb;
                }
                else
                {
                    r = this.Rand(dg.normal_drop, p.VIP);
                }
                l.LastTime = now;
                l.UsedNumb++;
                //判断是否兵种
                DItem ditem = _pkgModule.DItems[r.item_id];
                if(ditem.breakUnitId != 0)// && (ditem.type == 11 || ditem.type == 17)
                {      
                    //判断兵种是否已有
                    var unit = p.Units.FirstOrDefault(u => u.Tid == ditem.breakUnitId);
                    UnitInfo uinfo = null;
                    if (unit == null)
                    {
                        uinfo = _campModule.UnlockUnit(p, ditem.breakUnitId);
                    }
                    else
                    {
                        uinfo = _campModule.ToUnitInfo(unit);
                        //转化碎片
                        if(_campModule.DUnitUnlock.TryGetValue(ditem.breakUnitId, out var duu))
                        {
                            int itemcnt = (int)(duu.item_cnt * GameConfig.unit_to_item_rate);
                            response.rewardInfo.items.Add(new RewardItem { id = duu.item_id, count = itemcnt });
                            _pkgModule.AddItem(p, duu.item_id, itemcnt, reason);
                        }
                    }
                    response.rewardInfo.units.Add(uinfo);
                }
                else
                {
                    int itemcnt = MathUtils.RandomNumber(r.item_cnt_min, r.item_cnt_max + 1);
                    response.rewardInfo.items.Add(new RewardItem { id = r.item_id, count = itemcnt });
                    _pkgModule.AddItem(p, r.item_id, itemcnt, reason);
                }
                _db.SaveChanges();
            }
            else
            {
                string reason = $"十连摇奖{Request.type}";
                //续付费
                bool ok = _pkgModule.TrySubItem(p, dg.cost_item, 10, reason, out var item);
                if (!ok)
                {
                    return (int)GameErrorCode.道具不足;
                }

                bool hadunit = false;
                bool hadnec = false;
                //发奖励
                int numb = 0;
                int numbTotal = 0;
                while (numb < 10 && numbTotal < 50)
                {
                    numbTotal++;
                    DRaffle r = null;
                    // 发奖励
                    if(l.UsedNumb == 0 && dg.first_drop != 0)
                    {
                        r = this.Rand(dg.first_drop, p.VIP);
                    }
                    else if (l.BaseNumb == 0)
                    {
                        r = this.Rand(dg.base_drop, p.VIP);
                        l.BaseNumb = dg.base_numb;
                        hadnec = true;
                    }
                    else
                    {
                        if (hadnec)
                        {
                            r = this.Rand(dg.normal_drop, p.VIP);
                        }
                        else
                        {
                            //10连必掉组
                            r = this.Rand(dg.nec_drop, p.VIP);
                            hadnec = true;
                        }
                    }
                    //判断是否兵种
                    DItem ditem = _pkgModule.DItems[r.item_id];
                    if(ditem.breakUnitId != 0 && hadunit)
                    {
                        continue;
                    }
                    numb++;
                    l.BaseNumb--;
                    l.UsedNumb++;
                    if (ditem.breakUnitId != 0)// && (ditem.type == 11 || ditem.type == 17)
                    {
                        //判断兵种是否已有
                        var unit = p.Units.FirstOrDefault(u => u.Tid == ditem.breakUnitId);
                        UnitInfo uinfo = null;
                        if(unit == null)
                        {
                            uinfo = _campModule.UnlockUnit(p, ditem.breakUnitId);
                        }
                        else
                        {
                            uinfo = _campModule.ToUnitInfo(unit);
                            if (_campModule.DUnitUnlock.TryGetValue(ditem.breakUnitId, out var duu))
                            {
                                int itemcnt = (int)(duu.item_cnt * GameConfig.unit_to_item_rate);
                                response.rewardInfo.items.Add(new RewardItem { id = duu.item_id, count = itemcnt });
                                _pkgModule.AddItem(p, duu.item_id, itemcnt, reason);
                            }
                        }
                        response.rewardInfo.units.Add(uinfo);
                        hadunit = true;
                    }
                    else
                    {
                        int itemcnt = MathUtils.RandomNumber(r.item_cnt_min, r.item_cnt_max + 1);
                        response.rewardInfo.items.Add(new RewardItem { id = r.item_id, count = itemcnt });
                        _pkgModule.AddItem(p, r.item_id, itemcnt, reason);
                    }
                }
                l.LastTime = now;
                _db.SaveChanges();
            }
            response.baseNumb = l.BaseNumb;
            response.nextFreeTime = l.FreeNextTime.ToUnixTime();

            Session.SendAsync(response);
            return 0;
        }
    }
}
