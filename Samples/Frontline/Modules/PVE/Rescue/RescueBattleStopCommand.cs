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
    public class RescueBattleStopCommand : GameCommand<EndRescueRequest>
    {
        PlayerModule _playerModule;
        DungeonModule _dungeonModule;
        RescueModule _rescueModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _dungeonModule = Server.GetModule<DungeonModule>();
            _rescueModule = Server.GetModule<RescueModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            var player = _playerModule.QueryPlayer(pid);
            EndRescueResponse response = new EndRescueResponse();
            var pattern = _rescueModule.QueryRescue(pid);
            if (pattern.MissionToken != Request.battleId)
            {
                return (int)GameErrorCode.战斗令牌错误或战斗已经失效;
            }

            pattern.UseNumb++;
            pattern.LastTodayDiff = pattern.MissionDiff;
            
            DRescue dres = _rescueModule.DRescues[pattern.MissionDiff];
            RewardInfo rewardInfo = new RewardInfo() { res = new List<ResInfo>() };

            if (Request.win)
            {
                string reason = "雪地营救胜利";
                _playerModule.AddCurrencies(player,
                    new int[] { CurrencyType.SUPPLY, CurrencyType.IRON },
                    new int[] { dres.supply, dres.iron },
                    reason);
                rewardInfo.res.Add(new ResInfo() { type = CurrencyType.SUPPLY, count = dres.supply });
                rewardInfo.res.Add(new ResInfo() { type = CurrencyType.IRON, count = dres.iron });
            }
            _db.SaveChanges();

            //做任务
            response.success = true;
            response.win = Request.win;
            response.reward = rewardInfo;
            Session.SendAsync(response);
            return 0;
        }
    }
}
