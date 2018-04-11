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
    public class LeaveLegionCommand : GameCommand<LeavePartyRequest>
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
            var pm = _legionModule.QueryLegionMember(Session.PlayerId);
            if (string.IsNullOrEmpty(pm.LegionId))
            {
                return (int)GameErrorCode.军团不存在;
            }
            var legion = _legionModule.QueryLegion(pm.LegionId);
            var player = _playerModule.QueryPlayerBaseInfo(pm.PlayerId);

            
            if (legion.GvgState != LegionModule.GVG_STATE_NONE) {
                return (int)GameErrorCode.军团战期间不能退团;
            }
            legion.Members.Remove(pm);
            
            if (!legion.Members.Any())//无人，则解散
            {
                _db.Remove(legion);
            }
            else if (pm.Career == LegionCareer.Commander)//如果是党首则移位
            {
                var nextLeader = legion.Members.OrderByDescending(m => m.Career).First();
                nextLeader.Career = LegionCareer.Commander;
            }

            pm.Career = LegionCareer.Free;
            pm.LegionId = string.Empty;
            pm.LastLeftTime = DateTime.Now;
            pm.Contribution = 0;
            pm.IsTodayDonated = false;
            _db.SaveChanges();

            Session.SendAsync(new LeavePartyResponse()
            {
                success = true
            });
            return 0;
        }
    }
}
