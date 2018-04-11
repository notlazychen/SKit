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
    public class ReadMailCommand : GameCommand<ReadMailRequest>
    {
        MailModule _mailModule;
        DataContext _db;

        protected override void OnInit()
        {
            _mailModule = Server.GetModule<MailModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }
        
        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            ReadMailResponse response = new ReadMailResponse();
            var mail = _mailModule.QueryMails(pid).FirstOrDefault(m => m.Id == Request.id);
            if (!mail.IsReaded)
            {
                mail.IsReaded = true;
                _db.SaveChanges();
            }
            response.readed = true;
            response.id = Request.id;
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
