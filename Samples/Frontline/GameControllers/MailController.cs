using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class MailController : GameController
    {
        public int Call_MailList(MailListRequest request)
        {
            String pid = CurrentSession.UserId;
            MailListResponse response = new MailListResponse();
            List<MailInfo> ms = new List<MailInfo>()
            {

            };
            response.id = pid;
            response.mails = ms;
            response.success = true;
            CurrentSession.SendAsync(response);
            return 0;
        }
    }
}
