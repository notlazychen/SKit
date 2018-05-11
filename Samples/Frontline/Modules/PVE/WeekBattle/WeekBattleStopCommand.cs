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
    public class WeekBattleStopCommand : GameCommand<WeekBattleEndRequest>
    {
        PlayerModule _playerModule;
        WeekBattleModule _weekModule;
        CampModule _campModule;
        PkgModule _pkgModule;
        DataContext _db;

        protected override void OnInit()
        {
            _campModule = Server.GetModule<CampModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _weekModule = Server.GetModule<WeekBattleModule>();
            _pkgModule = Server.GetModule<PkgModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            WeekBattleEndResponse response = new WeekBattleEndResponse();
            var ww = _weekModule.QueryWeekData(player.Id);
            TimeSpan useTime = DateTime.Now - ww.BattleBeginTime;
            if (ww.BattleToken == null || ww.BattleToken != Request.token)
            {
                return (int)GameErrorCode.战斗令牌错误或战斗已经失效;
            }
            response.success = true;
            response.win = Request.win;
            String pid = Session.PlayerId;
            if (Request.win)
            {
                ww.Score += GameConfig.week_challenge_number;
                ww.DaysInWeek += 1;
                ww.UseNumb++;
                ww.BattleToken = null;
                response.reward = new RewardInfo() { res = new List<ResInfo>(), items = new List<RewardItem>() };
                String reason = "挑战周常关卡";
                int day = ww.BattleDay;
                int diff = ww.BattleDiff;
                DWeekBattle dww = _weekModule.DWeekBattles[diff][day];
                //检查阵容
                int addition = 0;
                Team team = player.Teams.First(t => t.IsSelected);
                if (!(dww.unit_type.Object.Length == 1 && dww.unit_type.Object[0] == 0))
                {
                    foreach (String uid in team.Units.Object)
                    {
                        if (!string.IsNullOrEmpty(uid))
                        {
                            Unit u = player.Units.First(x => x.Id == uid);
                            DUnit du = _campModule.DUnits[u.Tid];
                            bool inSet = dww.unit_type.Object.Contains(du.ww_type);
                            if (inSet)
                            {
                                addition += dww.unity_addition;
                            }
                        }
                    }
                }
                if (dww.item_id.Object.Length != 0)
                {
                    for (int i = 0; i < dww.item_id.Object.Length; i++)
                    {
                        int itemid = dww.item_id.Object[i];
                        int itemcnt = (int)(dww.item_cnt.Object[i] * (1+ addition / 10000d));
                        response.reward.items.Add(new RewardItem { id = itemid, count = itemcnt });
                        _pkgModule.AddItem(player, itemid, itemcnt, reason);
                    }
                }
                if (dww.res_type.Object.Length != 0)
                {
                    for (int i = 0; i < dww.res_type.Object.Length; i++)
                    {
                        int rescount = (int)(dww.res_cnt.Object[i] * (1 + addition / 10000d));
                        _playerModule.AddCurrency(player, dww.res_type.Object[i], rescount, reason);
                        response.reward.res.Add(new ResInfo { type = dww.res_type.Object[i], count = rescount });
                    }
                }
                _db.SaveChanges();
            }
            response.score = ww.Score;
            Session.SendAsync(response);
            return 0;
        }
    }
}
