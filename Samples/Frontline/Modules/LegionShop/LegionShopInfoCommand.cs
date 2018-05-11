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
    public class LegionShopInfoCommand : GameCommand<LegionShopInfoRequest>
    {
        LegionShopModule _mallModule;
        PlayerModule _playerModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _mallModule = Server.GetModule<LegionShopModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            var response = new LegionShopInfoResponse();
            response.commodities = new List<LegionShopCommodityInfo>();

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var mall = _mallModule.QueryLegionShop(player);
            foreach(var shopitem in _mallModule.DLegionShopItems.Values)
            {
                mall.SoldItemsDict.TryGetValue(shopitem.id, out var sold);                
                response.commodities.Add(_mallModule.ToInfo(shopitem, sold));
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
