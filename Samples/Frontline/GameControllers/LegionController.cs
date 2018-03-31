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
    public class LegionController : GameModule
    {
        
        private DataContext _db;
        private ILogger _logger;

        private PlayerModule _playerModule;

        public Dictionary<int, DLegion> DLegions { get; private set; }

        private Legion _freeLegion;//那些没有入团的成员信息统统丢入此内
        private Dictionary<string, Legion> _legions = new Dictionary<string, Legion>();
        
        public LegionController(DataContext db, ILogger<LegionController> logger)
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
                DLegions = designDb.DLegions.AsNoTracking().ToDictionary(x => x.level, x => x);
            });
        }

        protected override void OnConfigured()
        {
            _freeLegion = _db.Legions.FirstOrDefault(x => x.Id == string.Empty);
            if (_freeLegion == null)
            {
                _freeLegion = new Legion()
                {
                    Id = string.Empty,
                    Creater = "Game",
                    Name = string.Empty,
                    ShortName = string.Empty,
                };
                _db.Legions.Add(_freeLegion);
                _db.SaveChanges();
            }
        }

        #region 事件
        #endregion

        #region 辅助方法
        public  LegionMember QueryLegionMember(string playerId)
        {
            var member = _db.LegionMembers.FirstOrDefault(m => m.PlayerId == playerId);
            if(member == null)
            {
                member = new LegionMember()
                {
                    PlayerId = playerId,
                    Career = LegionCareer.Free,                    
                };
                _freeLegion.Members.Add(member);
                _db.SaveChanges();
            }
            return member;
        }

        public Legion QueryLegion(string legionId)
        {
            if (string.IsNullOrEmpty(legionId))
                return null;
            if(!_legions.TryGetValue(legionId, out var legion))
            {
                legion = _db.Legions.FirstOrDefault(l => l.Id == legionId);
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
        #endregion

        #region 客户端接口
        public int Call_LegionDetail(PartyDetailRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var member = QueryLegionMember(player.Id);
            PartyDetailResponse response = new PartyDetailResponse();
            response.success = true;
            if (member.Career != LegionCareer.Free)
            {
                var legion = this.QueryLegion(member.LegionId);
                response.id = legion.Id;
                response.pi = this.ToLegionInfo(legion);
                response.members = new List<PartyMemberInfo>();
                var playercon = Server.GetModule<PlayerModule>();
                foreach(var m in legion.Members)
                {
                    var p = playercon.QueryPlayerBaseInfo(m.PlayerId);
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
                    response.members.Add(mi);
                }
            }
            Session.SendAsync(response);

            return 0;
        }

        public int Call_CreateLegion(CreatePartyRequest request)
        {
            //验证名字是否和谐
            if (request.name == null || request.name.Length < 2 || request.name.Length > 30)
            {
                return (int)GameErrorCode.军团名不符合规则;
            }
            if (request.shortName == null || request.shortName.Length != 3)
            {
                return (int)GameErrorCode.军团名不符合规则;
            }
            //todo: 和谐字检查

            //检查退团CD
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            //检查等级是否满足
            if(player.Level < GameConfig.LegionCreateLevel)
            {
                return (int)GameErrorCode.等级不符合要求;
            }
            var playerCon = Server.GetModule<PlayerModule>();
            if(!playerCon.IsCurrencyEnough(player, CurrencyType.DIAMOND, GameConfig.LegionCreateCostDiamond))
            {
                return (int)GameErrorCode.资源不足;
            }
            var member = QueryLegionMember(player.Id);
            if (member.Career != LegionCareer.Free)
            {
                return 0;
            }
            if ((DateTime.Now - member.LastLeftTime).TotalDays < 1)
            {
                return (int)GameErrorCode.退团时间未满24小时不能加入和创建军团;
            }
            //检查名字和缩写名字是否重名
            bool dup = _db.Legions.Any(l => l.Name == request.name);
            if (dup)
            {
                return (int)GameErrorCode.军团重名;
            }
            dup = _db.Legions.Any(l => l.ShortName == request.shortName);
            if (dup)
            {
                return (int)GameErrorCode.军团缩写重名;
            }
            CreatePartyResponse response = new CreatePartyResponse();
            playerCon.AddCurrency(player, CurrencyType.DIAMOND, -GameConfig.LegionCreateCostDiamond, "创建军团");
            Legion legion = new Legion();

            legion.Id = Guid.NewGuid().ToString();
            legion.Icon=request.icon;
            legion.Name=request.name;
            legion.ShortName=request.shortName;
            legion.Note=request.note;
            legion.Creater=player.Id;
            legion.Level= 1;            
            legion.NeedCheck=request.check;//是否需要审核 true:需要 false:不需要
            legion.LeaderId = member.PlayerId;
            _db.Legions.Add(legion);

            _freeLegion.Members.Remove(member);
            legion.Members.Add(member);
            member.Career = LegionCareer.Commander;
            _db.SaveChanges();

            //todo: 创建成功移除申请列表

            response.success = true;
            response.party = ToLegionInfo(legion);

            Session.SendAsync(response);
            return 0;
        }

        //10个推荐军团
        public int Call_LegionList(PartyListRequest request)
        {
            PartyListResponse response = new PartyListResponse();
            response.parties = new List<PartyInfo>();
            response.success = true;
            var ls = _db.Legions.Where(l=>l.Id != string.Empty).OrderBy(l => l.Level).Take(10);
            foreach(var legion in ls)
            {
                response.parties.Add(ToLegionInfo(legion));
            }
            Session.SendAsync(response);
            return 0;
        }

        public int Call_LegionMemberList(MemberListRequest request)
        {
            MemberListResponse response = new MemberListResponse();
            response.id = request.id;
            response.members = new List<PartyMemberInfo>();
            response.success = true;
            var legion = this.QueryLegion(request.id);
            if(legion != null)
            {
                var playercon = Server.GetModule<PlayerModule>();
                foreach (var m in legion.Members)
                {
                    var p = playercon.QueryPlayerBaseInfo(m.PlayerId);
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
                    response.members.Add(mi);
                }
            }
            Session.SendAsync(response);
            return 0;
        }
        #endregion
    }
}

