using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Unit
    {
        [Key]
        public string Id { get; set; }

        public string PlayerId { get; set; }
        public int Tid { get; set; }

        public int Level { get; set; }//等级
        public int Grade { get; set; }//阶
        public int Exp { get; set; }//经验
        public int Number { get; set; }//能量
        public bool IsResting { get; set; }//休整结束时间
        public DateTime RestEndTime { get; set; }//休整结束时间
    }    
}
