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
    /// 设置阵容
    /// </summary>
    public class TeamSettingCommand : GameCommand<TeamSettingRequest>
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
            TeamSettingResponse response = new TeamSettingResponse();
            response.success = true;
            response.type = Request.type;
            response.tid = Request.team.id;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            //判断是不是自己的兵
            foreach (var id in Request.team.bps)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    if (!player.Units.Any(x => x.Id == id))
                    {
                        return (int)GameErrorCode.阵容设置必须是自己的兵种;
                    }
                }
            }
            if (Request.type == 1)
            {
                //判断长度
                if (Request.team.bps.Count > 5)
                    return (int)GameErrorCode.阵容不能超过五个兵种;
                var team = player.Teams.First(t => t.Id == Request.team.id);
                team.Units = new JsonObject<List<string>>(Request.team.bps);
                _campModule.OnTeamSettingChanged(team);
            }
            else
            {
                if (Request.team.bps.Count > 10)
                    return (int)GameErrorCode.阵容不能超过十个兵种;

                var team = player.Formations.First(t => t.Id == Request.team.id);
                team.Units = new JsonObject<List<string>>(Request.team.bps);
            }
            _db.SaveChanges();

            Session.SendAsync(response);
            return 0;
        }
    }
}
