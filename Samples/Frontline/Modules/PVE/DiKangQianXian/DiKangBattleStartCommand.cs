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
    public class DiKangBattleStartCommand : GameCommand<StartResistRequest>
    {
        DiKangModule _dikangModule;
        DataContext _db;

        protected override void OnInit()
        {
            _dikangModule = Server.GetModule<DiKangModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            StartResistResponse response = new StartResistResponse();
            response.success = true;
            var dikang = _dikangModule.QueryDiKang(pid);
            var wave = _dikangModule.DDiKangQianXians[dikang.Current + 1];
            response.wave = _dikangModule.ToInfo(wave);
            Session.SendAsync(response);
            return 0;
        }
    }
}
