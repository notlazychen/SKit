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
    public class SendMailCommand : GameCommand<SendMailRequest>
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
            SendMailResponse response = new SendMailResponse();

            String from = pid;
            Player p_from = _playerModule.QueryPlayer(pid);
            if (Request.recvName == null || Request.recvName == p_from.NickName)
            {
                return (int)GameErrorCode.查无此人;
            }
            int mail_title_count = GameConfig.mail_title_length;
            int mail_content_count = GameConfig.mail_content_length;
            Player p_recv = _playerModule.QueryPlayerByNickname(Request.recvName);
            if (Request.title == null || Request.title.Length > mail_title_count)
            {
                return (int)GameErrorCode.邮件标题超长;
            }
            else if (Request.content == null || Request.content.Length > mail_content_count)
            {
                return (int)GameErrorCode.邮件正文字数超长;
            }
            else if (p_recv == null)
            {
                return (int)GameErrorCode.查无此人;
            }

            _mailModule.SendMail(p_recv, p_from, Request.content, Request.title);

            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
