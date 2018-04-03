using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
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
    public class SellItemCommand : GameCommand<SellItemRequest>
    {
        PkgModule _pkgModule;
        PlayerModule _playerModule;
        CampModule _campModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _campModule = Server.GetModule<CampModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var item = player.Items.FirstOrDefault(x => x.Id == Request.id);

            String id = Request.id;
            int count = Request.count;

            int sum = 0;
            string reason = $"出售道具{item.Tid}";
            if (item == null || item.Count < count)
            {
                return 0;
            }
            DItem di = _pkgModule.DItems[item.Tid];

            int price = di.price;
            sum = price * count;

            _pkgModule.TrySubItem(player, di.tid, count, reason, out item);

            _playerModule.AddCurrency(player, CurrencyType.GOLD, sum, reason);

            _db.SaveChanges();

            SellItemResponse response = new SellItemResponse();
            response.id = id;
            response.success = true;

            response.remain = item.Count;
            response.gold = sum;
            Session.SendAsync(response);
            return 0;
        }
    }
}
