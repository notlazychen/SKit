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
    public class PkgInfoCommand : GameCommand<PkgInfoRequest>
    {
        PkgModule _pkgModule;
        PlayerModule _playerModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            var items = _playerModule.QueryPlayer(Session.PlayerId).Items;
            PkgInfoResponse response = new PkgInfoResponse
            {
                success = true,
                pid = this.Session.PlayerId,
                items = new List<ItemInfo>()
            };
            foreach (var item in items)
            {
                var ii = _pkgModule.ToItemInfo(item);
                response.items.Add(ii);
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
