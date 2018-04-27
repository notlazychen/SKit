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
    public class VIPInfoCommand : GameCommand<VIPInfoRequest>
    {
        PlayerModule _playerModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            VIPInfoResponse response = new VIPInfoResponse();
            //response.success = true;
            //response.vipExp = player.VIPExp;
            response.vip = player.VIP;
            response.endTime = player.VIPEndTime.ToUnixTime();
            response.recved = player.VIPGiftReceved != 0;
            Session.SendAsync(response);
            return 0;
        }
    }
}
