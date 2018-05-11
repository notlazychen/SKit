using Frontline.Data;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using Frontline.GameDesign;
using System.Linq;
using SKit.Common.Utils;
using Frontline.Common;

namespace Frontline.Modules
{
    public class LegionShopModule : GameModule
    {

        private DataContext _db;

        public Dictionary<int, DLegionShopItem> DLegionShopItems { get; private set; }//id>x
        
        public LegionShopModule(DataContext db, GameDesignContext design)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            //事件注册
            var playerModule = this.Server.GetModule<PlayerModule>();            

            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DLegionShopItems = designDb.DLegionShopItem.AsNoTracking().ToDictionary(x => x.id, x => x);
            });
        }


        #region 事件

        #endregion

        #region 辅助方法
        private Dictionary<string, LegionShop> _instances = new Dictionary<string, LegionShop>();
        public LegionShop QueryLegionShop(Player player)
        {
            var now = DateTime.Now;
            if (!_instances.TryGetValue(player.Id, out var instance))
            {
                instance = _db.LegionShops
                    .FirstOrDefault(m => m.PlayerId == player.Id);
                if (instance == null)
                {
                    instance = new LegionShop()
                    {
                        PlayerId = player.Id,
                    };                    
                    _db.LegionShops.Add(instance);
                    _db.SaveChanges();
                }
                else
                {
                    foreach(var tmp in instance.SoldItems.Split(","))
                    {
                        string[] ts = tmp.Split(":");
                        int id = int.Parse(ts[0]);
                        int cnt = int.Parse(ts[1]);
                        instance.SoldItemsDict.Add(id, cnt);
                    }
                }
                _instances.Add(player.Id, instance);
            }
            //判断刷新时间
            if (instance.LastRefreshTime.Date != DateTime.Today)
            {
                instance.SoldItems = string.Empty;
                instance.SoldItemsDict.Clear();
                instance.LastRefreshTime = now;
                _db.SaveChanges();
            }

            return instance;
        }

        public LegionShopCommodityInfo ToInfo(DLegionShopItem dc, int sold)
        {
            LegionShopCommodityInfo info = new LegionShopCommodityInfo
            {
                count = dc.item_cnt,
                id = dc.id,
                item_id = dc.item_id,
                res_type = dc.cost_res_type,
                res_cnt = dc.cost_res_cnt,
                limit_cnt = dc.commodity_stock - sold,
                order = dc.order,
                lv = dc.level_min
            };
            return info;
        }
        #endregion        
    }
}
