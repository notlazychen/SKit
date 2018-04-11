using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
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
    public class RescueInfoCommand : GameCommand<GetPatternInfoRequest>
    {
        RescueModule _rescueModule;
        DataContext _db;

        protected override void OnInit()
        {
            _rescueModule = Server.GetModule<RescueModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            GetPatternInfoResponse response = new GetPatternInfoResponse();
            response.success = true;
            String pid = Session.PlayerId;
            Rescue rescueInfo = _rescueModule.QueryRescue(pid);
            response.infos = new List<PVEPatternInfo>();
            PVEPatternInfo info = new PVEPatternInfo();
            info.type = 0;
            info.remainTimes = GameConfig.RescueMaxTimes - rescueInfo.UseNumb;
            info.totalTimes = GameConfig.RescueMaxTimes;
            response.infos.Add(info);
            Session.SendAsync(response);
            return 0;
        }
    }
}
