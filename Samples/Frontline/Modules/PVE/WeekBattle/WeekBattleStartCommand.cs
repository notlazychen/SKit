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
    public class WeekBattleStartCommand : GameCommand<WeekBattleStartRequest>
    {
        PlayerModule _playerModule;
        WeekBattleModule _weekModule;
        CampModule _campModule;
        DungeonModule _dungeonModule;
        DataContext _db;

        protected override void OnInit()
        {
            _campModule = Server.GetModule<CampModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _weekModule = Server.GetModule<WeekBattleModule>();
            _dungeonModule = Server.GetModule<DungeonModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            WeekBattleStartResponse response = new WeekBattleStartResponse();
            int day = DateTime.Now.GetWeekDay();
            int diff = Request.diff;
            DWeekBattle dww = _weekModule.DWeekBattles[diff][day];
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            //检查阵容
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
                        if (!inSet)
                        {
                            return (int)GameErrorCode.阵容中包含今日周常挑战不能上阵的兵;
                        }
                    }
                }
            }

            var ww = _weekModule.QueryWeekData(player.Id);
            ww.BattleDay = day;
            ww.BattleDiff = diff;
            ww.BattleToken = Guid.NewGuid().ToString();
            ww.BattleBeginTime = DateTime.Now;

            response.success = true;
            response.diff = diff;
            response.day = day;
            response.startTime = ww.BattleBeginTime.ToUnixTime();
            response.token = ww.BattleToken;
            response.monsters = _dungeonModule.ToMonsterInfosByDungeonId(dww.mid);
            Session.SendAsync(response);
            return 0;
        }
    }
}
