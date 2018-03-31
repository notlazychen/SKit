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
    [GameCommandOptions(allowAnonymous:true)]
    public class LoginCommand : GameCommand<AuthRequest>
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
            if (Session.IsAuthorized)
            {
                Session.SendAsync(new AuthResponse() { success = true, pid = Session.PlayerId });
                return 0;
                //return (int)GameErrorCode.重复登录;
            }
            var json = JObject.Parse(DES.DesDecrypt(Request.loginid, _config.DESKey));
            var ucenterId = json.Value<long>("id");
            var usercode = json.Value<String>("usercode");
            var bind = json.Value<bool>("bind");
            Player player = null;
            if (!_db.Players.Any(p => p.UserCenterId == ucenterId))
            {
                string ip = (Session.Socket.RemoteEndPoint as IPEndPoint)?.Address.ToString();
                player = _playerModule.CreatePlayer(ucenterId, usercode, Request.ver, ip);
            }
            else
            {
                player = _playerModule.QueryPlayer(_db.Players.Where(p => p.UserCode == usercode).Select(p => p.Id).First());
                player.LastLoginTime = DateTime.Now;
                _db.SaveChanges();
            }
            Session.Login(player.Id);

            _playerModule.OnPlayerEntered(player);
            AuthResponse response = new AuthResponse()
            {
                success = true,
                pid = player.Id
            };
            Session.SendAsync(response);

            //配置离开事件
            Session.PlayerLeave += Session_PlayerLeave;
            return 0;
        }

        private void Session_PlayerLeave(object sender, ClientCloseReason e)
        {
            Session.PlayerLeave -= Session_PlayerLeave;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            player.OnlineTime += (DateTime.Now - player.LastLoginTime);
            _db.SaveChanges();
        }
    }
}
