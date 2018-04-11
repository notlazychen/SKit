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
    public class TakeMailAttachmentCommand : GameCommand<TakeAttachmentRequest>
    {
        PlayerModule _playerModule;
        PkgModule _pkgModule;
        MailModule _mailModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _pkgModule = Server.GetModule<PkgModule>();
            _mailModule = Server.GetModule<MailModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            var player = _playerModule.QueryPlayer(pid);
            TakeAttachmentResponse response = new TakeAttachmentResponse();
            var mails = _mailModule.QueryMails(pid);
            RewardInfo rewardInfo = new RewardInfo() { res = new List<ResInfo>(), items = new List<RewardItem>() };
            bool needsave = false;
            if (Request.allTake)
            {
                List<String> ms = new List<string>();
                foreach(var mail in mails)
                {
                    if (!mail.IsRecved && mail.MailAttachments.Any())
                    {
                        needsave = true;
                        foreach (var att in mail.MailAttachments)
                        {
                            string reason = $"提取邮件附件{mail.Title}";
                            if (att.Type == 0)
                            {
                                _playerModule.AddCurrency(player, att.Tid, att.Count, reason);
                                rewardInfo.res.Add(new ResInfo { type = att.Tid, count = att.Count });
                            }
                            else
                            {
                                _pkgModule.AddItem(player, att.Tid, att.Count, reason);
                                rewardInfo.items.Add(new RewardItem { id = att.Tid, count = att.Count });
                            }
                        }
                    }
                }
                //mailService.takeAllAttachment(context.getSessionId(), rewardInfo);
                response.mails = ms;
            }
            else
            {
                var mail = mails.FirstOrDefault(m => m.Id == Request.id);
                if (!mail.IsRecved && mail.MailAttachments.Any())
                {
                    needsave = true;
                    foreach (var att in mail.MailAttachments)
                    {
                        string reason = $"提取邮件附件{mail.Title}";
                        if (att.Type == 0)
                        {
                            _playerModule.AddCurrency(player, att.Tid, att.Count, reason);
                            rewardInfo.res.Add(new ResInfo { type = att.Tid, count = att.Count });
                        }
                        else
                        {
                            _pkgModule.AddItem(player, att.Tid, att.Count, reason);
                            rewardInfo.items.Add(new RewardItem { id = att.Tid, count = att.Count });
                        }
                    }
                }
                response.mails = new List<string>() { Request.id };
            }
            if (needsave)
            {
                _db.SaveChanges();
            }
            rewardInfo.res = rewardInfo.res.GroupBy(r => r.type).Select(r => new ResInfo { type = r.Key, count = r.Sum(n=>n.count) }).ToList();
            rewardInfo.items = rewardInfo.items.GroupBy(r => r.id).Select(r => new RewardItem { id = r.Key, count = r.Sum(n => n.count) }).ToList();
            response.success = true;
            response.reward = rewardInfo;
            Session.SendAsync(response);

            return 0;
        }
    }
}
