using Frontline.Data;
using Frontline.GameDesign;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKit.Common.Utils;
using Microsoft.EntityFrameworkCore;
using Frontline.Common;
using Frontline.Domain;

namespace Frontline.Modules
{
    public class ArenaModule : GameModule
    {
        
        private DataContext _db;
        private ILogger _logger;

        public Dictionary<int, DArenaRankReward> DArenaRankRewards { get; private set; }
        public Dictionary<int, DArenaChallengeReward> DArenaChallengeRewards { get; private set; }

        private PlayerModule _playerModule;

        public ArenaModule(DataContext db, ILogger<BaseModule> logger)
        {
            _db = db;
            _logger = logger;
        }

        protected override void OnConfiguringModules()
        {
            _playerModule = this.Server.GetModule<PlayerModule>();
            _playerModule.PlayerLoading += Playercon_PlayerLoading;
            _playerModule.PlayerEverydayRefresh += Playercon_PlayerEverydayRefresh;

            var designModule = Server.GetModule<DesignDataModule>();
            designModule.Register(this, designDb =>
            {
                DArenaRankRewards = designDb.DArenaRankReward.AsNoTracking().ToDictionary(x => x.id, x => x);
                DArenaChallengeRewards = designDb.DArenaChallengeReward.AsNoTracking().ToDictionary(x => x.id, x => x);
            });
        }

        private void Playercon_PlayerEverydayRefresh(object sender, Player e)
        {
            if(e.ArenaCert != null)
            {
                e.ArenaCert.BoughtChallengeTimes = 0;
                e.ArenaCert.ChallengeTimes = 0;
                e.ArenaCert.ReceivedRewards = string.Empty;
                e.ArenaCert.Score = 0;
            }
        }

        private void Playercon_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader.Include(p=>p.ArenaCert).ThenInclude(c=>c.ArenaBattleHistories);
        }
        #region 事件
        #endregion

        #region 辅助函数
        private IEnumerable<GrabFlagAdversaryInfo> ToAdvInfo(IEnumerable<ArenaCert> ps)
        {
            foreach (var p in ps)
            {
                GrabFlagAdversaryInfo adv = new GrabFlagAdversaryInfo();

                var pc = Server.GetModule<PlayerModule>();
                var player = pc.QueryPlayerBaseInfo(p.PlayerId);
                adv.pid = p.PlayerId;
                adv.icon = player.Icon;
                adv.level = player.Level;
                adv.name = player.NickName;
                adv.power = player.MaxPower;
                adv.rank = p.CurrentRank;

                yield return adv;
            }
        }

        private void AddHistory(ArenaCert playercert, String otherId, String otherName, String otherIcon, int otherPower, int rankChange, String battleId, int result)
        {
            ArenaBattleHistory his = new ArenaBattleHistory();
            his.AdversaryPid = otherId;
            his.AdversaryName = otherName;
            his.PlayerId = playercert.PlayerId;
            his.Power = otherPower;
            his.RankChange = rankChange;
            his.Id = battleId;
            his.BattleResult = result;
            his.BattleTime = DateTime.Now.ToUnixTime();
            his.Icon = otherIcon;

            playercert.ArenaBattleHistories.Add(his);
            if (playercert.ArenaBattleHistories.Count > 20)
            {
                var first = playercert.ArenaBattleHistories.First();
                _db.ArenaBattleHistories.Remove(first);
            }
        }
        #endregion
        /// <summary>
        /// 请求竞技场次数奖励信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int Call_ScoreInfo(GrabFlagScoreRequest request)
        {
            GrabFlagScoreResponse response = new GrabFlagScoreResponse();
            response.success = true;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var war = player.ArenaCert;

            response.scoreInfos = new List<GrabFlagScoreInfo>();
            var recvRewards = new List<int>();

            if (war != null)
            {
                response.score = war.Score;
                response.nextTime = war.CD.ToUnixTime();
                recvRewards.AddRange(war.ReceivedRewards.Split(",").Where(x=>!string.IsNullOrEmpty(x)).Select(int.Parse));
            }
            foreach (var dr in DArenaChallengeRewards.Values)
            {
                GrabFlagScoreInfo srinfo = new GrabFlagScoreInfo();
                srinfo.id = dr.id;
                srinfo.score = dr.times;
                srinfo.received = war != null && recvRewards.Contains(dr.id);
                response.scoreInfos.Add(srinfo);
            }

            Session.SendAsync(response);
            return 0;
        }

