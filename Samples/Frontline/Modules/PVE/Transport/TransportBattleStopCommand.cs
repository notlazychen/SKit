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
    public class TransportBattleStopCommand : GameCommand<EndTransportRequest>
    {
        PlayerModule _playerModule;
        DungeonModule _dungeonModule;
        TransportModule _tansportModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _dungeonModule = Server.GetModule<DungeonModule>();
            _tansportModule = Server.GetModule<TransportModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            var player = _playerModule.QueryPlayer(pid);
            Transport transport = _tansportModule.QueryTransport(pid);
            DTransport fb = _tansportModule.DTransports[transport.MissionDiff];

            EndTransportResponse response = new EndTransportResponse();
            if (Request.remainTruckHP == null)
            {
                return -2;
            }

            if (Request.battleToken != transport.MissionToken)
            {
                return (int)GameErrorCode.战斗令牌错误或战斗已经失效;
            }

            if (Request.remainTruckHP.Count > 3)
            {
                return -2;
            }
            response.difficultDegree = transport.MissionDiff;
            response.success = true;
            response.win = Request.win;
            //给奖励
            RewardInfo rewardInfo = new RewardInfo() { res = new List<ResInfo>() };
            MonsterInfo mi = _dungeonModule.ToMonsterInfoByDungeonId(fb.truck_id, fb.tid);
            int maxHP = mi.hp;
            bool allLive = true;
            double totalHP = 0;
            double nowHP = 0;
            foreach (double hp in Request.remainTruckHP)
            {
                totalHP += maxHP;
                if (hp > 0)
                {
                    nowHP += hp;
                }
                else
                {
                    allLive = false;
                }
            }
            if (nowHP > totalHP)
            {
                nowHP = totalHP;
            }
            int gold = (int)(fb.gold * (nowHP / totalHP));
            string reason = "运输车护送成功";
            rewardInfo.res.Add(new ResInfo() { type = CurrencyType.GOLD, count = gold });
            _playerModule.AddCurrency(player, CurrencyType.GOLD, gold, reason);
            if (allLive)
            {
                //任务
            }            
            transport.MissionBeginTime = DateTime.MinValue;
            transport.UseNumb++;
            transport.LastTodayDiff = fb.diff;
            _db.SaveChanges();
            response.rewardInfo = rewardInfo;
            //做任务
            //todo: 记录日志
            Session.SendAsync(response);
            return 0;
        }
    }
}
