using Frontline.Data;
using Frontline.Domain;
using Microsoft.EntityFrameworkCore;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKit.Common.Utils;

namespace Frontline.Modules
{
    public class MailModule : GameModule
    {
        public const int TYPE_NORMAL = 0;
        public const int TYPE_SYSTEM = 1;
        public const int TYPE_FLAGWAR = 2;
        public const int TYPE_GVGOVER = 3;
        public const int TYPE_SHUTUP = 4;
        public const int TYPE_LADDER = 5;
        public const int TYPE_REBATE = 6;
        public const int TYPE_GIVING_SHARE = 7;//facebook礼包发送
        public const int TYPE_GIVING_ZAN = 8;//facebook礼包发送
        public const int TYPE_GIVING_INVITE = 9;//facebook礼包发送
        public const int ONE_GIFT = 10;//一元礼包
        public const int SKILL_REFACT = 11;//技能模块重构

        private DataContext _db;
        private PlayerModule _playerModule;

        public MailModule(DataContext db)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            _playerModule = Server.GetModule<PlayerModule>();
        }

        #region API
        public List<Mail> QueryMails(string pid)
        {
            return _db.Mails.Where(m => m.PlayerId == pid).Include(m => m.MailAttachments).ToList();
        }

        public void SendMail(Player recver, Player sender, string content, string title)
        {
            Mail mail = new Mail();
            mail.Content = content;
            mail.PlayerId = recver.Id;
            mail.Title = title;
            mail.Content = content;
            mail.IsRecved = true;
            mail.Time = DateTime.Now;
            mail.Icon = sender.Icon;
            mail.From = sender.NickName;

            this.SendMail(mail);
        }

        public void BroadcastAllSystemMail(
            int mailType,
            string title, string content,
            int[] itemids, int[] itemcnts,
            int[] resids, int[] rescnts)
        {
            var players = _playerModule.AllPlayers;
            foreach(var player in players)
            {
                Mail mail = new Mail();
                mail.Content = content;
                mail.PlayerId = player.Id;
                mail.Title = title;
                mail.Content = content;
                mail.IsRecved = false;
                mail.Time = DateTime.Now;
                mail.Type = mailType;
                mail.Id = Guid.NewGuid().ToString();

                for (int i = 0; i < itemids.Length; i++)
                {
                    MailAttachment att = new MailAttachment();
                    att.Count = itemcnts[i];
                    att.Type = 1;
                    att.Tid = itemids[i];
                    att.MailId = mail.Id;
                    mail.MailAttachments.Add(att);
                }

                for (int i = 0; i < resids.Length; i++)
                {
                    MailAttachment att = new MailAttachment();
                    att.Type = 0;
                    att.Count = rescnts[i];
                    att.Tid = resids[i];
                    att.MailId = mail.Id;
                    mail.MailAttachments.Add(att);
                }

                _db.Mails.Add(mail);
                NewMailNotify notify = new NewMailNotify();
                notify.mail = this.ToInfo(mail);
                notify.success = true;
                Server.SendByUserNameAsync(mail.PlayerId, notify);
            }
            _db.SaveChangesAsync();
        }

        public void SendSystemMail(Player recver,
            int mailType,
            string title, string content,
            int[] itemids, int[] itemcnts,
            int[] resids, int[] rescnts)
        {
            Mail mail = new Mail();
            mail.Content = content;
            mail.PlayerId = recver.Id;
            mail.Title = title;
            mail.Content = content;
            mail.IsRecved = false;
            mail.Time = DateTime.Now;
            mail.Type = mailType;
            mail.Id = Guid.NewGuid().ToString();

            for(int i = 0; i< itemids.Length; i++)
            {
                MailAttachment att = new MailAttachment();
                att.Count = itemcnts[i];
                att.Type = 1;
                att.Tid = itemids[i];
                att.MailId = mail.Id;
                mail.MailAttachments.Add(att);
            }

            for (int i = 0; i < resids.Length; i++)
            {
                MailAttachment att = new MailAttachment();
                att.Type = 0;
                att.Count = rescnts[i];
                att.Tid = resids[i];
                att.MailId = mail.Id;
                mail.MailAttachments.Add(att);
            }
            this.SendMail(mail);
        }

        private void SendMail(Mail m)
        {
            //todo: 检查邮件数量是否超出
            _db.Mails.Add(m);
            _db.SaveChangesAsync();

            NewMailNotify notify = new NewMailNotify();
            notify.mail = this.ToInfo(m);
            notify.success = true;
            Server.SendByUserNameAsync(m.PlayerId, notify);
        }

        public MailInfo ToInfo(Mail m)
        {
            MailInfo info = new MailInfo();
            info.id = m.Id;
            info.content = m.Content;
            info.from = m.From;
            info.readed = m.IsReaded;
            info.time = m.Time.ToUnixTime();
            info.title = m.Title;
            info.icon = m.Icon;
            info.partyName = m.LegionName;
            info.isPartyMail = m.IsLegionMail;
            info.mailType = m.Type;
            info.mailArgs = m.Args?.Object;
            info.collected = m.IsCollected;

            if (!m.IsRecved)
            {
                RewardInfo ri = new RewardInfo() { res = new List<ResInfo>(), items = new List<RewardItem>() };
                info.attachment = ri;
                foreach (var att in m.MailAttachments)
                {
                    if (att.Type == 0)
                    {
                        ri.res.Add(new ResInfo() { type = att.Tid, count = att.Count });
                    }
                    else
                    {
                        ri.items.Add(new RewardItem() { id = att.Tid, count = att.Count });
                    }
                }
            }
            return info;
        }
        #endregion
    }
}
