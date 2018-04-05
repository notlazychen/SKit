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
    public class DiKangResetCommand : GameCommand<ResistResetRequest>
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
            ResistResetResponse response = new ResistResetResponse();
            var dikang = _dikangModule.QueryDiKang(pid);
            
            if (dikang.ResetNumb > 0)
            {
                dikang.Current = 0;
                dikang.ResetNumb-=1;

                _db.SaveChanges();

                response.current = 0;
                response.resetNumb = dikang.ResetNumb;
                response.success = true;
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
