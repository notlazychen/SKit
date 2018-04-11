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
    public class DestoryLegionCommand : GameCommand<DestroyPartyRequest>
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


            if (legion.GvgState != LegionModule.GVG_STATE_NONE)
            {
                return (int)GameErrorCode.军团战期间不能退团;
            }

            if (pm.Career != LegionCareer.Commander)
            {
                return (int)GameErrorCode.军团操作权限不足;
            }

            _db.Legions.Remove(legion);
            foreach (var m in legion.Members)
            {
                m.Career = LegionCareer.Free;
                m.LegionId = string.Empty;
                m.LastLeftTime = DateTime.Now;
                m.Contribution = 0;
                m.IsTodayDonated = false;
                Server.SendByUserNameAsync(m.PlayerId, new LeavePartyResponse()
                {
                    success = true
                });
            }
            _db.SaveChanges();

            DestroyPartyResponse response = new DestroyPartyResponse();
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
