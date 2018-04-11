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
    public class DeleteMailCommand : GameCommand<DeleteMailRequest>
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
            DeleteMailResponse response = new DeleteMailResponse();
            var mids = Request.mids;
            response.mids = mids;
            var mails = _mailModule.QueryMails(pid);
            bool needsave = false;
            foreach(var mail in mails)
            {
                if(mids.Contains(mail.Id))
                {
                    needsave = true;
                    _db.Mails.Remove(mail);
                }
            }
            if (needsave)
            {
                _db.SaveChanges();
            }
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
