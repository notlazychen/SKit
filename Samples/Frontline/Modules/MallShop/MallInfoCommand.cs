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
            var mall = _mallModule.QueryMall(Session.PlayerId);
            foreach(var shop in mall.Shops)
            {
                foreach(var c in shop.ShopCommodities)
                {
                    MallShopInfo info = _mallModule.ToInfo(c);
                    response.items.Add(info);
                }
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
