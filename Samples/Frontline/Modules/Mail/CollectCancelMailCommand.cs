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
    public class CollectCancelMailCommand : GameCommand<CancelCollectRequest>
    {
        PlayerModule _playerModule;
        MailModule _mailModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _mailModule = Server.GetModule<MailModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            CancelCollectResponse response = new CancelCollectResponse();
            String mid = Request.id;
            response.mid = mid;
            var mails = _mailModule.QueryMails(pid);
            var mail = mails.FirstOrDefault(m => m.Id == mid);
            if (mail != null)
            {
                if(mail.IsCollected)
                {
                    mail.IsCollected = false;
                    _db.SaveChanges();
                }
            }
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
