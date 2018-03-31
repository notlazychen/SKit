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
    public class DrawLotteryCommand : GameCommand<LotteryRequest>
    {
        PlayerModule _playerModule;
        LotteryModule _lotteryModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _lotteryModule = Server.GetModule<LotteryModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        private DLotteryRand Rand(int lotteryId, int lv)
        {
            DLotteryGroup group = _lotteryModule.DLotteryGroups[lotteryId];

            int index = MathUtils.RandomIndex(group.group_w.Object);
            int groupId = group.group.Object[index];
            var rands = _lotteryModule.DLotteryRands[groupId].Where(r => r.lv_min <= lv && r.lv_max >= lv).ToList();
            var rand = MathUtils.RandomElement(rands, e => e.w);
            return rand;
        }

        public override int ExecuteCommand()
        {
            LotteryResponse response = new LotteryResponse();
            var p = _playerModule.QueryPlayer(Session.PlayerId);
            Lottery l = _lotteryModule.QueryLottery(Session.PlayerId);
            DateTime now = DateTime.Now;

            int method = response.method = Request.method;
            int mode = response.mode = Request.mode;
            response.rewardInfo = new RewardInfo()
            {
                items = new List<RewardItem>(),
                units = new List<UnitInfo>(),
                res = new List<ResInfo>()
            };
            PlayerModule playerModule = Server.GetModule<PlayerModule>();
            PkgModule pkgController = Server.GetModule<PkgModule>();
            //先判断是否免费
            if (method == 1)
            {
                //单抽
                if (mode == 1)
                {
                    //金币单抽
                    DLottery dl = _lotteryModule.DLotteries[1];
                    if (now >= l.GoldFreeNextTime)
                    {
                        DLotteryRand rand = null;
                        if (l.GoldBaseNumb <= 1)
                        {
                            rand = this.Rand(dl.rand_sp, p.Level);
                            l.GoldBaseNumb = GameConfig.lottery_base_cnt;
                        }
                        else
                        {
                            rand = this.Rand(dl.rand, p.Level);
                            l.GoldBaseNumb -= 1;
                        }
                        response.success = true;
                        response.rewardInfo.items.Add(new RewardItem()
                        {
                            id = rand.item_id,
                            count = rand.item_cnt,
                        });
                        //todo: 滚屏广播

                        l.GoldUsedNumb += 1;
                        l.GoldFreeNumb -= 1;
                        if (l.GoldFreeNumb > 0)
                        {
                            l.GoldFreeNextTime = now.AddMinutes(dl.free_cd);//下次免费金币抽刷新时间
                        }
                        else
                        {
                            l.GoldFreeNextTime = DateTime.Today.AddDays(1);
                        }

                    }
                    else
                    {
                        bool canChou = false;
                        //扣道具
                        string reason = "金币单抽";
                        if (pkgController.TrySubItem(p, dl.cost_item, 1, reason, out var item))
                        {
                            canChou = true;
                        }
                        else
                        {
                            //扣钱
                            if (playerModule.IsCurrencyEnough(p, CurrencyType.GOLD, dl.cost_res_cnt))
                            {
                                canChou = true;
                                playerModule.AddCurrency(p, CurrencyType.GOLD, -dl.cost_res_cnt, reason);
                            }
                        }
                        if (canChou)
                        {
                            DLotteryRand rand = null;
                            if (l.GoldBaseNumb <= 1)
                            {
                                rand = this.Rand(dl.rand_sp, p.Level);
                                l.GoldBaseNumb = GameConfig.lottery_base_cnt;
                            }
                            else
                            {
                                rand = this.Rand(dl.rand, p.Level);
                                l.GoldBaseNumb -= 1;
                            }
                            response.success = true;
                            response.rewardInfo.items.Add(new RewardItem()
                            {
                                id = rand.item_id,
                                count = rand.item_cnt
                            });

                            l.GoldUsedNumb += 1;

                            //todo: 滚屏广播
                        }
                    }
                }
                else//钻石单抽奖
                {
                    DLottery dl = _lotteryModule.DLotteries[2];
                    if (now >= l.DmdFreeNextTime)
                    {
                        DLotteryRand rand = null;
                        if (l.DmdBaseNumb <= 1)
                        {
                            rand = this.Rand(dl.rand_sp, p.Level);
                            l.DmdBaseNumb = GameConfig.lottery_base_cnt;
                        }
                        else
                        {
                            rand = this.Rand(dl.rand, p.Level);
                            l.DmdBaseNumb -= 1;
                        }
                        if (l.DmdUsedNumb == 0)
                        {
                            rand = new DLotteryRand();
                            rand.item_id = GameConfig.lottery_first_item_id;
                            rand.item_cnt = GameConfig.lottery_first_item_cnt;
                        }
                        response.success = true;

                        response.rewardInfo.items.Add(new RewardItem()
                        {
                            id = rand.item_id,
                            count = rand.item_cnt
                        });

                        //todo: 滚屏广播
                        l.DmdUsedNumb += 1;
                        l.DmdFreeNumb -= 1;
                        l.DmdFreeNextTime = now.AddMinutes(dl.free_cd);//下次免费金币抽刷新时间

                    }
                    else
                    {
                        bool canChou = false;
                        //扣道具
                        string reason = "钻石单抽";
                        if (pkgController.TrySubItem(p, dl.cost_item, 1, reason, out var item))
                        {
                            canChou = true;
                        }
                        else
                        {
                            //扣钱
                            if (playerModule.IsCurrencyEnough(p, CurrencyType.DIAMOND, dl.cost_res_cnt))
                            {
                                canChou = true;
                                playerModule.AddCurrency(p, CurrencyType.DIAMOND, -dl.cost_res_cnt, reason);
                            }
                        }
                        if (canChou)
                        {

                            DLotteryRand rand = null;
                            if (l.DmdBaseNumb <= 1)
                            {
                                rand = this.Rand(dl.rand_sp, p.Level);
                                l.DmdBaseNumb = GameConfig.lottery_base_cnt;
                            }
                            else
                            {
                                rand = this.Rand(dl.rand, p.Level);
                                l.DmdBaseNumb -= 1;
                            }
                            response.success = true;
                            response.rewardInfo.items.Add(new RewardItem()
                            {
                                id = rand.item_id,
                                count = rand.item_cnt
                            });
                            //todo: 滚屏广播
                            l.DmdUsedNumb += 1;
                        }
                    }
                }
            }
            else
            {
                //十连抽
                if (mode == 1)
                {//金币抽
                    string reason = "金币十连抽";
                    DLottery dl = _lotteryModule.DLotteries[1];
                    int cost = (int)(dl.cost_res_cnt * 10d * dl.ten_discount / 100d);
                    if (playerModule.IsCurrencyEnough(p, CurrencyType.GOLD, cost))
                    {
                        playerModule.AddCurrency(p, CurrencyType.GOLD, -cost, reason);

                        for (int i = 0; i < 10; i++)
                        {
                            DLotteryRand rand = null;
                            if (l.GoldBaseNumb <= 1)
                            {
                                rand = this.Rand(dl.rand_sp, p.Level);
                                l.GoldBaseNumb = GameConfig.lottery_base_cnt;
                            }
                            else
                            {
                                rand = this.Rand(dl.rand, p.Level);
                                l.GoldBaseNumb -= 1;
                            }

                            response.rewardInfo.items.Add(new RewardItem()
                            {
                                id = rand.item_id,
                                count = rand.item_cnt
                            });
                        }
                        //todo: 滚屏广播


                        response.success = true;
                        l.Gold10UsedNumb += 1;
                    }
                }
                else
                {//钻石抽
                    string reason = "钻石十连抽";
                    DLottery dl = _lotteryModule.DLotteries[2];
                    int cost = (int)(dl.cost_res_cnt * 10d * dl.ten_discount / 100d);
                    if (playerModule.IsCurrencyEnough(p, CurrencyType.DIAMOND, cost))
                    {
                        playerModule.AddCurrency(p, CurrencyType.DIAMOND, -cost, reason);

                        for (int i = 0; i < 10; i++)
                        {
                            DLotteryRand rand = null;
                            if (l.DmdBaseNumb <= 1)
                            {
                                if (l.Dmd10UsedNumb == 0)
                                {
                                    rand = this.Rand(dl.rand_first10, p.Level);
                                }
                                else
                                {
                                    rand = this.Rand(dl.rand_sp, p.Level);
                                }
                                l.DmdBaseNumb = GameConfig.lottery_base_cnt;
                            }
                            else
                            {
                                rand = this.Rand(dl.rand, p.Level);
                                l.DmdBaseNumb -= 1;
                            }

                            response.rewardInfo.items.Add(new RewardItem()
                            {
                                id = rand.item_id,
                                count = rand.item_cnt
                            });
                        }
                        //todo: 滚屏广播

                        l.Dmd10UsedNumb += 1;
                        response.success = true;

                    }
                }
            }

            if (response.success)
            {

                String reason;
                if (mode == 1)
                {
                    reason = "金币";
                }
                else
                {
                    reason = "钻石";
                }
                if (method == 1)
                {
                    reason += "单抽";
                }
                else
                {
                    reason += "十连抽";
                }
                foreach (var kv in response.rewardInfo.items.GroupBy(x => x.id))
                {
                    int itemid = kv.Key;
                    int itemcnt = kv.Sum(m => m.count);
                    pkgController.AddItem(p, itemid, itemcnt, reason);
                }
            }

            _db.SaveChanges();

            response.diamond = p.Wallet.DIAMOND;
            response.diamondBaseNumb = l.DmdBaseNumb;
            response.diamondFreeNextTime = l.DmdFreeNextTime.ToUnixTime();
            response.diamondUsedNumb = l.DmdUsedNumb;
            response.gold = p.Wallet.GOLD;
            response.goldBaseNumb = l.GoldBaseNumb;
            response.goldFreeNextTime = l.GoldFreeNextTime.ToUnixTime();
            response.goldUsedNumb = l.GoldUsedNumb;
            response.goldFreeNumb = l.GoldFreeNumb;
            response.diamondFreeNumb = l.DmdFreeNumb;

            Session.SendAsync(response);
            return 0;
        }
    }
}
