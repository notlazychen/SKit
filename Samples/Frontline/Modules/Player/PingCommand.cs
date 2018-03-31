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
    [GameCommandOptions(allowAnonymous:true, asynchronous:true)]
    public class PingCommand : GameCommand<Ping>
    {
        public override int ExecuteCommand()
        {
            Session.SendAsync(new Pong() { success = true, time = DateTime.Now.ToUnixTime() });
            return 0;
        }

        protected override void OnInit()
        {
        }
    }
}
