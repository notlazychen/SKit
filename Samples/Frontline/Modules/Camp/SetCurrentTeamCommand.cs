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
    /// 设置当前阵容
    /// </summary>
    public class SetCurrentTeamCommand : GameCommand<SetCurrentTeamRequest>
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
            SetCurrentTeamResponse response = new SetCurrentTeamResponse();
            response.success = true;
            response.type = Request.type;
            response.tid = Request.tid;

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            if (Request.type == 1)
            {
                foreach (var t in player.Teams)
                {
                    t.IsSelected = t.Id == Request.tid;
                }
            }
            else
            {
                foreach (var t in player.Formations)
                {
                    t.IsSelected = t.Id == Request.tid;
                }
            }
            _db.SaveChanges();
            Session.SendAsync(response);
            return 0;
        }
    }
}
