using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class MailController : GameModule
    {
        public int Call_MailList(MailListRequest request)
        {
            String pid = Session.PlayerId;
            MailListResponse response = new MailListResponse();
            List<MailInfo> ms = new List<MailInfo>()
            {

            };
            response.id = pid;
            response.mails = ms;
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
