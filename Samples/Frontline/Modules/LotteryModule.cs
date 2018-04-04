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

namespace Frontline.Modules
{
    public class LotteryModule : GameModule
    {
        
        private DataContext _db;

        public Dictionary<int, DLottery> DLotteries { get; private set; }
        public Dictionary<int, DLotteryGroup> DLotteryGroups { get; private set; }
        public Dictionary<int, List<DLotteryRand>> DLotteryRands { get; private set; }

        private Dictionary<string, Lottery> _lotteries = new Dictionary<string, Lottery>();

        public LotteryModule(DataContext db, GameDesignContext design)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DLotteries = designDb.DLotteries.AsNoTracking().ToDictionary(x => x.id, x => x);
                DLotteryGroups = designDb.DLotteryGroups.AsNoTracking().ToDictionary(x => x.id, x => x);
                DLotteryRands = designDb.DLotteryRands.AsNoTracking().GroupBy(x => x.group).ToDictionary(x => x.Key, x => x.ToList());
            });
        }

        #region 事件
        #endregion

        #region 辅助方法


        public Lottery QueryLottery(string pid)
        {
            if(!_lotteries.TryGetValue(pid, out var lottery))
            {
                lottery = _db.Lotteries.FirstOrDefault(l => l.PlayerId == pid);
                if(lottery == null)
                {
                    var dl1 = DLotteries[1];
                    var dl2 = DLotteries[2];
                    var now = DateTime.Now;
                    lottery = new Lottery()
                    {
                        PlayerId = pid,
                        GoldUsedNumb = 0,//今日金币抽次数  
                        GoldFreeNextTime = now,//下次免费金币抽刷新时间
                        GoldBaseNumb = GameConfig.lottery_base_cnt,//剩余出金币抽保底奖励的次数
                        GoldLastTime = now,//最后一次金币抽时间
                        GoldFreeNumb = dl1.free_cnt,
                        DmdUsedNumb = 0,//今日钻石抽次数   
                        DmdFreeNextTime = now,//下次免费钻石抽时间
                        DmdBaseNumb = GameConfig.lottery_base_cnt,//剩余出钻石保底奖励的次数
                        DmdLastTime = now,//最后一次钻石抽时间
                        DmdFreeNumb = dl2.free_cnt,
                        LastRefreshDay = DateTime.Today
                    };
                    _db.Lotteries.Add(lottery);
                    _db.SaveChanges();
                }
                _lotteries.Add(pid, lottery);
            }
            if (DateTime.Today != lottery.LastRefreshDay)
            {
                var dl1 = DLotteries[1];
                var dl2 = DLotteries[2];
                lottery.DmdFreeNumb = dl2.free_cnt;
                lottery.GoldFreeNumb = dl1.free_cnt;
                lottery.LastRefreshDay = DateTime.Today;
                _db.SaveChanges();
            }
            return lottery;
        }
        #endregion
    }

}

