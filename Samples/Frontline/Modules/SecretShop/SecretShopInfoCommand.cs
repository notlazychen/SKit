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
    public class SecretShopInfoCommand : GameCommand<SecretShopInfoRequest>
    {
        SecretShopModule _shopModule;
        PlayerModule _playerModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _shopModule = Server.GetModule<SecretShopModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            SecretShopInfoResponse response = new SecretShopInfoResponse();
            var now = DateTime.Now;
            var shop = _shopModule.QuerySecretShop(Session.PlayerId);
            response.open = now >= shop.OpenTime && now <= shop.CloseTime;

            response.beginTime = shop.OpenTime.ToUnixTime();
            response.endTime = shop.CloseTime.ToUnixTime();
            response.commodities = new List<SecretShopCommodityInfo>();
            foreach(var item in shop.SecretShopItems)
            {
                var info = new SecretShopCommodityInfo();
                var ditem = _shopModule.DSecretShopItems[item.Tid];
                info.id = item.Tid;
                info.limit_cnt = ditem.limit_cnt - item.SoldCount;
                info.item_cnt = ditem.item_cnt;
                info.item_id = ditem.item_id;
                info.res_type = ditem.res_type;
                info.original_price = ditem.old_price;
                info.current_price = ditem.cur_price;
                info.vip = ditem.vip;
                response.commodities.Add(info);
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
