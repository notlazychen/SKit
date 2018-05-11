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
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var mall = _mallModule.QueryMall(player);
            var shop = mall.Shops.First(s=>s.Type == Request.type);
            var commodity = shop.ShopCommodities.First(c => c.CommodityId == Request.id);
            var dc = _mallModule.DMallShopItems[commodity.Type][commodity.CommodityId];
            int cost_res_cnt = dc.cost_res_cnt * Request.count;
            if(!_playerModule.IsCurrencyEnough(player, dc.cost_res_type, cost_res_cnt))
            {
                return (int)GameErrorCode.资源不足;
            }
            if((dc.commodity_stock - commodity.SoldCount) < Request.count)
            {
                return (int)GameErrorCode.已售罄;
            }
            string reason = $"商城购买{dc.id}";
            response.remain = _playerModule.AddCurrency(player, dc.cost_res_type, -cost_res_cnt, reason);
            _pkgModule.AddItem(player, dc.item_id, dc.item_cnt * Request.count, reason);
            commodity.SoldCount+=Request.count;
            _db.SaveChanges();
            response.id = Request.id;
            response.count = Request.count;
            response.res_type = dc.cost_res_type;
            response.type = dc.type;
            Session.SendAsync(response);
            return 0;
        }
    }
}
