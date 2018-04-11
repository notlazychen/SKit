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
    public class LegionRequestApplicationCommand : GameCommand<ApplyPartyRequest>
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
        
        public override int ExecuteCommand()
        {
            String id = Request.id;
            String name = Request.name;

            Legion legion = null;
            if (id != null)
            {
                legion = _legionModule.QueryLegion(id);
            }
            else if (name != null)
            {
                legion = _legionModule.QueryLegionByName(name);
            }
            if (legion == null)
            {
                return (int)GameErrorCode.军团不存在;
            }

            LegionMember pm = _legionModule.QueryLegionMember(Session.PlayerId);
            if (legion == null || legion.Id == string.Empty)
            {//判断军团是否存在
                return (int)GameErrorCode.军团不存在;
            }
            if (!string.IsNullOrEmpty(pm.LegionId))
            {//玩家已加入军团
                return (int)GameErrorCode.已加入军团不能重复申请加入;
            }
            Player player = _playerModule.QueryPlayer(Session.PlayerId);

            ////判断离团CD
            if (GameConfig.LegionJoinLevel > player.Level)
            {
                //满足军团等级要求
                return (int)GameErrorCode.等级不符合要求;
            }
            if (legion.LegionApplications.Count >= GameConfig.LegionApplicationCount)
            {
                //军团收到申请条数已满
                return (int)GameErrorCode.军团申请人数达到上限;
            }
            if(legion.LegionApplications.Any(ap=>ap.PlayerId == pm.PlayerId))
            {
                Session.SendAsync(new ApplyPartyResponse()
                {
                    id = id,
                    success = true
                });
                return 0;
            }

            var dl = _legionModule.DLegions[legion.Level];
            if (!legion.NeedCheck && dl.max > legion.Members.Count)
            {
                //Session.SendAsync(new ApplyPartyResponse()
                //{
                //    id = id,
                //    success = true
                //});
                //加入军团不需要审核
                _legionModule.JoinLegion(legion, pm);
                return 0;
            }
            var application = new LegionApplication();
            application.Id = Guid.NewGuid().ToString();
            application.PlayerId = pm.PlayerId;
            application.LegionId = legion.Id;
            application.RequestTime = DateTime.Now;
            legion.LegionApplications.Add(application);

            _db.SaveChanges();

            ApplyPartyResponse response = new ApplyPartyResponse()
            {
                id = id,
                success = true
            };
            Session.SendAsync(response);
            return 0;
        }
    }
}
