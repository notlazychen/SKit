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
    public class MallShopModule : GameModule
    {

        private DataContext _db;

        public Dictionary<int, Dictionary<int, DMallShopItem>> DMallShopItems { get; private set; }//diff>day>x
        public Dictionary<int, DMallShop> DMallShops { get; private set; }
        
        public MallShopModule(DataContext db, GameDesignContext design)
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
                DMallShopItems = designDb.DMallShopItem.AsNoTracking().GroupBy(x=>x.type).ToDictionary(x => x.Key, x => x.ToDictionary(y=>y.id, y=>y));
                DMallShops = designDb.DMallShop.AsNoTracking().ToDictionary(x=>x.type, x=>x);
            });
        }


        #region 事件

        #endregion

        #region 辅助方法
        private Dictionary<string, Mall> _instances = new Dictionary<string, Mall>();
        public Mall QueryMall(string pid)
        {
            var now = DateTime.Now;
            if (!_instances.TryGetValue(pid, out var instance))
            {
                instance = _db.Malls
                    .Include(m=>m.Shops)
                        .ThenInclude(s=>s.ShopCommodities)
                    .FirstOrDefault(l => l.PlayerId == pid);
                if (instance == null)
                {
                    instance = new Mall()
                    {
                        PlayerId = pid,
                    };

                    foreach(var dshop in DMallShops.Values)
                    {
                        var shop = new MallShop();
                        shop.LastRefreshTime = now;
                        shop.PlayerId = pid;
                        RandomShopCommdities(shop, dshop);
                        shop.Type = dshop.type;
                        instance.Shops.Add(shop);
                    }
                    _db.Malls.Add(instance);
                    _db.SaveChanges();
                }
                _instances.Add(pid, instance);
            }
            foreach (var shop in instance.Shops)
            {
                var dshop = this.DMallShops[shop.Type];
                //判断刷新时间
                if (now.IsPass(shop.LastRefreshTime, dshop.refresh_hour.Object))
                {
                    RandomShopCommdities(shop, dshop);
                    shop.LastRefreshTime = now;
                    _db.SaveChanges();
                }
            }
            return instance;
        }

        public MallShopInfo ToInfo(MallShopCommodity c)
        {
            if (!this.DMallShopItems[c.Type].ContainsKey(c.CommodityId))
            {
                return null;
            }
            var dc = this.DMallShopItems[c.Type][c.CommodityId];
            MallShopInfo info = new MallShopInfo
            {
                count = dc.count,
                id = dc.id,
                item_id = dc.item_id,
                res_type = dc.res_type,
                res_cnt = dc.res_cnt,
                type = dc.type,
                limit_cnt = 1 - c.SoldCount
            };
            return info;
        }
        #endregion

        public void RandomShopCommdities(MallShop shop, DMallShop dshop)
        {
            var source = this.DMallShopItems[dshop.type].Values.ToList();
            if(shop.ShopCommodities.Count != dshop.size)
            {
                int deltalength = dshop.size - shop.ShopCommodities.Count;
                if(deltalength < 0)
                {
                    //多出来的删掉
                    for(int i = 0; i< -deltalength; i++)
                    {
                        var c = shop.ShopCommodities.First();
                        shop.ShopCommodities.Remove(c);
                        _db.MallShopCommodities.Remove(c);
                    }
                }
                else
                {
                    //不足的补上
                    for (int i = 0; i < deltalength; i++)
                    {
                        MallShopCommodity commodity = new MallShopCommodity
                        {
                            PlayerId = shop.PlayerId,
                            Type = dshop.type,
                        };
                        shop.ShopCommodities.Add(commodity);
                    }
                }
            }
            foreach(var c in shop.ShopCommodities)
            {
                var item = MathUtils.RandomElement(source, s => s.rate);
                if (item == null)
                    break;
                source.Remove(item);
                c.CommodityId = item.id;
                c.SoldCount = 0;
            }
        }
    }
}
