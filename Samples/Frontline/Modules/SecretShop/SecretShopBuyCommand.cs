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
    public class SecretShopBuyCommand : GameCommand<SecretShopBuyItemRequest>
    {
        SecretShopModule _shopModule;
        PlayerModule _playerModule;
        PkgModule _pkgModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _shopModule = Server.GetModule<SecretShopModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            var response = new SecretShopBuyItemResponse();
            var shop = _shopModule.QuerySecretShop(Session.PlayerId);

            var commodity = shop.SecretShopItems.First(c => c.Tid == Request.id);
            var player = _playerModule.QueryPlayer(shop.PlayerId);
            var dc = _shopModule.DSecretShopItems[commodity.Tid];
            if(!_playerModule.IsCurrencyEnough(player, dc.res_type, dc.cur_price))
            {
                return (int)GameErrorCode.资源不足;
            }
            if(commodity.SoldCount >= dc.limit_cnt)
            {
                return (int)GameErrorCode.已售罄;
            }
            string reason = $"神秘商店购买{dc.id}";
            _playerModule.AddCurrency(player, dc.res_type, -dc.cur_price, reason);
            _pkgModule.AddItem(player, dc.item_id, dc.item_cnt, reason);
            commodity.SoldCount++;
            _db.SaveChanges();
            response.id = Request.id;
            response.item_id = dc.item_id;
            response.item_cnt = dc.item_cnt;
            Session.SendAsync(response);
            return 0;
        }
    }
}
