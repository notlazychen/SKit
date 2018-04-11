using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class MailAttachment
    {
        [Key]
        public string Id { get; set; }

        public string MailId { get; set; }
        public int Tid { get; set; }
        public int Type { get; set; }//资源0, 道具1
        public int Count { get; set; }
    }
}
