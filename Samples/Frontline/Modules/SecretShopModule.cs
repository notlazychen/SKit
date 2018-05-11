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
    public class SecretShopModule : GameModule
    {

        private DataContext _db;

        public Dictionary<int, List<DSecretShop>> DSecretShops { get; private set; }//mission_type>shop_id>x
        public Dictionary<int, DSecretShopItem> DSecretShopItems { get; private set; }
        public Dictionary<int, Dictionary<int, DSecretShopItem>> DSecretShopItemsByGroup { get; private set; }//group>int>x

        private DungeonModule _dungeonModule;
        public SecretShopModule(DataContext db, GameDesignContext design)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            //事件注册
            var playerModule = this.Server.GetModule<PlayerModule>();
            _dungeonModule = this.Server.GetModule<DungeonModule>();

            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DSecretShops = designDb.DSecretShop.AsNoTracking().GroupBy(g => g.mission_type).ToDictionary(g => g.Key, g => g.ToList());
                DSecretShopItems = designDb.DSecretShopItem.AsNoTracking().ToDictionary(x => x.id, x => x);
                DSecretShopItemsByGroup = DSecretShopItems.Values.GroupBy(g => g.group).ToDictionary(g => g.Key, g => g.ToDictionary(x => x.id, x => x));
            });

            _dungeonModule.PassDungeon += _dungeonModule_PassDungeon;
        }

        private void _dungeonModule_PassDungeon(Player who, DungeonPassEventArgs args)
        {
            var shop = this.QuerySecretShop(who.Id);
            var now = DateTime.Now;
            bool isOpen = shop.OpenTime <= now && shop.CloseTime >= now;
            if (!isOpen && shop.TriggerCD <= now)
            {
                if (DSecretShops.TryGetValue(args.Dungeon.Type, out var dgs))
                {
                    DSecretShop ds = null;
                    foreach (var d in dgs)
                    {
                        if (d.trigger_lv.Object[0] <= who.Level && d.trigger_lv.Object[1] >= who.Level)
                        {
                            ds = d;
                            break;
                        }
                    }
                    if (ds == null)
                        return;
                    shop.OpenTime = now;
                    shop.CloseTime = now.AddSeconds(ds.duration_second);
                    shop.TriggerCD = now.AddSeconds(ds.interval_second);
                    var list = this.DSecretShopItemsByGroup[ds.shop_id].Values.ToList();
                    if (shop.SecretShopItems.Any())
                    {
                        foreach (var item in shop.SecretShopItems)
                        {
                            var ditem = MathUtils.RandomElement(list, l => l.w);
                            item.Tid = ditem.id;
                            item.SoldCount = 0;
                            list.Remove(ditem);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            var ditem = MathUtils.RandomElement(list, l => l.w);
                            var item = new SecretShopItem()
                            {
                                Id = Guid.NewGuid().ToString(),
                                PlayerId = who.Id,
                                Tid = ditem.id,
                                SoldCount = 0,
                            };
                            shop.SecretShopItems.Add(item);
                            list.Remove(ditem);
                        }
                    }

                    _db.SaveChanges();

                    //推送
                    SecretShopOpenNotify notify = new SecretShopOpenNotify()
                    {
                        beginTime = shop.OpenTime.ToUnixTime(),
                        endTime = shop.CloseTime.ToUnixTime(),
                        commodities = new List<SecretShopCommodityInfo>()
                    };
                    foreach (var item in shop.SecretShopItems)
                    {
                        var info = new SecretShopCommodityInfo();
                        var ditem = this.DSecretShopItems[item.Tid];
                        info.id = item.Tid;
                        info.limit_cnt = ditem.limit_cnt - item.SoldCount;
                        info.item_cnt = ditem.item_cnt;
                        info.item_id = ditem.item_id;
                        info.res_type = ditem.res_type;
                        info.original_price = ditem.old_price;
                        info.current_price = ditem.cur_price;
                        info.vip = ditem.vip;
                        notify.commodities.Add(info);
                    }
                    Server.SendByUserNameAsync(who.Id, notify);
                }

            }
        }


        #region 事件

        #endregion

        #region 辅助方法
        private Dictionary<string, SecretShop> _shops = new Dictionary<string, SecretShop>();
        public SecretShop QuerySecretShop(string pid)
        {
            if (!_shops.TryGetValue(pid, out var shop))
            {
                shop = _db.SecretShops
                    .Include(s => s.SecretShopItems)
                    .FirstOrDefault(d => d.PlayerId == pid);
                if (shop == null)
                {
                    shop = new SecretShop();
                    shop.PlayerId = pid;
                    //shop.IsOpen = false;
                    _db.SecretShops.Add(shop);
                    _db.SaveChanges();
                }
                _shops.Add(pid, shop);
            }
            return shop;
        }
        #endregion
    }
}
