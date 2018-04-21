using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Raffle
    {
        public String PlayerId { get; set; }
        public int Type { get; set; }

        public int UsedNumb { get; set; }//单抽总次数  
        public int UsedNumb10 { get; set; }//10抽总次数  
        public int FreeNumb { get; set; }//免费抽次数 
        public DateTime FreeNextTime { get; set; }//下次免费抽刷新时间
        public int BaseNumb { get; set; }//剩余抽保底奖励的次数
        public DateTime LastTime { get; set; }//最后一次抽时间
    }
}
