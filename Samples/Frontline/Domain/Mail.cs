using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Mail
    {

        public string Id { get; set; }

        public String PlayerId { get; set; }//所属的玩家的id

        public String From { get; set; }

        public String Icon { get; set; }//发件人头像

        public String Title { get; set; }

        public String Content { get; set; }

        public DateTime Time { get; set; }

        public bool IsReaded { get; set; }

        public bool IsCollected { get; set; }

        public String LegionName { get; set; }//军团名

        public bool IsLegionMail { get; set; }

        public int Type { get; set; }

        public JsonObject<List<String>> Args { get; set; } = new JsonObject<List<string>>();

        public bool IsRecved { get; set; }//是否领取附件
        public List<MailAttachment> MailAttachments { get; set; } = new List<MailAttachment>();
    }
}
