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
        public Dictionary<int, Dictionary<int, List<DRandom>>> DRandoms { get; private set; }// randomid> group> xset

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
                DItems = designDb.DItem.AsNoTracking().ToDictionary(x => x.tid, x => x);
                DRandoms = designDb.DRandom.AsNoTracking().GroupBy(x => x.random).ToDictionary(x => x.Key, x => x.GroupBy(g => g.group).ToDictionary(g => g.Key, g => g.ToList()));
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
            RewardInfo ri = new RewardInfo() { res = new List<ResInfo>(), items = new List<RewardItem>() };

            if (DRandoms.TryGetValue(randomId, out var groups))
            {
                foreach (var group in groups.Values)
                {
                    var rand = MathUtils.RandomElement(group, g => g.w);
                    if (rand == null)
                        continue;
                    int cnt = MathUtils.RandomNumber(rand.min, rand.max + 1);
                    if (rand.tid == 0)
                        continue;
                    if (rand.type <= 1)
                    {
                        ri.res.Add(new ResInfo { type = rand.tid, count = cnt });
                    }
                    else if (rand.type >= 2)
                    {
                        DItem ditem = this.DItems[rand.tid];
                        ri.items.Add(new RewardItem { id = rand.tid, count = cnt, icon = ditem.icon, name = ditem.name, quality = ditem.quality, type = ditem.type });
                    }
                }

                foreach (var element in ri.items.GroupBy(itm => itm.id))
                {
                    PlayerItem item = this.AddItem(player, element.Key, element.Sum(x => x.count), reason);
                }
                var playerModule = Server.GetModule<PlayerModule>();
                foreach (var element in ri.res.GroupBy(itm => itm.type))
                {
                    playerModule.AddCurrency(player, element.Key, element.Sum(x => x.count), reason);
                }
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
                if (itemcnt == 0)
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
