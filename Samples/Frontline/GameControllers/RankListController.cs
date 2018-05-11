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

namespace Frontline.Modules
{
    public class RankListController : GameModule
    {
        public const int POWER = 1;//战力榜
        public const int RESIST = 2;//铁壁战榜
        public const int FLAG = 3;//夺旗战榜
        public const int LEVEL = 4;//等级榜
        public const int LEGIONLEVEL = 5;//军团等级

        public const int MAX_RANKING_COUNT = 50;
        public const int MAX_RANKING_SITE_COUNT = 500;
                
        private DataContext _db;
        private ILogger _logger;

        private LegionModule _legionController;
        private PlayerModule _playerModule;

        public RankListController(DataContext db, ILogger<RankListController> logger)
        {
            _db = db;            
            _logger = logger;
        }

        protected override void OnConfiguringModules()
        {
            _playerModule = Server.GetModule<PlayerModule>();

            base.OnConfiguringModules();
            _legionController = Server.GetModule<LegionModule>();
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
                case LEVEL:
                    this.GetLevelRank();
                    break;
                case LEGIONLEVEL:
                    this.GetLegionLevelRank();
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
            var playercon = Server.GetModule<PlayerModule>();
            var player = _playerModule.QueryPlayer(Session.PlayerId);
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
                ri.score = w.CurrentRank;
                ri.power = p.MaxPower;
                ri.legionName = _legionController.QueryLegion(_legionController.QueryLegionMember(p.Id)?.LegionId)?.Name;
                resp.rankInfos.Add(ri);
            }
            Session.SendAsync(resp);
        }

        /// <summary>
        /// 铁壁战
        /// </summary>
        private void GetResistRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = RESIST;
            Session.SendAsync(resp);
        }

        private List<RankInfo> _powerRankInfo = null;
        private DateTime _powerRankOverdueTime;
        private void GetPowerRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = POWER;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            if (_powerRankInfo == null || _powerRankOverdueTime < DateTime.Now)
            {
                _powerRankInfo = _db.Players
                    .OrderByDescending(p => p.MaxPower)
                    .Take(MAX_RANKING_COUNT)
                    .Select(p => new RankInfo()
                    {
                        icon = p.Icon,
                        level = p.Level,
                        name = p.NickName,
                        pid = p.Id,
                        power = p.MaxPower,
                        score = p.MaxPower
                    }).ToList();
                for(int i = 1; i<= _powerRankInfo.Count; i++)
                {
                    var ri = _powerRankInfo[i - 1];
                    ri.legionName = _legionController.QueryLegion(_legionController.QueryLegionMember(ri.pid)?.LegionId)?.Name;
                    ri.rank = i;
                }
                _powerRankOverdueTime = DateTime.Now.AddMinutes(10);
            }
            resp.rankInfos = _powerRankInfo;
            var me = _powerRankInfo.FirstOrDefault(p => p.pid == player.Id);
            if(me != null)
            {
                resp.myRank = me.rank;
            }
            Session.SendAsync(resp);
        }

        private List<RankInfo> _rankInfoForLevel = null;
        private DateTime _rankOverdueTimeForLevel;
        /// <summary>
        /// 等级
        /// </summary>
        private void GetLevelRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = LEVEL;
            if (_rankInfoForLevel == null || _rankOverdueTimeForLevel < DateTime.Now)
            {
                _rankInfoForLevel = _playerModule.AllPlayers
                    .OrderByDescending(p => p.Level).ThenByDescending(p => p.Exp)
                    .Take(MAX_RANKING_COUNT)
                    .Select(p => new RankInfo()
                    {
                        icon = p.Icon,
                        level = p.Level,
                        name = p.NickName,
                        pid = p.Id,
                        power = p.MaxPower,
                        score = p.Level
                    }).ToList();
                _rankOverdueTimeForLevel = DateTime.Now.AddMinutes(10);
                for (int i = 1; i <= _rankInfoForLevel.Count; i++)
                {
                    var ri = _rankInfoForLevel[i - 1];
                    ri.legionName = _legionController.QueryLegion(_legionController.QueryLegionMember(ri.pid)?.LegionId)?.Name;
                    ri.rank = i;
                }
            }
            resp.rankInfos = _rankInfoForLevel;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var me = _rankInfoForLevel.FirstOrDefault(p => p.pid == player.Id);
            if (me != null)
            {
                resp.myRank = me.rank;
            }
            Session.SendAsync(resp);
        }


        private List<RankInfo> _rankInfoForLegion = null;
        private DateTime _rankOverdueTimeForLegion;
        /// <summary>
        /// 军团等级
        /// </summary>
        private void GetLegionLevelRank()
        {
            GetRankingListResponse resp = new GetRankingListResponse();
            resp.success = true;
            resp.type = LEGIONLEVEL;
            if (_rankInfoForLegion == null || _rankOverdueTimeForLegion < DateTime.Now)
            {
                _rankInfoForLegion = _legionController.AllLegions
                    .OrderByDescending(p => p.Level).ThenByDescending(p => p.Exp)
                    .Take(MAX_RANKING_COUNT)
                    .Select((p,i) => new RankInfo()
                    {
                        icon = p.Icon,
                        level = p.Level,
                        name = _playerModule.QueryPlayer(p.LeaderId).NickName,
                        legionName = p.Name,
                        pid = p.Id,
                        power = 0,
                        score = p.Level,
                        rank = i + 1
                    }).ToList();
                _rankOverdueTimeForLegion = DateTime.Now.AddMinutes(10);
            }
            resp.rankInfos = _rankInfoForLegion;
            var legionMember = _legionController.QueryLegionMember(Session.PlayerId);
            //var legion = _legionController.QueryLegion(legionMember.LegionId);
            var me = resp.rankInfos.FirstOrDefault(p => p.pid == legionMember.LegionId);
            if (me != null)
            {
                resp.myRank = me.rank;
            }
            Session.SendAsync(resp);
        }
        
        #endregion
    }
}
