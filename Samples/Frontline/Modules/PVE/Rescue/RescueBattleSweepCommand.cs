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
    public class RescueBattleSweepCommand : GameCommand<SweepRescueRequest>
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
            
            SweepRescueResponse response = new SweepRescueResponse();

            //todo: 判断vip是否可以扫荡

            var pattern = _rescueModule.QueryRescue(pid);

            if (pattern.LastTodayDiff == 0)
            {
                return (int)GameErrorCode.今天至少通关一次雪地营救;
            }
            //if (pattern.LastTodayDiff != Request.difficulty)
            //{
            //    return -2;
            //}
            int remain = GameConfig.RescueMaxTimes - pattern.UseNumb;
            if (remain <= 0) {
                return -2;
            }
            //rescueService.sweep(pattern, rojo, pattern.getLastTodayDiff(), response);

            pattern.UseNumb++;

            string reason = "雪地营救扫荡";
            DRescue dres = _rescueModule.DRescues[pattern.LastTodayDiff];
            RewardInfo rewardInfo = new RewardInfo() { res = new List<ResInfo>() };
            _playerModule.AddCurrencies(player,
                          new int[] { CurrencyType.SUPPLY, CurrencyType.IRON },
                          new int[] { dres.supply, dres.iron },
                          reason);
            rewardInfo.res.Add(new ResInfo() { type = CurrencyType.SUPPLY, count = dres.supply });
            rewardInfo.res.Add(new ResInfo() { type = CurrencyType.IRON, count = dres.iron });
            _db.SaveChanges();
            //做任务
            //记录日志
            response.success = true;
            response.reward = rewardInfo;
            response.difficulty = pattern.LastTodayDiff;
            Session.SendAsync(response);
            return 0;
        }
    }
}
