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
    public class RescueXXXCommand : GameCommand<GetRescueFriendsRequest>
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
            GetRescueFriendsResponse response = new GetRescueFriendsResponse();
            response.success = true;
            response.friends = new List<string>() { "1F1"};
            Session.SendAsync(response);
            return 0;
        }
    }
}
