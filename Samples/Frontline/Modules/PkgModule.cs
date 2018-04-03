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
    public class PkgModule : GameModule
    {
        
        private DataContext _db;

        public Dictionary<int, DItem> DItems { get; private set; }
        public Dictionary<int, DRandom> DRandoms { get; private set; }

        public PkgModule(DataContext db, GameDesignContext design)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            //事件注册
            var playerModule = this.Server.GetModule<PlayerModule>();
            playerModule.PlayerCreating += _PlayerController_PlayerCreating;
            playerModule.PlayerLoading += PlayerController_PlayerLoading;

            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DItems = designDb.DItems.AsNoTracking().ToDictionary(x => x.tid, x => x);
                DRandoms = designDb.DRandoms.AsNoTracking().ToDictionary(x => x.id, x => x);
            });
        }

        private void PlayerController_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader.Include(p => p.Items);
        }


        private void _PlayerController_PlayerCreating(object sender, Player e)
        {
            PlayerItem item = new PlayerItem()
            {
                PlayerId = e.Id,
                Tid = 40000001,
                Count = 1
            };
            e.Items.Add(item);
        }

        #region 事件
        public event EventHandler<PlayerItem> ItemUsed;
        private void RaiseItemUsed(PlayerItem item)
        {
            ItemUsed?.Invoke(this, item);
        }
        #endregion

        #region 辅助方法
        public ItemInfo ToItemInfo(PlayerItem item)
        {
            ItemInfo ii = new ItemInfo();
            ii.id = item.Id;
            ii.tid = item.Tid;
            ii.lap = item.Count;
            DItem ditem;
            if (DItems.TryGetValue(item.Tid, out ditem))
            {
                ii.name = ditem.name;
                ii.desc = ditem.desc;
                ii.useable = ditem.useable;
                ii.type = ditem.type;
                ii.quality = ditem.quality;
                ii.icon = ditem.icon;
                ii.breakCount = ditem.breakCount;
                ii.breakRandomId = ditem.breakRandomId;
                ii.breakUnitId = ditem.breakUnitId;
                ii.price = ditem.price;
                ii.overlap = ditem.overlap;
                //ii.synthCount = ditem.s;
                //ii.synthId;
                //ii.synthCost;
            }
            return ii;
        }

        public void SubItems(Player player, int[] itemids, int[] itemcnts, string reason)
        {
            for (int i = 0; i < itemids.Length; i++)
            {
                int itemid = itemids[i];
                int itemcnt = itemcnts[i];
                if (itemcnt == 0)
                {
                    continue;
                }
                PlayerItem item;
                this.TrySubItem(player, itemid, itemcnt, reason, out item);
            }
        }
        public bool TrySubItem(Player player, int itemId, int count, string reason, out PlayerItem item)
        {
            item = player.Items.FirstOrDefault(x => x.Tid == itemId);
            if (item == null)
            {
                return false;
            }
            else
            {
                if (item.Count >= count)
                {
                    item.Count -= count;
                    if (item.Count <= 0)
                    {
                        //player.Items.Remove(item);
                        _db.Items.Remove(item);
                    }

                    ResourceAmountChangedNotify notify = new ResourceAmountChangedNotify
                    {
                        success = true,
                        items = new List<ResourceInfo>()
                        {
                            new ResourceInfo()
                            {
                                type = 2,
                                id = itemId,
                                count = item.Count,
                                sid = item.Id
                            }
                        }
                    };
                    Server.SendByUserNameAsync(player.Id, notify);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AddItems(Player player, int[] itemIds, int[] counts, string reason)
        {
            ResourceAmountChangedNotify notify = new ResourceAmountChangedNotify
            {
                success = true,
                items = new List<ResourceInfo>()
            };
            for (int i = 0; i < itemIds.Length; i++)
            {
                var itemId = itemIds[i];
                var count = counts[i];
                if (count == 0)
                    continue;
                var item = player.Items.FirstOrDefault(x => x.Tid == itemId);
                if (item == null)
                {
                    item = new PlayerItem()
                    {
                        Tid = itemId,
                        PlayerId = player.Id,
                        Count = count,
                        Id = Guid.NewGuid().ToString("D")
                    };
                    player.Items.Add(item);
                }
                else
                {
                    item.Count += count;
                }

                notify.items.Add(new ResourceInfo()
                {
                    type = 2,
                    id = itemId,
                    count = item.Count,
                    sid = item.Id
                });                
            }
            Server.SendByUserNameAsync(player.Id, notify);
        }

        public PlayerItem AddItem(Player player, int itemId, int count, string reason)
        {
            var item = player.Items.FirstOrDefault(x => x.Tid == itemId);
            if (item == null)
            {
                item = new PlayerItem()
                {
                    Tid = itemId,
                    PlayerId = player.Id,
                    Count = count,
                    Id = Guid.NewGuid().ToString("D")
                };
                player.Items.Add(item);
            }
            else
            {
                item.Count += count;
            }

            ResourceAmountChangedNotify notify = new ResourceAmountChangedNotify
            {
                success = true,
                items = new List<ResourceInfo>()
                {
                    new ResourceInfo()
                    {
                        type = 2,
                        id = itemId,
                        count = item.Count,
                        sid = item.Id
                    }
                }
            };
            Server.SendByUserNameAsync(player.Id, notify);

            _db.SaveChanges();
            return item;
        }

        public RewardInfo RandomReward(Player player, int randomId, int times, string reason)
        {
            DRandom di = DRandoms[randomId];
            RewardInfo ri = new RewardInfo();
            ri.items = new List<RewardItem>();
            ri.res = new List<ResInfo>();
            for (int t = 0; t < times; t++)
            {
                if (di.weight.Object.Length <= 0)//必掉
                {
                    if (di.gid.Object.Length > 0)
                    {
                        for (int i = 0; i < di.gid.Object.Length; i++)
                        {
                            DItem d = DItems[di.gid.Object[i]];
                            RewardItem rii = new RewardItem();
                            rii.count = di.count.Object[i];
                            rii.icon = d.icon;
                            rii.id = di.gid.Object[i];
                            rii.name = d.name;
                            rii.quality = d.quality;
                            rii.type = d.type;
                            ri.items.Add(rii);
                        }
                    }
                    if (di.res_type.Object.Length > 0)
                    {
                        for (int i = 0; i < di.res_type.Object.Length; i++)
                        {
                            ResInfo res = new ResInfo()
                            {
                                type = di.res_type.Object[i],
                                count = di.res_count.Object[i]
                            };
                            ri.res.Add(res);
                        }
                    }
                }
                else//随机一个
                {
                    int index = MathUtils.RandomIndex(di.weight.Object);
                    if (di.gid.Object.Length > 0)
                    {
                        //约定，如果随机的话，随机到小于等于0的id就是没随到东西
                        int itemId = di.gid.Object[index];
                        if (itemId > 0)
                        {
                            DItem d = DItems[di.gid.Object[index]];
                            RewardItem rii = new RewardItem();
                            rii.count = di.count.Object[index];
                            rii.icon = d.icon;
                            rii.id = di.gid.Object[index];
                            rii.name = d.name;
                            rii.quality = d.quality;
                            rii.type = d.type;
                            ri.items.Add(rii);
                        }
                    }
                    else if (di.res_type.Object.Length > 0)
                    {
                        //约定，如果随机的话，随机到小于等于0的id就是没随到东西
                        int resType = di.res_type.Object[index];
                        if (resType > 0)
                        {
                            ResInfo res = new ResInfo()
                            {
                                type = di.res_type.Object[index],
                                count = di.res_count.Object[index]
                            };
                            ri.res.Add(res);
                        }
                    }
                }
            }

            foreach(var element in ri.items.GroupBy(itm => itm.id)){
                PlayerItem item = this.AddItem(player, element.Key, element.Sum(x=>x.count), reason);
            }
            var playerModule = Server.GetModule<PlayerModule>();
            foreach (var element in ri.res.GroupBy(itm => itm.type))
            {
                playerModule.AddCurrency(player, element.Key, element.Sum(x=>x.count), reason);
            }

            return ri;
        }

        public bool IsItemEnough(Player player, int[] itemids, int[] itemcnts)
        {
            if (itemids.Length > itemcnts.Length)
            {
                return false;
            }
            for (int i = 0; i < itemids.Length; i++)
            {
                int itemid = itemids[i];
                int itemcnt = itemcnts[i];
                if(itemcnt == 0)
                {
                    continue;
                }
                var item = player.Items.FirstOrDefault(x => x.Tid == itemid);
                if (item == null)
                {
                    return false;
                }
                else
                {
                    if (item.Count < itemcnt)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
