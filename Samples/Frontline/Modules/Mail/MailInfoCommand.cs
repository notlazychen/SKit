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
    public class MailInfoCommand : GameCommand<MailListRequest>
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
            MailListResponse response = new MailListResponse();
            List<MailInfo> ms = new List<MailInfo>();
            var mails = _mailModule.QueryMails(pid);
            foreach(var m in mails)
            {
                ms.Add(_mailModule.ToInfo(m));
            }
            response.id = pid;
            response.mails = ms;
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