        /// <summary>
        /// 领取次数奖励
        /// </summary>
        public int Call_RecvScoreReward(ReceiveGrabFlagScoreRewardRequest request)
        {

            DArenaChallengeReward reward = DArenaChallengeRewards[request.rewardId];
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var war = player.ArenaCert;

            if (war.Score < reward.times)
            {
                return (int)GameErrorCode.竞技场挑战次数不足;
            }
            List<int> receRewards = war.ReceivedRewards.Split(",").Where(x => !string.IsNullOrEmpty(x)).Select(int.Parse).ToList();
            if (receRewards.Contains(request.rewardId))
            {
                return (int)GameErrorCode.已领取此竞技场挑战奖励;
            }

            string reason = "领取竞技场次数奖励";
            //发放奖励
            var pkg = Server.GetModule<PkgModule>();
            RewardInfo rewardInfo = pkg.RandomReward(player, reward.random_id, 1, reason);
            receRewards.Add(reward.id);
            war.ReceivedRewards = string.Join(",", receRewards);
            _db.SaveChanges();

            ReceiveGrabFlagScoreRewardResponse resp = new ReceiveGrabFlagScoreRewardResponse();
            resp.rewardId = request.rewardId;
            resp.rewardInfo = rewardInfo;
            resp.success = true;
            Session.SendAsync(resp);
            return 0;
        }
        
        public int Call_GetEnemies(GrabFlagAdversariesRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var war = player.ArenaCert;

            GrabFlagAdversariesResponse response = new GrabFlagAdversariesResponse();
            response.success = true;
            if (war == null)
            {
                war = new ArenaCert();
                int rank = _db.ArenaCerts.Count() + 1;
                war.CurrentRank = rank;
                war.MaxRank = rank;
                war.ChallengeTimes = 0;
                //war.LastRefreshTime = DateTime.Now;
                war.PlayerId = player.Id;
                war.ReceivedRewards = "";
                player.ArenaCert = war;
                _db.SaveChanges();
            }
            response.adversaries = new List<GrabFlagAdversaryInfo>();
            response.remainChallengTimes = GameConfig.ArenaChallengeNumber - war.ChallengeTimes;

            response.score = war.Score;
            response.currentRank = war.CurrentRank;
            response.buyTimes = war.BoughtChallengeTimes;

            //随机出5个人来
            if (war.CurrentRank > 5 && war.CurrentRank < 9)
            {
                var avs = _db.ArenaCerts.Where(x => x.CurrentRank >= war.CurrentRank - 5 && x.CurrentRank < war.CurrentRank).Take(5).ToList();
                response.adversaries.AddRange(this.ToAdvInfo(avs));
            }
            else if (war.CurrentRank <= 5)
            {
                var avs = _db.ArenaCerts.Where(x => x.CurrentRank <= 6 && x.CurrentRank != war.CurrentRank).Take(5).ToList();
                response.adversaries.AddRange(this.ToAdvInfo(avs));
            }
            else
            {
                int step = (int)Math.Ceiling(war.CurrentRank / 3d);
                int from = war.CurrentRank - step;
                if (from > war.CurrentRank - 5)
                {
                    from = war.CurrentRank - 5;
                }
                int to = war.CurrentRank;
                int wei = (int)Math.Ceiling(step / 5d);
                int[] vsid = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    int a = @from + i * wei;
                    int b = @from + i * wei + wei;
                    int r = MathUtils.RandomNumber(a, b);
                    vsid[i] = r;
                }
                var vs = _db.ArenaCerts.Where(c => vsid.Contains(c.CurrentRank)).Take(5).ToList();
                response.adversaries.AddRange(this.ToAdvInfo(vs));
            }

