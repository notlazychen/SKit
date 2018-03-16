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

namespace Frontline.GameControllers
{
    public class PkgController : GameController
    {
        private GameDesignContext _design;
        private DataContext _db;
        public PkgController(DataContext db, GameDesignContext design)
        {
            _db = db;
            _design = design;
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
        private ItemInfo ToItemInfo(PlayerItem item)
        {
            var ditem = _design.DItems.FirstOrDefault(d => d.tid == item.Tid);

            ItemInfo ii = new ItemInfo();
            ii.id = $"{item.PlayerId}I{item.Tid}";
            ii.tid = item.Tid;
            ii.lap = item.Count;
            if (ditem != null)
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

        #endregion

        #region 客户端接口
        public void PkgInfo(PkgInfoRequest request)
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

        public void UseItem(UseItemRequest request)
        {

            int itemCnt = 1;
            if (request.cnt > itemCnt)
            {
                itemCnt = request.cnt;
            }
            UseItemResponse response = new UseItemResponse();
            response.id = request.id;

            var player = CurrentSession.GetBindPlayer();
            var item = player.Items.FirstOrDefault(x => x.Id == request.id);
            if (item == null)
                return;

            if (item.Count < itemCnt)
                return;

            DItem di = _design.DItems.First(d => d.tid == item.Tid);

            if (!di.useable)
            {
                return;
            }
            int unitId = di.breakUnitId;//使用后解锁的兵种id
            if (unitId > 0)
            {
                //UnitService us = Spring.bean(UnitService.class);
                //Unit u = us.addUnit(item.getPid(), unitId, 0);
                //if (u != null) {
                //    response.setSuccess(true);
                //    response.setUnitInfo(us.unitInfo(rojo, u));
                //}
            }
            else if (di.breakRandomId > 0)//使用后可以获得随机库
            {
                //int randomId = di.getBreakRandomId();
                // D_ItemGroup group = engine.get(D_ItemGroup.class, new File("./script/itemGroups/" + randomId + ".groovy"));
                //PkgService ps = Spring.bean(PkgService.class);
                //RewardInfo ri = new RewardInfo();
                //for (int i = 0; i<cnt; i++) {
                //    RewardInfo ri2 = ps.reward(item.getPid(), group, Reason.M_USEITEM + di.getName());
                //    if (ri2 != null) {
                //        ri.addReward(ri2);
                //    }
                //}
                //response.setRewardInfo(ri);
                //response.setSuccess(true);
            }
            else if (di.breakCount > 0)//资源
            {
                //                    response.setRewardInfo(new RewardInfo());
                //                    Support su = Spring.bean(PlayerService.class).getSupport(item.getPid());

                //int resType = type(di.getType());
                //su.addRes(resType, di.getBreakCount() * cnt, Reason.M_USEITEM + di.getName());
                //                    rojo.updateAndFlush(su, su.getResField(resType));
                //                    response.getRewardInfo().addRes(resType, di.getBreakCount());
                //response.setSuccess(true);
            }
            else if (di.type == 18)
            {
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
                player.Items.Remove(item);
            }
            response.lap = item.Count;
            CurrentSession.SendAsync(response);
        }
        #endregion
    }
}
