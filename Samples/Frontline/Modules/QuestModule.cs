using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKit.Common.Utils;

namespace Frontline.Modules
{
    public class QuestModule : GameModule
    {
        public Dictionary<int, DQuestDailyReward> DQuestDailyRewards { get; private set; }
        public Dictionary<int, DQuestDaily> DQuestDailys { get; private set; }
        public Dictionary<int, DQuest> DQuests { get; private set; }

        private DataContext _db;
        private PlayerModule _playerModule;

        public QuestModule(DataContext db)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DQuestDailyRewards = designDb.DQuestDailyReward.AsNoTracking().ToDictionary(x => x.id, x => x);
                DQuestDailys = designDb.DQuestDaily.AsNoTracking().ToDictionary(x => x.id, x => x);
                DQuests = designDb.DQuest.AsNoTracking().ToDictionary(x => x.id, x => x);
            });
        }

        private Dictionary<string, PlayerQuestData> _playerDatas = new Dictionary<string, PlayerQuestData>();

        #region API
        public PlayerQuestData QueryPlayerQuestData(string pid)
        {
            if (string.IsNullOrEmpty(pid))
                return null;
            var player = _playerModule.QueryPlayer(pid);
            if (player == null)
                return null;
            if (!_playerDatas.TryGetValue(pid, out var data))
            {
                data = _db.PlayerQuestDatas
                    .Include(p => p.Quests)
                    .Include(p => p.QuestDailys)
                    .FirstOrDefault(q => q.PlayerId == pid);
                if (data == null)
                {
                    data = new PlayerQuestData()
                    {
                        PlayerId = pid,
                        LastRefreshDay = DateTime.Today,
                    };
                    //初始化主线任务
                    foreach (DQuest dq in DQuests.Values)
                    {
                        if (dq.index == 1)
                        {
                            Quest quest = new Quest();
                            quest.Id = Guid.NewGuid().ToString();
                            quest.Tid = dq.id;
                            quest.PlayerId = pid;
                            if (dq.limit_level <= player.Level)
                            {
                                quest.Status = QuestState.Doing;
                                //任务需要一个进度初始化
                                int v = 0;// QuestConditionMgr.getInstance().getInitialValue(player.getId(), q.getCondition_type(), q.getCondition_target());
                                quest.Progress = v;
                            }
                            else
                            {
                                quest.Status = QuestState.Waiting;
                            }
                            data.Quests.Add(quest);
                        }
                    }
                    //初始化每日任务
                    TryRefershDailyQuest(player, data, true);
                    _db.PlayerQuestDatas.Add(data);
                    _db.SaveChanges();
                }
                _playerDatas.Add(pid, data);
            }
            TryRefershDailyQuest(player, data);
            return data;
        }

        private void TryRefershDailyQuest(Player player, PlayerQuestData data, bool force = false)
        {
            if (force || data.LastRefreshDay.Date != DateTime.Today)
            {
                var quests = data.QuestDailys;
                _db.QuestDailys.RemoveRange(quests);
                _db.SaveChanges();

                foreach (DQuestDaily dq in DQuestDailys.Values)
                {
                    if (dq.level_area.Object[0] <= player.Level && dq.level_area.Object[1] >= player.Level)
                    {
                        QuestDaily q = new QuestDaily();
                        q.Tid = dq.id;
                        q.PlayerId = player.Id;
                        q.Id = Guid.NewGuid().ToString();
                        int v = 0;// QuestConditionMgr.getInstance().getInitialValue(player.getId(), quest.getCondition_type(), quest.getCondition_target());
                        q.Progress = v;
                        data.QuestDailys.Add(q);
                    }
                }
                //初始化每日任务活跃度
                var dailyPointReward = new List<int>();
                foreach (DQuestDailyReward dqr in DQuestDailyRewards.Values)
                {
                    if (dqr.lv.Object[0] <= player.Level && dqr.lv.Object[1] >= player.Level)
                    {
                        dailyPointReward.Add(dqr.id);
                    }
                }
                data.LastRefreshDay = DateTime.Today;
                data.DailyPoint = 0;
                data.RecvedDailyPointReward = string.Empty;
                data.DailyPointReward = dailyPointReward.ManyToString(x => x.ToString());
                if (!force)
                {
                    _db.SaveChanges();
                }
            }
        }
        #endregion
    }

    public class ConditionType
    {
        public const int LevelUp = 1;//玩家等级
        public const int NormalMissionAccomplishTimes = 2;//通关普通副本次数
        public const int NormalMissionAccomplished = 3;//已通关普通副本
        public const int AdvancedMissionAccomplishTimes = 4;//通关精英副本次数
        public const int AdvancedMissionAccomplished = 5;//已通关精英副本
        public const int EquipmentLevelUpTimes = 6;//装备升级次数
        public const int EquipmentMaxLevel = 7;//装备最高等级

        public const int UnitLevelUpTimes = 8;//兵种升级次数
        public const int UnitMaxLevel = 9;
        public const int UnitMaxGrade = 10;//兵种最高进阶等级
        public const int DefendTimes = 11;//抵抗前线次数
        public const int DefendMaxLevel = 12;//抵抗前线最高波数
        public const int OilBoughtTimes = 13;//购买原油次数
        public const int GoldBoughtTimes = 14;//购买金币次数
        public const int BattleSkillUsedTimes = 15;//战斗中使用技能次数
        public const int UnitGradeUpTimes = 16;//兵种进阶次数

        public const int BuyItemInMall = 17;//在商城购买道具
        public const int BuyItemInBattleFieldShop = 18;//在战地商店购买道具
        public const int GRAB_FLAG_TIMES = 19;//夺旗战次数

        //        public static final int LEVEL_UP_TO = 20;//玩家升到指定等级
        public const int USE_ITEM_TIMES = 21;//使用指定道具
        public const int TEAM_COUNT_CHANGE = 22;//上阵兵种数量改变
        public const int SEND_FRIEND_REQUEST_TIMES = 23;//发出申请好友次数
        public const int SEND_FRIEND_OIL_TIMES = 24;//赠送好友原油次数
        public const int UNIT_UNLOCK_TIMES = 25;//兵营解锁新兵种次数
        public const int UNIT_NUMBER_RESET_TIMES = 26;//兵营休整次数
        public const int SCIENCE_DEV_TIMES = 27;//科研中心研发科技次数
        public const int RESET_WORKERS_TIMES = 28;//后勤基地分配完毕次数
        public const int JOIN_PARTY = 29;//加入一个军团

        public const int YunShu_TIMES = 30;//运输线次数
        public const int XueDiYinJiu_Times = 31;//雪地营救战次数
        public const int TianTi_TIMES = 32;//天梯战次数
        public const int QianTanBaoWei_Times = 33;//抢滩保卫战次数

        public const int Friend_Count = 35;//拥有好友数        
        public const int Unit_Count = 36;//拥有兵种数        
        public const int NoDamagePassRescue = 37;//零死亡过雪地营救次数
        public const int WeekBattleNumber = 38;//周常挑战次数
        public const int WeekBattleScore = 39;//周常挑战积分
        public const int WeekBattleNumberIn2Minutes = 40;//2分钟内完成周常挑战次数
        public const int LadderLevel = 41;//天梯段位
        public const int JoinGVG = 42;//参加军团战
        public const int NormalPVPNumber = 43;//参加单人对抗模式次数
        public const int NoDamagePassTransport = 44;//无损通过运输线
        public const int GuildDonate = 45;//军团捐献
        public const int MoneyPay = 46;//人民币支付
    }

    public enum UpdateMethod
    {
        Increase,
        Override
    }
}
