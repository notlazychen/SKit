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
    public class TransportInfoCommand : GameCommand<GetTransportInfoRequest>
    {
        TransportModule _tansportModule;
        DataContext _db;

        protected override void OnInit()
        {
            _tansportModule = Server.GetModule<TransportModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            GetTransportInfoResponse response = new GetTransportInfoResponse();
            Transport transport = _tansportModule.QueryTransport(pid);
            response.success = true;

            response.remainTimes = GameConfig.TransportMaxTimes - transport.UseNumb;
            response.totalTimes = GameConfig.TransportMaxTimes;
            Session.SendAsync(response);
            return 0;
        }
    }
}
