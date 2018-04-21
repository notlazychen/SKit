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
    public class MallBuyCommand : GameCommand<BuyItemRequest>
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
            BuyItemResponse response = new BuyItemResponse();
            response.success = true;
            var mall = _mallModule.QueryMall(Session.PlayerId);
            var shop = mall.Shops.First(s=>s.Type == Request.type);
            var commodity = shop.ShopCommodities.First(c => c.CommodityId == Request.id);
            var player = _playerModule.QueryPlayer(mall.PlayerId);
            var dc = _mallModule.DMallShopItems[commodity.Type][commodity.CommodityId];
            if(!_playerModule.IsCurrencyEnough(player, dc.res_type, dc.res_cnt))
            {
                return (int)GameErrorCode.资源不足;
            }
            if(commodity.SoldCount >= 1)
            {
                return (int)GameErrorCode.已售罄;
            }
            string reason = $"商城购买{dc.id}";
            response.remain = _playerModule.AddCurrency(player, dc.res_type, -dc.res_cnt, reason);
            _pkgModule.AddItem(player, dc.item_id, dc.count, reason);
            commodity.SoldCount++;
            _db.SaveChanges();
            response.id = Request.id;
            response.res_type = dc.res_type;
            response.type = dc.type;
            Session.SendAsync(response);
            return 0;
        }
    }
}
