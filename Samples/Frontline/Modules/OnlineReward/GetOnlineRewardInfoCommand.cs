using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
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
    public class GetOnlineRewardInfoCommand : GameCommand<GetOnlineRewardInfoRequest>
    {
        PlayerModule _playerModule;
        OnlineRewadModule _onlineModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _onlineModule = Server.GetModule<OnlineRewadModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            GetOnlineRewardInfoResponse response = new GetOnlineRewardInfoResponse();
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var ol = player.OlReward;
            response.recvTime = ol.NextTime.ToUnixTime();
            response.reward = _onlineModule.ToRewardInfo(ol);
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
