using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class QuestDaily
    {
        [Key]
        public string Id { get; set; }
        
        public string PlayerId { get; set; }

        public int Tid { get; set; }//策划id
        public int Progress { get; set; }
        public QuestStatus Status { get; set; }//状态0进行中，1已完成
    }
}
