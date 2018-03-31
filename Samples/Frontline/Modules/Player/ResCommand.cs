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
    public class ResCommand : GameCommand<ResRequest>
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
            ResResponse response = new ResResponse();
            response.success = true;
            response.pid = player.Id;
            response.level = player.Level;
            response.nickyName = player.NickName;
            response.icon = player.Icon;
            response.exp = player.Exp;
            response.renameCnt = player.RenameNumb;
            response.vip = player.VIP;

            response.resInfos = new List<ResInfo>();
            for (int ct = 1; ct <= CurrencyType.MAX_TYPE; ct++)
            {
                response.resInfos.Add(new ResInfo()
                {
                    type = ct,
                    count = player.Wallet.GetCurrency(ct)
                });
            }

            //一些配置表的内容
            response.nextExp = _playerModule.DLevels[player.Level].exp;
            response.resistMaxWave = 1;
            response.preExp = player.Level == 1 ? 0 : _playerModule.DLevels[player.Level - 1].exp;
            Session.SendAsync(response);
            return 0;
        }
    }
}
