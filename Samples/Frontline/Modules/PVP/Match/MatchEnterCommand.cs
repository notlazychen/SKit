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
    public class MatchEnterCommand : GameCommand<MatchRequest>
    {
        PlayerModule _playerModule;
        MatchBattleModule _matchModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _matchModule = Server.GetModule<MatchBattleModule>();
        }
        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            _matchModule.Enter(player, Request.type, Request.difficult);
            return 0;
        }
    }
}
