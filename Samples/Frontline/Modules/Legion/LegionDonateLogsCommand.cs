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
    //军团捐献
    public class LegionDonateLogsCommand : GameCommand<PartyContriRequest>
    {
        PlayerModule _playerModule;
        PkgModule _pkgModule;
        LegionModule _legionModule;
        DataContext _db;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _legionModule = Server.GetModule<LegionModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            var pm = _legionModule.QueryLegionMember(Session.PlayerId);
            if (string.IsNullOrEmpty(pm.LegionId))
            {
                return (int)GameErrorCode.军团不存在;
            }
            var legion = _legionModule.QueryLegion(pm.LegionId);
            var player = _playerModule.QueryPlayer(pm.PlayerId);


            PartyContriResponse response = new PartyContriResponse();
            List<ContriInfo> cs = _legionModule.DLegionDonates.Values.Select(x=> new ContriInfo {
                id = x.id,
                contri = x.contri,
                cost = x.cost,
                type = x.type,
                exp_party = x.exp_party,
                name = x.name
            }).ToList();

            response.contries = cs;
            response.pid = Request.pid;
            response.success = true;
            response.cur = pm.IsTodayDonated ? 1 : 0;
            response.max = 1;
            response.logs = new List<ContriLogInfo>();

            Session.SendAsync(response);
            //todo: 任务和记录捐献日志
            return 0;
        }
    }
}
