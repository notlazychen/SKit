using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKit.Common.Utils;
using Frontline.Services;
using Frontline.MQ;
using Frontline.Common;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using SKit.Common;

namespace Frontline.Modules
{
    public class MatchBattleModule : GameModule
    {
        private DataContext _db;
        private PlayerModule _playerModule;
        private CampModule _campModule;
        private MessageBus _bus;
        private GameServerSettings _settings;
        private ILogger _logger;
        private ServerSession _matchServerSession;

        public MatchBattleModule(DataContext db, MessageBus bus,
            ILogger<MatchBattleModule> logger,
            IOptions<GameServerSettings> config)
        {
            _logger = logger;
            _db = db;
            _bus = bus;
            _settings = config.Value;
        }

        protected override void OnConfiguringModules()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _campModule = Server.GetModule<CampModule>();
            _bus.Start(new PullAdapter(_settings.MyBusAddress));
            _matchServerSession = _bus.Connect(_settings.MatchServerAddress);
            _bus.ServerMessageReceived += _bus_ServerMessageReceived;
            _bus.RelayMessageReceived += _bus_RelayMessageReceived;
        }

        private void _bus_RelayMessageReceived(object sender, RelayMessageReceivedEventArgs e)
        {
            Server.MultiSendByUserName(e.Data, e.Receivers);
        }

        private void _bus_ServerMessageReceived(object sender, ServerMessageReceivedEventArgs e)
        {
            _logger.LogWarning(JsonConvert.SerializeObject(e));
        }

        #region API
        public MatchBattlePlayerInfo ToBattlePlayerInfo(Player p, int matchType)
        {
            MatchBattlePlayerInfo info = new MatchBattlePlayerInfo();
            info.pid = p.Id;
            info.name = p.NickName;
            info.icon = p.Icon;
            info.units = new List<UnitInfo>();
            info.position = 0;
            info.group = 0;
            info.level = p.Level;
            info.vip = p.VIP;
            info.serName = this.Server.Name;

            //    MultiPattern mpInfo = rojo.get(MultiPattern.class, pid);
            //    if (mpInfo == null) {
            //        mpInfo = new MultiPattern();
            //    mpInfo.setPid(pid);
            //        mpInfo.setComboWin(new ArrayList<>());
            //        for (int i = 0; i< 3; i++) {
            //            mpInfo.getComboWin().add(0);
            //}
            //rojo.saveAndFlush(mpInfo);
            //    } else {
            //        if (mpInfo.getComboWin() == null) {
            //            mpInfo.setComboWin(new ArrayList<>());
            //        }
            //        if (mpInfo.getComboWin().size() < 3) {

            //            for (int i = 0; i< 3; i++) {
            //                mpInfo.getComboWin().add(0);
            //            }
            //            rojo.updateAndFlush(mpInfo);
            //        }
            //    }
            //设置连胜信息
            //info.setComboWin(mpInfo.getComboWin().get(matchType));
            //Support su = Spring.bean(PlayerService.class).getSupport(pid);
            info.diamond = p.Wallet.DIAMOND;

            if (matchType == 1)
            {
                //天梯
                //Ladder linfo = this.ladderService.getLadderInfo(pid);
                S2SLadderInfo ladderInfo = new S2SLadderInfo();
                ladderInfo.ladderMrk = 1;// linfo.getMilitaryRank());
                ladderInfo.ladderScore = 1;// (linfo.getLadderScore());
                info.ladderInfo = ladderInfo;
            }
            var team = p.Formations.FirstOrDefault(t => t.IsSelected);

            foreach (String bp in team.Units.Object)
            {
                if (!string.IsNullOrEmpty(bp))
                {
                    Unit u = p.Units.FirstOrDefault(x => x.Id == bp);

                    UnitInfo ui = _campModule.ToUnitInfo(u);
                    info.units.Add(ui);
                }
            }

            if (info.units.Count == 0)
            {
                return null;
            }

            return info;
        }

        public bool Enter(Player p, int type, int diff)
        {
            S2SMatchRequest request = new S2SMatchRequest();
            MatchBattlePlayerInfo info = this.ToBattlePlayerInfo(p, type);
            if (info == null)
            {
                return false;
            }
            request.info = info;
            request.type = type;
            request.diff = diff;

            if (_matchServerSession.SendToServer(request))
            {
                Session.PlayerLeave -= Session_PlayerLeave;
                Session.PlayerLeave += Session_PlayerLeave;
            }
            return true;
        }

        private void Session_PlayerLeave(object sender, ClientCloseReason e)
        {
            var session = sender as GameSession;
            if (session != null)
            {
                session.PlayerLeave -= Session_PlayerLeave;
                MatchCancelRequest request = new MatchCancelRequest();
                request.pid = session.PlayerId;
                _matchServerSession.SendToServer(request);
            }
        }

        public void Exit(MatchCancelRequest request)
        {
            _matchServerSession.SendToServer(request);
        }
        #endregion
    }
}
