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
    public class LegionShopBuyCommand : GameCommand<BuyLegionShopItemRequest>
    {
        LegionShopModule _mallModule;
        PlayerModule _playerModule;
        PkgModule _pkgModule;
        LegionModule _legionModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _mallModule = Server.GetModule<LegionShopModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _legionModule = Server.GetModule<LegionModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var mall = _mallModule.QueryLegionShop(player);
            var dc = _mallModule.DLegionShopItems[Request.id];
            int cost_res_cnt = dc.cost_res_cnt * Request.count;
            if(!_playerModule.IsCurrencyEnough(player, dc.cost_res_type, cost_res_cnt))
            {
                return (int)GameErrorCode.资源不足;
            }
            mall.SoldItemsDict.TryGetValue(dc.id, out var sold);
            if((dc.commodity_stock - sold) < Request.count)
            {
                return (int)GameErrorCode.已售罄;
            }
            var lm = _legionModule.QueryLegionMember(player.Id);
            var legion = _legionModule.QueryLegion(lm.LegionId);
            if(dc.level_min > legion.Level)
            {
                return (int)GameErrorCode.军团等级不足;
            }
            string reason = $"军团商城购买{dc.id}";

            var response = new BuyLegionShopItemResponse();
            response.legionCoin = _playerModule.AddCurrency(player, dc.cost_res_type, -cost_res_cnt, reason);
            _pkgModule.AddItem(player, dc.item_id, dc.item_cnt * Request.count, reason);
            sold+= Request.count;
            mall.SoldItemsDict[dc.id] = sold;
            mall.ToSave();
            _db.SaveChanges();
            response.id = Request.id;
            Session.SendAsync(response);
            return 0;
        }
    }
}