            Session.SendAsync(response);
            return 0;
        }

        public int Call_ArenaBattleStart(GrabFlagBattleChallengeRequest request)
        {
            string enemyPid = request.adversaryPid;

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var war = player.ArenaCert;
            var warEnemy = _db.ArenaCerts.FirstOrDefault(x=>x.PlayerId == enemyPid);
            if (warEnemy == null)
                return 0;
            GrabFlagBattleChallengeResponse resp = new GrabFlagBattleChallengeResponse();
            int remainTimes = GameConfig.ArenaChallengeNumber - war.ChallengeTimes;
            if (remainTimes <= 0)
            {
                return (int)GameErrorCode.竞技场挑战次数不足;
            }
            war.IsBattling = true;
            war.BattleEnemyPid = warEnemy.PlayerId;
            String battleId = $"{war.PlayerId}AB{war.TotalBattleNumb}" ;
            resp.remainChallengeTimes = remainTimes - 1;

            var camp = Server.GetModule<CampModule>();
            resp.myUnits = camp.GetCurrentTeamUnitInfos(player);

            var playerModule = Server.GetModule<PlayerModule>();
            var pem = playerModule.QueryPlayer(enemyPid);
            resp.adversaryUnits = camp.GetCurrentTeamUnitInfos(pem);
            resp.enemyName = pem.NickName;
            resp.battleId = battleId;
            resp.success = true;

            Session.SendAsync(resp);
            return 0;
        }


        public int Call_ArenaBattleEnd(GrabFlagBattleChallengeOverRequest request)
        {
            GrabFlagBattleChallengeOverResponse resp = new GrabFlagBattleChallengeOverResponse();

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var war = player.ArenaCert;
            if (!war.IsBattling)
            {
                return (int)GameErrorCode.战斗令牌错误或战斗已经失效;
            }
            String battleId = $"{war.PlayerId}AB{war.TotalBattleNumb}";
            if (request.battleId != battleId)
            {
                return (int)GameErrorCode.战斗令牌错误或战斗已经失效;
            }
            int min = GameConfig.ArenaBattleCDMinutes;
            war.CD = DateTime.Now.AddMinutes(min);

            war.TotalBattleNumb++;
            war.ChallengeTimes++;
            war.Score++;

            resp.orginalRank = war.CurrentRank;
            resp.nextTime = war.CD.ToUnixTime();
            resp.success = true;
            resp.adversaryPid = war.BattleEnemyPid;

            var playerModule = Server.GetModule<PlayerModule>();
            int delta = 0;
            string reason = "竞技场挑战胜利";
            var enemy = playerModule.QueryPlayer(war.BattleEnemyPid);
            if (request.win)
            {
                RewardInfo reward = new RewardInfo() { items = new List<RewardItem>(), res = new List<ResInfo>()};
                playerModule.AddCurrency(player, CurrencyType.GOLD, GameConfig.ArenaBattleWinAddGold, reason);
                reward.res.Add(new ResInfo { type = CurrencyType.GOLD, count = GameConfig.ArenaBattleWinAddGold });

                var warEnemy = _db.ArenaCerts.First(x => x.PlayerId == war.BattleEnemyPid);
                int eRank = warEnemy.CurrentRank;
                if (war.CurrentRank > eRank)
                {
                    warEnemy.CurrentRank = war.CurrentRank;
                    war.CurrentRank = eRank;
                    delta = warEnemy.CurrentRank - eRank;
                    if (war.CurrentRank > war.MaxRank)
                    {
                        war.MaxRank = war.CurrentRank;
                    }
                }
                resp.win = true;
            }
            else
            {
                resp.win = false;
            }
            //给对方记录挨打日志
            AddHistory(enemy.ArenaCert, player.Id, player.NickName, player.Icon, player.MaxPower, delta, battleId, resp.win ? -1 : 1);

            _db.SaveChanges();
            resp.currentRank = war.CurrentRank;
            resp.remainChallengeTimes = GameConfig.ArenaChallengeNumber - war.ChallengeTimes;
            resp.score = war.Score;
            Session.SendAsync(resp);

            this.OnPlayerArenaBattleOver(war, request.win);
            return 0;
        }

        public int Call_ResetCD(FlagCDResetRequest request)
        {
            FlagCDResetResponse response = new FlagCDResetResponse();

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            //判断钻石够不够
            int diamond = GameConfig.ArenaBattleCDCostDiamond;
            var playercon = Server.GetModule<PlayerModule>();
            if (playercon.GetCurrencyValue(player, CurrencyType.DIAMOND) >= diamond)
            {
                playercon.AddCurrency(player, CurrencyType.DIAMOND, -diamond, "竞技场清楚挑战CD");                
                response.success = true;
                player.ArenaCert.CD = DateTime.Now;
                _db.SaveChanges();
            }

            Session.SendAsync(response);
            return 0;
        }

        public int Call_RankRewardInfo(GrabFlagRankRewardRequest request)
        {
            GrabFlagRankRewardResponse response = new GrabFlagRankRewardResponse();
            response.rewardInfos = new List<GrabFlagRankRewardInfo>();
            response.success = true;

            foreach (DArenaRankReward reward in DArenaRankRewards.Values)
            {
                GrabFlagRankRewardInfo info = new GrabFlagRankRewardInfo();

                info.rank_area = new List<int>();
                info.rank_area.AddRange(reward.rank_area.Object);
                info.items_id = new List<int>();
                info.items_id.AddRange(reward.items_id.Object);
                info.items_cnt = new List<int>();
                info.items_cnt.AddRange(reward.items_cnt.Object);
                response.rewardInfos.Add(info);
            }
            Session.SendAsync(response);

            return 0;
        }

        public int Call_RequestHistories(GrabFlagBattleHistoryRequest request)
        {
            GrabFlagBattleHistoryResponse resp = new GrabFlagBattleHistoryResponse();
            resp.histories = new List<GrabFlagBattleHistoryInfo>();
            var player = Server.GetModule<PlayerModule>().QueryPlayer(Session.PlayerId);
            foreach (ArenaBattleHistory history in player.ArenaCert.ArenaBattleHistories)
            {
                GrabFlagBattleHistoryInfo h = new GrabFlagBattleHistoryInfo();
                h.icon=history.Icon;
                h.adversaryName=history.AdversaryName;
                h.adversaryPid=history.AdversaryPid;
                h.battleResult=history.BattleResult;
                h.battleTime=history.BattleTime;
                h.power=history.Power;
                h.rankChange=history.RankChange;
                resp.histories.Add(h);
            }
            resp.success = true;
            Session.SendAsync(resp);
            return 0;
        }

        public event GamePlayerEventHandler<ArenaCert, bool> ArenaBattleOver;
        public void OnPlayerArenaBattleOver(ArenaCert player, bool win)
        {
            ArenaBattleOver?.Invoke(player, win);
        }
    }
}
