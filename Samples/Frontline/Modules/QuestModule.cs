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
    public delegate void GamePlayerEventHandler<TWho, TArgs>(TWho who, TArgs args);

    public class QuestModule : GameModule
    {
        public Dictionary<int, DQuestDailyReward> DQuestDailyRewards { get; private set; }
        public Dictionary<int, DQuestDaily> DQuestDailys { get; private set; }
        public Dictionary<int, DQuest> DQuests { get; private set; }

        private DataContext _db;
        private PlayerModule _playerModule;
        private DiKangModule _dikangModule;
        private LegionModule _legionModule;
        private FriendModule _friendModule;
        private DungeonModule _dungeonModule;
        private CampModule _campModule;
        private ArenaModule _arenaModule;
        private PkgModule _pkgModule;
        private TransportModule _transportModule;

        private Dictionary<int, Func<string, int, int, int>> _initConditions = new Dictionary<int, Func<string, int, int, int>>();

        public QuestModule(DataContext db)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            _dikangModule = Server.GetModule<DiKangModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _legionModule = Server.GetModule<LegionModule>();
            _friendModule = Server.GetModule<FriendModule>();
            _dungeonModule = Server.GetModule<DungeonModule>();
            _campModule = Server.GetModule<CampModule>();
            _arenaModule = Server.GetModule<ArenaModule>();
            _pkgModule = Server.GetModule<PkgModule>();
            _transportModule = Server.GetModule<TransportModule>();

            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DQuestDailyRewards = designDb.DQuestDailyReward.AsNoTracking().ToDictionary(x => x.id, x => x);
                DQuestDailys = designDb.DQuestDaily.AsNoTracking().ToDictionary(x => x.id, x => x);
                DQuests = designDb.DQuest.AsNoTracking().ToDictionary(x => x.id, x => x);
            });
            RegisterInitConditions();

            //注册监听事件
            _playerModule.PlayerLevelUp += (who, args)=>this.UpdateQuestProgress(who.Id, ConditionType.LevelUp, 0, UpdateMethod.Override, who.Level);
            _dungeonModule.PassDungeon += _dungeonModule_PassDungeon;
            _campModule.EquipLevelUp += _campModule_EquipLevelUp;
            _campModule.UnitLevelUp += _campModule_UnitLevelUp;
            _campModule.UnitGradeUp += _campModule_UnitGradeUp;
            _campModule.UnitUnlock += _campModule_UnitUnlock;
            _playerModule.PlayerBuyRes += _playerModule_PlayerBuyRes;
            _dikangModule.DikangBegin += _dikangModule_DikangBegin;
            _dikangModule.DikangPass += _dikangModule_DikangPass;
            _arenaModule.ArenaBattleOver += _arenaModule_ArenaBattleOver;
            _pkgModule.ItemUsed += _pkgModule_ItemUsed;
            _campModule.TeamSettingChanged += _campModule_TeamSettingChanged;
            _friendModule.SendFriendApplicationRequest += _friendModule_SendFriendApplicationRequest;
            _friendModule.SendFriendOil += _friendModule_SendFriendOil;
            _legionModule.PlayerJoinLegion += _legionModule_PlayerJoinLegion;
            _transportModule.TransportBattleOver += _transportModule_TransportBattleOver;
            _transportModule.TransportBattleAllLive += _transportModule_TransportBattleAllLive;
        }

        private void _transportModule_TransportBattleAllLive(string who, bool args)
        {
            UpdateQuestProgress(who, ConditionType.NoDamagePassTransport, 0, UpdateMethod.Increase, 1);
        }

        private void _transportModule_TransportBattleOver(string who, bool args)
        {
            UpdateQuestProgress(who, ConditionType.YunShu_TIMES, 0, UpdateMethod.Increase, 1);
        }

        private void _legionModule_PlayerJoinLegion(LegionMember who, Legion args)
        {
            UpdateQuestProgress(who.PlayerId, ConditionType.JOIN_PARTY, 0, UpdateMethod.Override, 1);
        }

        private void _campModule_UnitUnlock(Player player, UnitInfo e)
        {
            UpdateQuestProgress(e.pid, ConditionType.UNIT_UNLOCK_TIMES, e.tid, UpdateMethod.Increase, 1);
            UpdateQuestProgress(e.pid, ConditionType.Unit_Count, 0, UpdateMethod.Override, player.Units.Count);
        }

        private void _friendModule_SendFriendOil(string who, string args)
        {
            UpdateQuestProgress(who, ConditionType.SEND_FRIEND_OIL_TIMES, 0, UpdateMethod.Increase, 1);
        }

        private void _friendModule_SendFriendApplicationRequest(FriendList who, FriendList args)
        {
            UpdateQuestProgress(who.PlayerId, ConditionType.SEND_FRIEND_REQUEST_TIMES, 0, UpdateMethod.Increase, 1);
        }

        private void _campModule_TeamSettingChanged(object sender, Team e)
        {
            int cnt = e.Units.Object.Count(o => !string.IsNullOrEmpty(o));
            UpdateQuestProgress(e.PlayerId, ConditionType.TEAM_COUNT_CHANGE, 0, UpdateMethod.Override, cnt);
        }

        private void _pkgModule_ItemUsed(object sender, PlayerItem e)
        {
            UpdateQuestProgress(e.PlayerId, ConditionType.USE_ITEM_TIMES, e.Tid, UpdateMethod.Increase, 1);
        }

        private void _arenaModule_ArenaBattleOver(ArenaCert who, bool win)
        {
            UpdateQuestProgress(who.PlayerId, ConditionType.GRAB_FLAG_TIMES, win ? 1 : 2, UpdateMethod.Increase, 1);
        }

        private void _dikangModule_DikangPass(DiKang who, DDiKangQianXian wave)
        {
            UpdateQuestProgress(who.PlayerId, ConditionType.DefendMaxLevel, 0, UpdateMethod.Override, wave.wid);
        }

        private void _dikangModule_DikangBegin(DiKang who, DDiKangQianXian args)
        {
            UpdateQuestProgress(who.PlayerId, ConditionType.DefendTimes, 0, UpdateMethod.Increase, 1);
        }

        private void _playerModule_PlayerBuyRes(Player who, int type)
        {
            switch (type)
            {
                case CurrencyType.OIL:
                    UpdateQuestProgress(who.Id, ConditionType.OilBoughtTimes, 0, UpdateMethod.Increase, 1);
                    break;
                case CurrencyType.GOLD:
                    UpdateQuestProgress(who.Id, ConditionType.GoldBoughtTimes, 0, UpdateMethod.Increase, 1);
                    break;
            }        
        }

        private void _campModule_UnitGradeUp(object sender, UnitGradeUpEventArgs e)
        {
            UpdateQuestProgress(e.UnitInfo.pid, ConditionType.UnitMaxGrade, e.UnitInfo.tid, UpdateMethod.Override, e.UnitInfo.claz);
            UpdateQuestProgress(e.UnitInfo.pid, ConditionType.UnitGradeUpTimes, e.UnitInfo.tid, UpdateMethod.Increase, 1);
        }

        private void _campModule_UnitLevelUp(object sender, UnitLevelUpEventArgs e)
        {
            UpdateQuestProgress(e.UnitInfo.pid, ConditionType.UnitLevelUpTimes, e.UnitInfo.tid, UpdateMethod.Increase, 1);
            UpdateQuestProgress(e.UnitInfo.pid, ConditionType.UnitMaxLevel, e.UnitInfo.tid, UpdateMethod.Override, e.UnitInfo.level);
        }

        private void _campModule_EquipLevelUp(object sender, EquipLevelUpEventArgs e)
        {
            UpdateQuestProgress(e.UnitInfo.pid, ConditionType.EquipmentLevelUpTimes, e.EquipInfo.equipId, UpdateMethod.Increase, 1);
            UpdateQuestProgress(e.UnitInfo.pid, ConditionType.EquipmentMaxLevel, e.EquipInfo.equipId, UpdateMethod.Override, e.EquipInfo.level);
        }

        private void _dungeonModule_PassDungeon(Player who, Dungeon args)
        {
            if (args.Type == 1)
            {
                UpdateQuestProgress(who.Id, ConditionType.NormalMissionAccomplishTimes, args.Tid, UpdateMethod.Increase, 1);
                UpdateQuestProgress(who.Id, ConditionType.NormalMissionAccomplished, args.Tid, UpdateMethod.Override, 1);
            }
            else
            {
                UpdateQuestProgress(who.Id, ConditionType.AdvancedMissionAccomplishTimes, args.Tid, UpdateMethod.Increase, 1);
                UpdateQuestProgress(who.Id, ConditionType.AdvancedMissionAccomplished, args.Tid, UpdateMethod.Override, 1);
            }
        }

        private void RegisterInitConditions()
        {

            _initConditions.Add(ConditionType.LevelUp, (pid, conditionType, conditionTarget) =>
            {
                var player = _playerModule.QueryPlayer(pid);
                return player.Level;
            });
            _initConditions.Add(ConditionType.EquipmentMaxLevel, (pid, conditionType, conditionTarget) =>
            {
                var player = _playerModule.QueryPlayer(pid);
                int max = 0;
                foreach (Unit u in player.Units)
                {
                    foreach (Equip e in u.Equips)
                    {
                        if (e.Level > max)
                        {
                            max = e.Level;
                        }
                    }
                }
                return max;
            });
            _initConditions.Add(ConditionType.UnitMaxLevel, (pid, conditionType, conditionTarget) =>
            {
                var player = _playerModule.QueryPlayer(pid);
                int max = 0;
                foreach (Unit u in player.Units)
                {
                    if (u.Level > max)
                    {
                        max = u.Level;
                    }
                }
                return max;
            });
            _initConditions.Add(ConditionType.UnitMaxGrade, (pid, conditionType, conditionTarget) =>
            {
                var player = _playerModule.QueryPlayer(pid);
                int max = 0;
                foreach (Unit u in player.Units)
                {
                    if (u.Grade > max)
                    {
                        max = u.Grade;
                    }
                }
                return max;
            });
            _initConditions.Add(ConditionType.NormalMissionAccomplished, (pid, conditionType, conditionTarget) =>
            {
                var player = _playerModule.QueryPlayer(pid);
                var dungeonModule = Server.GetModule<DungeonModule>();
                foreach (var section in player.Sections)
                {
                    foreach (var dungeon in section.Dungeons)
                    {
                        if (dungeon.Tid == conditionTarget && dungeon.Star > 0)
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            });
            _initConditions.Add(ConditionType.AdvancedMissionAccomplished, (pid, conditionType, conditionTarget) =>
            {
                var player = _playerModule.QueryPlayer(pid);
                var dungeonModule = Server.GetModule<DungeonModule>();
                foreach (var section in player.Sections)
                {
                    foreach (var dungeon in section.Dungeons)
                    {
                        if (dungeon.Tid == conditionTarget && dungeon.Star > 0)
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            });
            _initConditions.Add(ConditionType.DefendMaxLevel, (pid, conditionType, conditionTarget) =>
            {
                var dikang = _dikangModule.QueryDiKang(pid);
                if (dikang == null)
                    return 0;
                return dikang.Best;
            });
            _initConditions.Add(ConditionType.TEAM_COUNT_CHANGE, (pid, conditionType, conditionTarget) =>
            {
                int size = 0;
                var player = _playerModule.QueryPlayer(pid);
                var team = player.Teams.FirstOrDefault(t => t.IsSelected);
                if (team != null)
                {
                    foreach (string bp in team.Units.Object)
                    {
                        if (string.IsNullOrEmpty(bp))
                        {
                            size++;
                        }
                    }
                }
                return size;
            });
            _initConditions.Add(ConditionType.JOIN_PARTY, (pid, conditionType, conditionTarget) =>
            {
                var pm = _legionModule.QueryLegionMember(pid);
                if (pm != null)
                {
                    if (!string.IsNullOrEmpty(pid))
                    {
                        return 1;
                    }
                }
                return 0;
            });
            _initConditions.Add(ConditionType.GuildDonate, (pid, conditionType, conditionTarget) =>
            {
                var pm = _legionModule.QueryLegionMember(pid);
                if (pm != null)
                {
                    if (!string.IsNullOrEmpty(pid))
                    {
                        return 1;
                    }
                    return pm.IsTodayDonated ? 1 : 0;
                }
                return 0;
            });
            _initConditions.Add(ConditionType.Friend_Count, (pid, conditionType, conditionTarget) =>
            {
                FriendList rs = _friendModule.QueryPlayerFriendList(pid);
                if (rs == null)
                    return 0;
                return rs.Friends.Count;
            });
            _initConditions.Add(ConditionType.Unit_Count, (pid, conditionType, conditionTarget) =>
            {
                var player = _playerModule.QueryPlayer(pid);
                return player.Units.Count;
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
                            AcceptQuest(player, data, dq);
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
                        int v = this.GetInitialValue(player.Id, dq.condition_type, dq.condition_target);
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

        private int GetInitialValue(string pid, int conditionType, int conditionTarget)
        {
            if (_initConditions.TryGetValue(conditionType, out var func))
            {
                return func(pid, conditionType, conditionTarget);
            }
            return 0;
        }

        public QuestInfo ToInfo(Quest quest)
        {
            QuestInfo questInfo = new QuestInfo();
            questInfo.id = quest.Id;
            questInfo.qid = quest.Tid;
            questInfo.progress = quest.Progress;
            questInfo.questType = 0;
            return questInfo;
        }

        public QuestInfo ToInfo(QuestDaily quest)
        {
            QuestInfo questInfo = new QuestInfo();
            questInfo.id = quest.Id;
            questInfo.qid = quest.Tid;
            questInfo.progress = quest.Progress;
            questInfo.questType = 0;
            return questInfo;
        }
        
        public Quest AcceptQuest(Player player, PlayerQuestData data, DQuest quest)
        {
            Quest q = new Quest();
            q.Tid = quest.id;
            q.PlayerId = player.Id;
            q.Id = Guid.NewGuid().ToString();
            if (quest.limit_level <= player.Level)
            {
                q.Status = QuestStatus.Doing;
                //任务需要一个进度初始化
                int v = this.GetInitialValue(player.Id, quest.condition_type, quest.condition_target);
                q.Progress = v;
            }
            else
            {
                q.Status = QuestStatus.Waiting;
            }
            data.Quests.Add(q);
            return q;
        }

        private void UpdateQuestProgress(String pid, int conditionType, int conditionTarget, UpdateMethod method, int newProgress)
        {
            var questPlayer = this.QueryPlayerQuestData(pid);
            bool needsave = false;
            foreach (Quest qData in questPlayer.Quests)
            {
                if (!DQuests.TryGetValue(qData.Tid, out var dq))
                {
                    continue;
                }
                //检查等待中任务的开启条件（等级）是否满足，满足则开启任务
                if (conditionType == ConditionType.LevelUp && qData.Status == QuestStatus.Waiting)
                {
                    if (dq.limit_level <= newProgress)
                    {
                        int v = this.GetInitialValue(pid, dq.condition_type, dq.condition_target);
                        qData.Progress = v;
                        qData.Status = QuestStatus.Doing;
                        needsave = true;

                        QuestAccepted qAccept = new QuestAccepted();
                        qAccept.questInfo = ToInfo(qData);
                        qAccept.success = true;
                        Server.SendByUserNameAsync(pid, qAccept);
                    }
                }
                if (qData.Status != QuestStatus.Doing)
                {
                    continue;//跳过不是进行中的任务
                }
                if (dq.condition_type == conditionType)
                {
                    if (dq.condition_target <= 0 || dq.condition_target == conditionTarget)
                    {
                        if (method == UpdateMethod.Increase)
                        {
                            qData.Progress = qData.Progress + newProgress;
                            needsave = true;
                            //通知客户端                
                            QuestProgressChanged qChange = new QuestProgressChanged();
                            qChange.questInfo = ToInfo(qData);
                            qChange.success = true;
                            Server.SendByUserNameAsync(pid, qChange);
                        }
                        else if (method == UpdateMethod.Override)
                        {
                            if (qData.Progress < newProgress)
                            {
                                qData.Progress = newProgress;
                                needsave = true;
                                //通知客户端                            
                                QuestProgressChanged qChange = new QuestProgressChanged();
                                qChange.questInfo = ToInfo(qData);
                                qChange.success = true;
                                Server.SendByUserNameAsync(pid, qChange);
                            }
                        }
                    }
                }
            }

            foreach (QuestDaily qData in questPlayer.QuestDailys)
            {
                if (!DQuestDailys.TryGetValue(qData.Tid, out var dq))
                {
                    continue;
                }
                if (qData.Status != QuestStatus.Doing)
                {
                    continue;//跳过不是进行中的任务
                }
                if (dq.condition_type == conditionType)
                {
                    if (dq.condition_target <= 0 || dq.condition_target == conditionTarget)
                    {
                        if (method == UpdateMethod.Increase)
                        {
                            qData.Progress = qData.Progress + newProgress;
                            needsave = true;
                            //通知客户端
                            QuestProgressChanged qChange = new QuestProgressChanged();
                            qChange.questInfo = ToInfo(qData);
                            qChange.success = true;

                            Server.SendByUserNameAsync(pid, qChange);
                        }
                        else if (method == UpdateMethod.Override)
                        {
                            if (qData.Progress < newProgress)
                            {
                                qData.Progress = newProgress;
                                needsave = true;
                                //通知客户端                            
                                QuestProgressChanged qChange = new QuestProgressChanged();
                                qChange.questInfo = ToInfo(qData);
                                qChange.success = true;

                                Server.SendByUserNameAsync(pid, qChange);
                            }
                        }
                    }
                }
            }
            //Spring.bean(MainlineService.class).TryUpdateMainline(pid, conditionType, conditionTarget, method, newProgress);
            //Spring.bean(QiRiWalfareService.class).TryUpdateMission(pid, conditionType, conditionTarget, method, newProgress);
            if (needsave)
            {
                _db.SaveChanges();
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
        //public const int BattleSkillUsedTimes = 15;//战斗中使用技能次数
        public const int UnitGradeUpTimes = 16;//兵种进阶次数

        public const int BuyItemInMall = 17;//在商城购买道具
        public const int BuyItemInBattleFieldShop = 18;//在战地商店购买道具
        public const int GRAB_FLAG_TIMES = 19;//夺旗战次数

        //public static final int LEVEL_UP_TO = 20;//玩家升到指定等级
        public const int USE_ITEM_TIMES = 21;//使用指定道具
        public const int TEAM_COUNT_CHANGE = 22;//上阵兵种数量改变
        public const int SEND_FRIEND_REQUEST_TIMES = 23;//发出申请好友次数
        public const int SEND_FRIEND_OIL_TIMES = 24;//赠送好友原油次数
        public const int UNIT_UNLOCK_TIMES = 25;//兵营解锁新兵种次数
        //public const int UNIT_NUMBER_RESET_TIMES = 26;//兵营休整次数
        //public const int SCIENCE_DEV_TIMES = 27;//科研中心研发科技次数
        //public const int RESET_WORKERS_TIMES = 28;//后勤基地分配完毕次数
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
