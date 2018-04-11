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
    public class LegionListInfoCommand : GameCommand<PartyListRequest>
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

        //客户端请求任务信息
        public override int ExecuteCommand()
        {
            PartyListResponse response = new PartyListResponse();
            response.parties = new List<PartyInfo>();
            response.success = true;
            var ls = _db.Legions.Where(l => l.Id != string.Empty).OrderBy(l => l.Level).Take(10);
            foreach (var legion in ls)
            {
                response.parties.Add(_legionModule.ToLegionInfo(legion));
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
