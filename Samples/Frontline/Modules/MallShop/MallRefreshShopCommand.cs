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
    public class MallRefreshShopCommand : GameCommand<MallShopRefreshRequest>
    {
        MallShopModule _mallModule;
        PlayerModule _playerModule;
        PkgModule _pkgModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _mallModule = Server.GetModule<MallShopModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            MallShopRefreshResponse response = new MallShopRefreshResponse();
            response.success = true;
            response.type = Request.type;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var mall = _mallModule.QueryMall(player);
            var shop = mall.Shops.First(s=>s.Type == Request.type);
            var dshop = _mallModule.DMallShops[shop.Type];
            if (!dshop.refresh)
            {
                return (int)GameErrorCode.此商店不可手动刷新;
            }
            if (!_playerModule.IsCurrencyEnough(player, CurrencyType.DIAMOND, dshop.diamond))
            {
                return (int)GameErrorCode.资源不足;
            }
            string reason = $"商城刷新";
            _playerModule.AddCurrency(player, CurrencyType.DIAMOND, -dshop.diamond, reason);
            _mallModule.RandomShopCommdities(player, shop, dshop);
            shop.LastRefreshTime = DateTime.Now;
            _db.SaveChanges();
            response.shops = new List<MallShopInfo>();
            foreach(var c in shop.ShopCommodities)
            {
                response.shops.Add(_mallModule.ToInfo(c));
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
