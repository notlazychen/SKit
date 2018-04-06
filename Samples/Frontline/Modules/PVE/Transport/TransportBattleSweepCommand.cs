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
    public class TransportBattleSweepCommand : GameCommand<SweepTransportRequest>
    {
        PlayerModule _playerModule;
        DungeonController _dungeonModule;
        TransportModule _tansportModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _dungeonModule = Server.GetModule<DungeonController>();
            _tansportModule = Server.GetModule<TransportModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            var player = _playerModule.QueryPlayer(pid);
            Transport transport = _tansportModule.QueryTransport(pid);
            SweepTransportResponse response = new SweepTransportResponse();
            if (transport.LastTodayDiff == 0)
            {
                return (int)GameErrorCode.今天至少护送一次运输车;
            }
            response.difficultDegree = transport.LastTodayDiff;
            //todo: vip
            //if (vip.getTransport_sweep() == 1) {
            int remain = GameConfig.TransportMaxTimes - transport.UseNumb;
            if (remain <= 0)
            {
                return -2;
            }
            string reason = "扫荡运输护送";
            DTransport fb = _tansportModule.DTransports[transport.LastTodayDiff];
            int gold = (int)(fb.gold * 2d / 3d);
            response.rewardInfo = new RewardInfo() { res = new List<ResInfo>() { new ResInfo() { type = CurrencyType.GOLD, count = gold } } };
            _playerModule.AddCurrency(player, CurrencyType.GOLD, gold, reason);
            transport.UseNumb += 1;
            _db.SaveChanges();
            //做任务
            //记录日志
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
