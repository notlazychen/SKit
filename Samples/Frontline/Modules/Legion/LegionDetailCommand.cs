using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
using Newtonsoft.Json.Linq;
using protocol;
using SKit;
using SKit.Common;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class LegionDetailCommand : GameCommand<PartyDetailRequest>
    {
        PlayerModule _playerModule;
        LegionModule _legionModule;
        DataContext _db;

        protected override void OnInit()
        {
            _legionModule = Server.GetModule<LegionModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        //客户端请求任务信息
        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var member = _legionModule.QueryLegionMember(player.Id);
            PartyDetailResponse response = new PartyDetailResponse();
            response.success = true;
            if (member.Career != LegionCareer.Free)
            {
                var legion = _legionModule.QueryLegion(member.LegionId);
                response.id = legion.Id;
                response.pi = _legionModule.ToLegionInfo(legion);
                response.members = new List<PartyMemberInfo>();
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
    }
}
