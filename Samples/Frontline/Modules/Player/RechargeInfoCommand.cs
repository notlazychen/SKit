using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Newtonsoft.Json;
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
    public class RechargeInfoCommand : GameCommand<RechargeInfoRequest>
    {
        protected override void OnInit()
        {
        }

        public override int ExecuteCommand()
        {
            RechargeInfoResponse response = JsonConvert.DeserializeObject<RechargeInfoResponse>("{ \"rechargeDiamond\":0,\"rechargeInfos\":[],\"diamondConsume\":0,\"success\":true}");
            Session.SendAsync(response);
            return 0;
        }
    }
}
