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
    public class LegionApplicationsListCommand : GameCommand<ApplyListRequest>
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
            var legion = _legionModule.QueryLegion(Request.id);
            if (legion != null)
            {
                ApplyListResponse response = new ApplyListResponse();
                List<ApplyInfo> ins = new List<ApplyInfo>();

                foreach(var app in legion.LegionApplications)
                {
                    var appinfo = new ApplyInfo();
                    appinfo.id = app.Id;
                    var p = _playerModule.QueryPlayerBaseInfo(app.PlayerId);
                    appinfo.nickname = p.NickName;
                    appinfo.online = Server.IsOnline(app.PlayerId);
                    appinfo.power = p.MaxPower;
                    appinfo.time = app.RequestTime.ToUnixTime();
                    appinfo.vip = p.VIP;
                    appinfo.level = p.Level;
                    appinfo.pid = p.Id;
                    ins.Add(appinfo);
                }
                response.applies = ins;
                response.id = Request.id;
                response.success = true;
                Session.SendAsync(response);
            }
            return 0;
        }
    }
}
