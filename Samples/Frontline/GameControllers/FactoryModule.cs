using Frontline.Data;
using Frontline.GameDesign;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using SKit.Common.Utils;
using Frontline.Common;
using Microsoft.Extensions.Logging;

namespace Frontline.Modules
{
    public class FactoryModule : GameModule
    {
        
        private DataContext _db;
        private ILogger _logger;

        public Dictionary<int, DFacTaskGroup> DFacTaskGroups { get; private set; }
        public Dictionary<int, DFacTask> DFacTasks { get; private set; }
        public Dictionary<int, List<DFacTask>> DFacTasksByGroup { get; private set; }

        public Dictionary<int, DFacWorker> DFacWorkers { get; private set; } //type:{star:x}
        public Dictionary<int, Dictionary<int, DFacWorker>> DFacWorkersByTypeAndStar { get; private set; } //type:{star:x}

        private Dictionary<string, Factory> _factories = new Dictionary<string, Factory>();

        private PlayerModule _playerModule;
        public FactoryModule(DataContext db, GameDesignContext design, ILogger<FactoryModule> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        protected override void OnConfiguringModules()
        {
            _playerModule = Server.GetModule<PlayerModule>();

            var designModule = Server.GetModule<DesignDataModule>();
            designModule.Register(this, designDb =>
            {
                DFacWorkers = designDb.DFacWorker.AsNoTracking().ToDictionary(x => x.id, x => x);
                DFacWorkersByTypeAndStar = DFacWorkers.Values.GroupBy(w => w.type).ToDictionary(x => x.Key, x => x.ToDictionary(y => y.star, y => y));
                DFacTaskGroups = designDb.DFacTaskGroup.AsNoTracking().ToDictionary(x => x.id, x => x);
                DFacTasks = designDb.DFacTask.AsNoTracking().ToDictionary(x => x.id, x => x);
                DFacTasksByGroup = this.DFacTasks.Values.GroupBy(y => y.group).ToDictionary(z => z.Key, z => z.ToList());
            });
        }

        #region 事件
        #endregion

        #region 辅助方法
        public Factory QueryPlayerFactory(Player player)
        {
            bool isnew = false;
            bool needsave = false;
            if (!_factories.TryGetValue(player.Id, out var fac))
            {
                fac = _db.Factories
                    .Include(f => f.FacTasks)
                    .Include(f => f.FacWorkers)
                    .FirstOrDefault(f => f.PlayerId == player.Id);
                if (fac == null)
                {
                    isnew = true;
                    needsave = true;
                    fac = new Factory()
                    {
                        PlayerId = player.Id,
                        LastRefreshDay = DateTime.Today,
                    };
                    foreach (int type in GameConfig.FactoryInitWorkersType)
                    {
                        var worker = new FacWorker();
                        worker.Id = Guid.NewGuid().ToString();
                        worker.PlayerId = player.Id;
                        worker.Tid = DFacWorkersByTypeAndStar[type][1].id;
                        worker.State = FacWorkerState.Idle;
                        fac.FacWorkers.Add(worker);
                    }
                    _db.Factories.Add(fac);
                    RefreshMarket(fac);
                    //刷新任务
                    RefreshTask(player, fac);
                    _db.SaveChanges();
                }
                _factories.Add(player.Id, fac);
            }
            if (!isnew)
            {
                if (fac.LastRefreshDay.Date != DateTime.Today)
                {
                    needsave = true;
                    //刷新任务
                    fac.TodayMarketRefreshTimes = 0;
                    fac.LastRefreshDay = DateTime.Today;
                    RefreshMarket(fac);
                    RefreshTask(player, fac);
                }
                //else if (!fac.FacTasks.Any())
                //{
                //    needsave = true;
                //    RefreshTask(player, fac);
                //}
            }
            if (needsave)
            {
                _db.SaveChanges();
            }
            return fac;
        }

        public WorkerInfo ToWorkerInfo(FacWorker w)
        {
            return new WorkerInfo() { Id = w.Id, State = (int)w.State, Tid = w.Tid };
        }
        public WorkTaskInfo ToWorkTaskInfo(FacTask t)
        {  
            return new WorkTaskInfo()
            {
                Id = t.Id,
                EndTime = t.EndTime.ToUnixTime(),
                State = (int)t.State,
                Tid = t.Tid,
                Workers = t.FacWorkers.StringToMany(x => x),
            };
        }

        private void RefreshMarket(Factory fac)
        {
            _db.FacWorkers.RemoveRange(fac.FacWorkers.Where(w => w.State == FacWorkerState.Free || w.State == FacWorkerState.Fired));
            fac.FacWorkers.Where(w => w.InMarket).ToList().ForEach(w=>w.InMarket = false);           
            for (int i = 0; i < GameConfig.FactoryWorkerMarketLength; i++)
            {
                var worker = new FacWorker();
                worker.Id = Guid.NewGuid().ToString();
                worker.PlayerId = fac.PlayerId;
                var dw = MathUtils.RandomElement(DFacWorkers.Values, w => w.weight);
                worker.Tid = dw.id;
                worker.State = FacWorkerState.Free;
                worker.InMarket = true;
                fac.FacWorkers.Add(worker);
            }
            _db.SaveChanges();
        }

        private void RefreshTask(Player player, Factory fac)
        {
            //确定任务组
            var group = DFacTaskGroups.Values.FirstOrDefault(g => player.Level >= g.min_level && player.Level <= g.max_level);
            if (group == null)
                return;

            if (fac.FacTasks.Count == 0)
            {
                for (int i = 0; i < GameConfig.FactoryTaskLength; i++)
                {
                    var task1 = new FacTask();
                    task1.Id = Guid.NewGuid().ToString();
                    task1.State = FacTaskState.Waiting;
                    task1.PlayerId = player.Id;
                    var dt1 = MathUtils.RandomElement(DFacTasksByGroup[group.gourp_supply], t => t.w);
                    task1.Tid = dt1.id;
                    task1.Type = dt1.type;
                    fac.FacTasks.Add(task1);

                    var task2 = new FacTask();
                    task2.Id = Guid.NewGuid().ToString();
                    task2.State = FacTaskState.Waiting;
                    task2.PlayerId = player.Id;
                    var dt2 = MathUtils.RandomElement(DFacTasksByGroup[group.group_iron], t => t.w);
                    task2.Tid = dt2.id;
                    task2.Type = dt2.type;
                    fac.FacTasks.Add(task2);
                }
            }
            else
            {
                foreach (var task in fac.FacTasks)
                {
                    if (task.State == FacTaskState.Waiting)
                    {
                        if(DFacTasksByGroup.TryGetValue(task.Type == 1 ? group.gourp_supply : group.group_iron, out var tfg))
                        {
                            var dt = MathUtils.RandomElement(tfg, t => t.w);
                            task.Tid = dt.id;
                        }
                    }
                }
            }
            _db.SaveChanges();
        }
        #endregion

        #region 客户端接口
        public int Call_FactoryInfo(FactoryRequest request)
        {
            FactoryResponse response = new FactoryResponse();
            var fac = this.QueryPlayerFactory(_playerModule.QueryPlayer(Session.PlayerId));
            response.todayRefreshWorkerMarketNumb = fac.TodayMarketRefreshTimes;
            response.hireWorkersNumb = fac.HireWorkerNumb;
            response.workers = fac.FacWorkers
                .Where(w => w.State != FacWorkerState.Free && w.State != FacWorkerState.Fired)
                .Select(w => this.ToWorkerInfo(w)).ToList();
            response.workerMarket = fac.FacWorkers
                .Where(w => w.InMarket)
                .Select(w => this.ToWorkerInfo(w)).ToList();
            response.taskInfos = fac.FacTasks.Select(t => ToWorkTaskInfo(t)).ToList();
            Session.SendAsync(response);
            return 0;
        }

        public int Call_RefreshMarket(RefreshWorkerMarketRequest request)
        {
            //判断刷新次数够哦不够
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var playercon = Server.GetModule<PlayerModule>();
            var fac = this.QueryPlayerFactory(player);
            var vip = playercon.VIP[player.VIP];
            int remain = vip.work_day_hire_n - fac.TodayMarketRefreshTimes;
            if (remain <= 0)
            {
                return (int)GameErrorCode.工人市场刷新次数用尽;
            }

            RefreshWorkerMarketResponse response = new RefreshWorkerMarketResponse();
            response.success = true;
            this.RefreshMarket(fac);
            response.workerMarket = fac.FacWorkers.Where(w => w.InMarket).Select(this.ToWorkerInfo).ToList();
            Session.SendAsync(response);
            return 0;
        }
        /// <summary>
        /// 雇佣工人
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int Call_HireWorker(HireWorkerRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var playercon = Server.GetModule<PlayerModule>();
            var fac = this.QueryPlayerFactory(player);
            var worker = fac.FacWorkers.First(w => w.Id == request.id);
            if (worker.State != FacWorkerState.Free)
            {
                return (int)GameErrorCode.无此工人;
            }
            //判断钱够不够
            DFacWorker dw = DFacWorkers[worker.Tid];
            if (!playercon.IsCurrencyEnough(player, dw.res_type, dw.res_cnt))
            {
                return (int)GameErrorCode.资源不足;
            }
            //判断工人总数
            var canbuy = _playerModule.VIP[player.VIP].work_total_hire_n;
            if(fac.FacWorkers.Count(w=>!w.InMarket && w.State != FacWorkerState.Fired && w.State != FacWorkerState.Free) >= canbuy + 5)
            {
                return (int)GameErrorCode.雇佣人数已满;
            }
            string reason = $"雇佣工人{dw.id}";
            playercon.AddCurrency(player, dw.res_type, -dw.res_cnt, reason);
            worker.State = FacWorkerState.Idle;
            fac.HireWorkerNumb++;
            _db.SaveChanges();

            HireWorkerResponse response = new HireWorkerResponse();
            response.success = true;
            response.worker = ToWorkerInfo(worker);
            Session.SendAsync(response);
            return 0;
        }

        public int Call_FireWorker(FireWorkerRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var playercon = Server.GetModule<PlayerModule>();
            var fac = this.QueryPlayerFactory(player);
            var worker = fac.FacWorkers.First(w => w.Id == request.workerId);
            if (worker.State != FacWorkerState.Idle)
            {
                return (int)GameErrorCode.无此工人;
            }
            //fac.FacWorkers.Remove(worker);
            //_db.FacWorkers.Remove(worker);
            worker.State = FacWorkerState.Fired;
            _db.SaveChanges();
            FireWorkerResponse response = new FireWorkerResponse();
            response.success = true;
            response.workerid = request.workerId;
            Session.SendAsync(response);
            return 0;
        }

        public int Call_StartWork(StartWorkRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var playercon = Server.GetModule<PlayerModule>();
            var pkg = Server.GetModule<PkgModule>();
            var fac = this.QueryPlayerFactory(player);
            var task = fac.FacTasks.First(t => t.Id == request.taskid);
            var works = fac.FacWorkers.Where(w => request.workers.Contains(w.Id)).ToList();
            var dt = DFacTasks[task.Tid];
            //判断道具是否足够
            if(!pkg.IsItemEnough(player, new[] { dt.cost_item_id }, new[] { dt.cost_item_cnt }))
            {
                return (int)GameErrorCode.道具不足;
            }
            //判断工人是否符合
            bool can = works.Any(w => DFacWorkers[w.Tid].star >= dt.worker_q)
                && works.All(w=>w.State == FacWorkerState.Idle);
            if (!can)
            {
                return (int)GameErrorCode.工人品质未满足条件;
            }
            if(works.Count < dt.worker_num)
            {
                return (int)GameErrorCode.工人人数不足;
            }
            string reason = $"派遣任务{dt.id}";
            pkg.TrySubItem(player,dt.cost_item_id, dt.cost_item_cnt, reason, out var item);
            task.State = FacTaskState.Doing;
            task.FacWorkers = works.ManyToString(w => w.Id.ToString());
            task.EndTime = DateTime.Now.AddSeconds(dt.cost_time);
            task.IsWorkersReleased = false;
            foreach (var worker in works)
            {
                worker.State = FacWorkerState.Working;
            }
            _db.SaveChanges();

            StartWorkResponse response = new StartWorkResponse();
            response.success = true;
            response.taskInfo = ToWorkTaskInfo(task);
            Session.SendAsync(response);
            return 0;
        }

        public int Call_StopWork(StopWorkRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var playercon = Server.GetModule<PlayerModule>();
            var fac = this.QueryPlayerFactory(player);
            var task = fac.FacTasks.First(t => t.Id == request.taskid);
            if(task.State != FacTaskState.Doing)
            {
                return (int)GameErrorCode.不能撤回未派遣中的任务;
            }
            task.State = FacTaskState.Waiting;
            //撤回工人
            task.IsWorkersReleased = true;
            var workersId = task.FacWorkers.StringToMany(x => x);
            foreach (var w in fac.FacWorkers)
            {
                if (workersId.Contains(w.Id))
                {
                    w.State = FacWorkerState.Idle;
                }
            }
            StopWorkResponse response = new StopWorkResponse();
            response.success = true;
            response.taskInfo = ToWorkTaskInfo(task);
            Session.SendAsync(response);
            task.FacWorkers = string.Empty;
            _db.SaveChanges();
            return 0;
        }

        public int Call_Finish(FinishWorkRequest request)
        {
            var now = DateTime.Now;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var playercon = Server.GetModule<PlayerModule>();
            var fac = this.QueryPlayerFactory(player);
            var task = fac.FacTasks.First(t => t.Id == request.taskid);

            if (task.State != FacTaskState.Doing)
            {
                return (int)GameErrorCode.不能提交未派遣的任务;
            }
            var pkg = Server.GetModule<PkgModule>();
            var dt = DFacTasks[task.Tid];
            string reason = $"完成派遣任务{task.Tid}";
            if (task.EndTime > now)
            {
                if (request.useItem)
                {
                    //检查道具是否足够
                    if (!pkg.TrySubItem(player, dt.done_item_id, dt.done_item_cnt, reason, out var item))
                    {
                        return (int)GameErrorCode.道具不足;
                    }
                }
                else
                {
                    return (int)GameErrorCode.任务尚未完成;
                }
            }
            task.State = FacTaskState.Finish;
            var vip = playercon.VIP[player.VIP];
            double outAdd = 0;
            double itemexAdd = dt.reward_ex_prob;// + vip.work_reward_ex_prob;
            var worksId = task.FacWorkers.StringToMany(x=>x);
            foreach(var worker in fac.FacWorkers.Where(w => worksId.Contains(w.Id)))
            {
                var dw = DFacWorkers[worker.Tid];
                outAdd += dw.output_p /10000d;
                itemexAdd += dw.itemes_p/10000d;
            }
            RewardInfo reward = new RewardInfo() { res = new List<ResInfo>(), items = new List<RewardItem>() };
            int rescnt = (int)(dt.res_cnt * (1 + outAdd));
            reward.res.Add(new ResInfo() { type = dt.res_type, count = rescnt });
            playercon.AddCurrency(player, dt.res_type, rescnt, reason);
            for(int i = 0; i< dt.item_type.Object.Length; i++)
            {
                int itemid = dt.item_type.Object[i];
                int itemcnt = dt.item_cnt.Object[i];
                pkg.AddItem(player, itemid, itemcnt, reason);
                reward.items.Add(new RewardItem() {id = itemid, count = itemcnt });
            }
            //随机额外道具
            if(MathUtils.RandomNumber(0, 10000) <= (itemexAdd * 10000))
            {
                for (int i = 0; i < dt.item_id_ex.Object.Length; i++)
                {
                    int itemid = dt.item_id_ex.Object[i];
                    int itemcnt = dt.item_cnt_ex.Object[i];
                    pkg.AddItem(player, itemid, itemcnt, reason);
                    reward.items.Add(new RewardItem() { id = itemid, count = itemcnt });
                }
            }
            
            //完成则撤回工人
            task.IsWorkersReleased = true;
            var workersId = task.FacWorkers.StringToMany(x => x);
            foreach (var w in fac.FacWorkers)
            {
                if (workersId.Contains(w.Id))
                {
                    w.State = FacWorkerState.Idle;
                }
            }
            FinishWorkResponse response = new FinishWorkResponse();
            response.success = true;
            response.rewardInfo = reward;
            response.taskInfo = ToWorkTaskInfo(task);
            task.FacWorkers = string.Empty;
            _db.SaveChanges();

            Session.SendAsync(response);
            return 0;
        }
        #endregion
    }
}

