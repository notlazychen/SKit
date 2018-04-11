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
    public class CollectMailCommand : GameCommand<CollectMailRequest>
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
            CollectMailResponse response = new CollectMailResponse();
            String mid = Request.id;
            response.mid = mid;
            var mails = _mailModule.QueryMails(pid);
            var mail = mails.FirstOrDefault(m => m.Id == mid);
            if (mail != null)
            {
                int mail_collect_max = GameConfig.mail_collect_max;
                int mail_collect_count = mails.Count(m => m.IsCollected);
                if (mail_collect_count >= mail_collect_max)
                {
                    //收藏邮件的数量上限100
                    return (int)GameErrorCode.邮件收藏数量达到上限;
                }
                mail.IsCollected = true;
                _db.SaveChanges();
            }
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
