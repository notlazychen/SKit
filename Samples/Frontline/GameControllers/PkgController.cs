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

namespace Frontline.GameControllers
{
    public class PkgController : GameController
    {
        private GameDesignContext _designDb;
        private DataContext _db;

        Dictionary<int, DItem> _ditems;
        Dictionary<int, DRandom> _drandoms;

        public PkgController(DataContext db, GameDesignContext design)
        {
            _db = db;
            _designDb = design;
        }

        protected override void OnReadGameDesignTables()
        {
            _ditems = _designDb.DItems.AsNoTracking().ToDictionary(x => x.tid, x => x);
            _drandoms = _designDb.DRandoms.AsNoTracking().ToDictionary(x => x.id, x => x);
        }

        protected override void OnRegisterEvents()
        {
            //事件注册
            var playerController = this.Server.GetController<PlayerController>();
            playerController.PlayerCreating += _PlayerController_PlayerCreating;
            playerController.PlayerLoading += PlayerController_PlayerLoading;
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
            if (_ditems.TryGetValue(item.Tid, out ditem))
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
                    if (item.Count == 0)
                    {
                        //player.Items.Remove(item);
                        _db.Items.Remove(item);
                    }

                    ResourceAmountChangedNotify notify = new ResourceAmountChangedNotify();
                    notify.success = true;
                    notify.items = new List<ResourceInfo>()
                    {
                        new ResourceInfo()
                        {
                            type = 2,
                            id = itemId,
                            count = item.Count
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
                    Id = Guid.NewGuid().ToString("N")
                };
                player.Items.Add(item);
            }
            else
            {
                item.Count += count;
            }
            return item;
        }

        public RewardInfo RandomReward(Player player, int randomId, string reason)
        {
            DRandom di = _drandoms[randomId];
            RewardInfo ri = new RewardInfo();
            ri.items = new List<RewardItem>();
            ri.res = new List<ResInfo>();
            if (di.weight.Object.Length <= 0)//必掉
            {
                if (di.gid.Object.Length > 0)
                {
                    for (int i = 0; i < di.gid.Object.Length; i++)
                    {
                        PlayerItem item = this.AddItem(player, di.gid.Object[i], di.count.Object[i], reason);
                        DItem d = _ditems[di.gid.Object[i]];
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
                        //Support su = Spring.bean(PlayerService.class).getSupport(pid);
                        var playerController = Server.GetController<PlayerController>();
                        playerController.AddCurrency(player, di.res_type.Object[i], di.res_count.Object[i], reason);
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
                int index = MathUtil.RandomIndex(di.weight.Object);
                if (di.gid.Object.Length > 0)
                {
                    //约定，如果随机的话，随机到小于等于0的id就是没随到东西
                    int itemId = di.gid.Object[index];
                    if (itemId > 0)
                    {
                        PlayerItem item = this.AddItem(player, di.gid.Object[index], di.count.Object[index], reason);
                        DItem d = _ditems[di.gid.Object[index]];
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
                        var playerController = Server.GetController<PlayerController>();
                        playerController.AddCurrency(player, di.res_type.Object[index], di.res_count.Object[index], reason);

                        ResInfo res = new ResInfo()
                        {
                            type = di.res_type.Object[index],
                            count = di.res_count.Object[index]
                        };
                        ri.res.Add(res);
                    }
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

        #region 客户端接口
        public void Call_PkgInfo(PkgInfoRequest request)
        {
            //PkgInfoResponse response = JsonConvert.DeserializeObject<PkgInfoResponse>("{\"pid\":\"10000f2\",\"items\":[{\"breakUnitId\":0,\"icon\":14001,\"breakRandomId\":60000001,\"synthCost\":0,\"type\":9,\"tid\":40000001,\"quality\":1,\"useable\":true,\"overlap\":1,\"breakCount\":0,\"synthCount\":0,\"price\":0,\"name\":\"新手礼包\",\"lap\":1,\"id\":\"10000f2i40000001\",\"synthId\":0,\"desc\":\"新手发展必不可少的礼包\"}],\"success\":true}");
            var items = this.CurrentSession.GetBind<Player>().Items;
            PkgInfoResponse response = new PkgInfoResponse();
            response.success = true;
            response.pid = this.CurrentSession.UserId;
            response.items = new List<ItemInfo>();
            foreach (var item in items)
            {
                var ii = this.ToItemInfo(item);
                response.items.Add(ii);
            }
            CurrentSession.SendAsync(response);
        }

        public void Call_UseItem(UseItemRequest request)
        {

            int itemCnt = 1;
            if (request.cnt > itemCnt)
            {
                itemCnt = request.cnt;
            }
            var player = CurrentSession.GetBindPlayer();
            var item = player.Items.FirstOrDefault(x => x.Id == request.id);
            if (item == null)
                return;

            if (item.Count < itemCnt)
                return;

            DItem di = _ditems[item.Tid];

            if (!di.useable)
            {
                return;
            }

            UseItemResponse response = new UseItemResponse();
            response.id = request.id;
            response.success = true;
            int unitId = di.breakUnitId;//使用后解锁的兵种id
            string reason = $"使用道具{di.tid}";
            if (unitId > 0)
            {
                var campController = Server.GetController<CampController>();
                Unit u = campController.UnlockUnit(player, unitId, true);
                UnitInfo ui = campController.ToUnitInfo(u);
                response.unitInfo = ui;
            }
            else if (di.breakRandomId > 0)//使用后可以获得随机库
            {
                RewardInfo reward = this.RandomReward(player, di.breakRandomId, reason);
                response.rewardInfo = reward;
            }
            else if (di.breakCount > 0)//资源
            {
                var playerController = Server.GetController<PlayerController>();
                playerController.AddCurrency(player, di.type, di.breakCount, reason);
                response.rewardInfo = new RewardInfo();
                response.rewardInfo.res = new List<ResInfo>()
                {
                    new ResInfo(){type = di.type, count = di.breakCount}
                };
            }
            else if (di.type == 18)
            {
                //后勤基地工人+1
                //        int maxCnt = engine.getInt(Application.systemFile, "worker_max_cnt");
                //        Industry industry = Spring.bean(IndustryService.class).getIndustry(item.getPid());
                //        if (industry.getTotalWorkers() + cnt > maxCnt) {
                //            response.setInfo(Spring.errCode("item_use_fail_workersmax"));
                //            return response;
                //        }
                //        industry.setIdleWorkers(industry.getIdleWorkers() + cnt);
                //        industry.setTotalWorkers(industry.getTotalWorkers() + cnt);
                //        rojo.updateAndFlush(industry, "idleWorkers", "totalWorkers");
                //        BuyWorkerResponse resp = new BuyWorkerResponse();
                //resp.setSuccess(true);
                //        resp.setIdleWorkers(industry.getIdleWorkers());
                //        resp.setTotalWorkers(industry.getTotalWorkers());
                //        Support su = Spring.bean(PlayerService.class).getSupport(item.getPid());
                //    resp.setDiamond((int) su.getDiamond());
                //        Context.getContextServer().send(resp, item.getPid());
                //    response.setSuccess(true);
            }


            item.Count -= itemCnt;//减少堆叠
            if (item.Count <= 0)
            {
                _db.Items.Remove(item);
                //player.Items.Remove(item);
            }
            _db.SaveChanges();
            response.lap = item.Count;
            CurrentSession.SendAsync(response);
        }
        #endregion
    }
}
