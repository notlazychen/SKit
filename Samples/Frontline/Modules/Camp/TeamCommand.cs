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
    /// 获取阵容信息
    /// </summary>
    public class TeamCommand : GameCommand<TeamRequest>
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
            TeamResponse response = new TeamResponse();
            response.success = true;
            response.pid = Session.PlayerId;
            response.teams5 = new List<TeamInfo>();
            response.teams10 = new List<TeamInfo>();

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            foreach (var team in player.Teams)
            {
                TeamInfo ti = new TeamInfo();
                ti.selected = team.IsSelected;
                ti.id = team.Id;
                ti.bps = team.Units.Object;
                response.teams5.Add(ti);
            }
            foreach (var f in player.Formations)
            {
                TeamInfo ti = new TeamInfo();
                ti.selected = f.IsSelected;
                ti.id = f.Id;
                ti.bps = f.Units.Object;
                response.teams10.Add(ti);
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
