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
    /// <summary>
    /// 查看阵容详情
    /// </summary>
    public class ShowTeamInfoCommand : GameCommand<GetTeamInfoRequest>
    {
        PlayerModule _playerModule;
        CampModule _campModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _campModule = Server.GetModule<CampModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            GetTeamInfoResponse response = new GetTeamInfoResponse();
            response.success = true;
            response.pid = Request.pid;
            response.team = new List<TeamPlaceInfo>();
            string pid = Request.pid;
            var playerModule = Server.GetModule<PlayerModule>();
            var other = playerModule.QueryPlayer(pid);
            if (other == null)
            {
                return (int)GameErrorCode.查无此人;
            }
            var team = other.Teams.First(t => t.IsSelected);
            for (int i = 0; i < team.Units.Object.Count; i++)
            {
                TeamPlaceInfo info = new TeamPlaceInfo();
                info.place = i;
                string uid = team.Units.Object[i];
                if (!string.IsNullOrEmpty(uid))
                {
                    var unit = other.Units.FirstOrDefault(u => u.Id == uid);
                    if (unit != null)
                    {
                        info.unitInfo = _campModule.ToUnitInfo(unit);
                    }
                }
                response.team.Add(info);
            }

            Session.SendAsync(response);
            return 0;
        }
    }
}
