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
    public class LegionModule : GameModule
    {
        public const int GVG_STATE_NONE = 0;//0未操作
        public const int GVG_STATE_ENROLL = 1;//1报名
        public const int GVG_STATE_ING = 2;//2已开始

        private DataContext _db;
        private ILogger _logger;

        private PlayerModule _playerModule;

        public Dictionary<int, DLegion> DLegions { get; private set; }
        public Dictionary<int, DLegionDonate> DLegionDonates { get; private set; }
        public Dictionary<int, Dictionary<int, DLegionScience>> DLegionSciences { get; private set; }//tid>lv>x


        public Legion FreeLegion { get; private set; }//那些没有入团的成员信息统统丢入此内
        private Dictionary<string, Legion> _legions = new Dictionary<string, Legion>();

        public LegionModule(DataContext db, ILogger<LegionModule> logger)
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
                DLegions = designDb.DLegion.AsNoTracking().ToDictionary(x => x.level, x => x);
                DLegionDonates = designDb.DLegionDonate.AsNoTracking().ToDictionary(x=>x.id, x=>x);
                DLegionSciences = designDb.DLegionScience.AsNoTracking().GroupBy(x=>x.id).ToDictionary(x=>x.Key, x=> x.ToDictionary(d=>d.lv, d=>d));
            });
        }

        protected override void OnConfigured()
        {
            FreeLegion = _db.Legions.FirstOrDefault(x => x.Id == string.Empty);
            if (FreeLegion == null)
            {
                FreeLegion = new Legion()
                {
                    Id = string.Empty,
                    Creater = "Game",
                    Name = string.Empty,
                    ShortName = string.Empty,
                };
                _db.Legions.Add(FreeLegion);
                _db.SaveChanges();
            }
        }

        #region 事件
        #endregion

        #region 辅助方法
        public LegionMember QueryLegionMember(string playerId)
        {
            var member = _db.LegionMembers
                .Include(m=>m.LegionSciences)
                .FirstOrDefault(m => m.PlayerId == playerId);
            if (member == null)
            {
                member = new LegionMember()
                {
                    PlayerId = playerId,
                    Career = LegionCareer.Free,
                };
                FreeLegion.Members.Add(member);
                _db.SaveChanges();
            }
            if(member.LastRefreshTime.Date != DateTime.Today)
            {
                member.IsTodayDonated = false;
                member.LastRefreshTime = DateTime.Now;
                _db.SaveChanges();
            }
            return member;
        }

        public Legion QueryLegion(string legionId)
        {
            if (string.IsNullOrEmpty(legionId))
                return null;
            if (!_legions.TryGetValue(legionId, out var legion))
            {
                legion = _db.Legions
                    .Include(l => l.LegionApplications)
                    .Include(l => l.LegionBBS)
                    .FirstOrDefault(l => l.Id == legionId);
                if (legion != null)
                {
                    _legions.Add(legion.Id, legion);
                }
            }
            return legion;
        }

        public Legion QueryLegionByName(string legionName)
        {
            if (string.IsNullOrEmpty(legionName))
                return null;
            var legion = _legions.Values.FirstOrDefault(l => l.Name.Contains(legionName));
            if (legion == null)
            {
                legion = _db.Legions
                    .Include(l => l.LegionApplications)
                    .Include(l => l.LegionBBS)
                    .FirstOrDefault(l => l.Name == legionName);
                if (legion != null)
                {
                    _legions.Add(legion.Id, legion);
                }
            }
            return legion;
        }

        public PartyInfo ToLegionInfo(Legion legion)
        {
            var dl = DLegions[legion.Level];
            return new PartyInfo()
            {
                id = legion.Id,
                check = legion.NeedCheck,
                count = legion.Members.Count,
                note = legion.Note,
                name = legion.Name,
                level = legion.Level,
                max = dl.max,
                exp = legion.Exp,
                icon = legion.Icon,
                next_exp = dl.exp,
                shortName = legion.ShortName,
                applied = false,
                leaderName = Server.GetModule<PlayerModule>().QueryPlayerBaseInfo(legion.LeaderId).NickName
            };
        }

        public void JoinLegion(Legion legion, LegionMember lm)
        {
            var app = legion.LegionApplications.FirstOrDefault(ap => ap.PlayerId == lm.PlayerId);
            if (app != null)
            {
                _db.LegionApplications.Remove(app);
            }
            lm.LegionId = legion.Id;
            lm.IsTodayDonated = false;
            lm.Career = LegionCareer.Member;
            legion.Members.Add(lm);

            _db.SaveChanges();

            //加入军团推送
            PartyDetailResponse detail = new PartyDetailResponse();
            detail.id = lm.PlayerId;
            detail.pi = this.ToLegionInfo(legion);
            List<PartyMemberInfo> pms = new List<PartyMemberInfo>();
            foreach (var m in legion.Members)
            {
                var p = _playerModule.QueryPlayerBaseInfo(m.PlayerId);
                var mi = new PartyMemberInfo()
                {
                    id = m.PlayerId,
                    camp = 0,
                    career = (int)m.Career,
                    contri = m.Contribution,
                    icon = p.Icon,
                    lastLoginTime = p.LastLoginTime.ToUnixTime(),
                    level = p.Level,
                    nickname = p.NickName,
                    power = p.MaxPower,
                    vip = p.VIP,
                };
                pms.Add(mi);
            }
            detail.members = pms;
            detail.success = true;
            Server.SendByUserNameAsync(lm.PlayerId, detail);
        }
        #endregion

    }
}

