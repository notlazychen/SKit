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
    public class DiKangInfoCommand : GameCommand<ResistInfoRequest>
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
            ResistInfoResponse response = new ResistInfoResponse();
            var dikang = _dikangModule.QueryDiKang(pid);
            response.resetNumb = dikang.ResetNumb;
            response.best = dikang.Best;
            response.current = dikang.Current;
            response.success = true;
            response.recvBoxes = dikang.RecvBox.StringToMany(int.Parse);
            Session.SendAsync(response);
            return 0;
        }
    }
}
