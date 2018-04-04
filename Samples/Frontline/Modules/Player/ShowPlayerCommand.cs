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
    public class ShowPlayerCommand : GameCommand<ShowPlayerRequest>
    {
        PlayerModule _playerModule;
        FriendController _friendModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _friendModule = Server.GetModule<FriendController>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            string pid = Request.pid;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            Player other = _playerModule.QueryPlayer(pid);
            if (other == null)
            {
                return (int)GameErrorCode.查无此人;
            }
            var friendlist = _friendModule.QueryPlayerFriendList(player.Id);
            ShowPlayerResponse response = new ShowPlayerResponse();
            response.success = true;
            response.pid = pid;
            response.power = other.MaxPower;
            response.vip = other.VIP;
            response.isfriend = friendlist.Friends.Any(f => f.PlayerId == other.Id);
            response.icon = other.Icon;
            response.name = other.NickName;
            response.level = other.Level;

            Session.SendAsync(response);
            return 0;
        }
    }
}
