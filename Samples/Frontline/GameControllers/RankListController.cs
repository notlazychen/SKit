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
using Microsoft.EntityFrameworkCore;

namespace Frontline.GameControllers
{
    public class RankListController : GameController
    {
        public const int POWER = 1;//战力榜
        public const int RESIST = 2;//铁壁战榜
        public const int FLAG = 3;//夺旗战榜
        public const int DEFENCE = 4;//pvp抢滩登陆榜
        public const int WEEKWORK = 5;//周常

        public const int MAX_RANKING_COUNT = 50;
        public const int MAX_RANKING_SITE_COUNT = 500;

        private GameDesignContext _designDb;
        private DataContext _db;
        private ILogger _logger;

        public RankListController(DataContext db, GameDesignContext design, ILogger<RankListController> logger)
        {
            _db = db;
            _designDb = design;
            _logger = logger;
        }

        #region 客户端接口
        public int Call_RankingListInfo(GetRankingListRequest request)
        {
            switch (request.type)
            {
                case FLAG:
                    this.GetArenaRank();
                    break;
                case RESIST:
                    this.GetResistRank();
                    break;
                case POWER:
                    this.GetPowerRank();
                    break;
                case DEFENCE:
                    this.GetQiangTanRank();
                    break;
                case WEEKWORK:
                    this.GetWeekWorkRank();
                    break;
            }
            return 0;
        }
        #endregion

        #region 辅助函数
        private void GetArenaRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = FLAG;
            var playercon = Server.GetController<PlayerController>();
            var player = CurrentSession.GetBindPlayer();
            var war = player.ArenaCert;
            if (war != null)
            {
                resp.myRank = war.CurrentRank;
            }

            resp.rankInfos = new List<RankInfo>();
            var acs = _db.ArenaCerts.Where(a => a.CurrentRank <= MAX_RANKING_COUNT).OrderBy(a=>a.CurrentRank).ToList();
            foreach (var w in acs)
            {
                RankInfo ri = new RankInfo();
                ri.rank = w.CurrentRank;
                ri.pid = w.PlayerId;
                var p = playercon.QueryPlayerBaseInfo(w.PlayerId);

                ri.icon = p.Icon;
                ri.name = p.NickName;
                ri.level = p.Level;
                ri.legionName = null;
                ri.score = w.CurrentRank;
                ri.power = p.MaxPower;
                ri.legionName = p.KorpsName;
                resp.rankInfos.Add(ri);
            }
            CurrentSession.SendAsync(resp);
        }

        /// <summary>
        /// 铁壁战
        /// </summary>
        private void GetResistRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = RESIST;
            CurrentSession.SendAsync(resp);
        }

        private List<RankInfo> _powerRankInfo = null;
        private DateTime _powerRankOverdueTime;
        private void GetPowerRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = POWER;
            var playercon = Server.GetController<PlayerController>();
            var player = CurrentSession.GetBindPlayer();
            if (_powerRankInfo == null || _powerRankOverdueTime < DateTime.Now)
            {
                _powerRankInfo = _db.Players
                    .OrderByDescending(p => p.MaxPower)
                    .Take(MAX_RANKING_COUNT)
                    .Select(p=> new RankInfo()
                    {
                        icon = p.Icon,
                        legionName = p.KorpsName,
                        level = p.Level,
                        name = p.NickName,
                        pid = p.Id,         
                        power = p.MaxPower,
                        score = p.MaxPower
                    }).ToList();
                for(int i = 1; i<= _powerRankInfo.Count; i++)
                {
                    _powerRankInfo[i - 1].rank = i;
                }
                _powerRankOverdueTime = DateTime.Now.AddMinutes(10);
            }
            resp.rankInfos = _powerRankInfo;
            var me = _powerRankInfo.FirstOrDefault(p => p.pid == player.Id);
            if(me != null)
            {
                resp.myRank = me.rank;
            }
            CurrentSession.SendAsync(resp);
        }
        /// <summary>
        /// 抢滩
        /// </summary>
        private void GetQiangTanRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = DEFENCE;
            CurrentSession.SendAsync(resp);
        }
        /// <summary>
        /// 周常
        /// </summary>
        private void GetWeekWorkRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = WEEKWORK;
            CurrentSession.SendAsync(resp);
        }
        
        #endregion
    }
}
