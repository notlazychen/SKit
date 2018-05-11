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
    public class MallInfoCommand : GameCommand<MallInfoRequest>
    {
        MallShopModule _mallModule;
        PlayerModule _playerModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _mallModule = Server.GetModule<MallShopModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            MallInfoResponse response = new MallInfoResponse();
            response.success = true;
            response.items = new List<MallShopInfo>();

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var mall = _mallModule.QueryMall(player);
            foreach(var shop in mall.Shops)
            {
                response.items.AddRange(shop.ShopCommodities.Where(c=>!c.IsOut).Select(c=> _mallModule.ToInfo(c)).OrderBy(c=>c.order));
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
