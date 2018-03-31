using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Lottery
    {
        [Key]
        public String PlayerId { get; set; }
        public int GoldUsedNumb { get; set; }//金币抽总次数  
        public int Gold10UsedNumb { get; set; }//金币10抽总次数  
        public int GoldFreeNumb { get; set; }//免费金币抽次数 
        public DateTime GoldFreeNextTime { get; set; }//下次免费金币抽刷新时间
        public int GoldBaseNumb { get; set; }//剩余出金币抽保底奖励的次数
        public DateTime GoldLastTime { get; set; }//最后一次金币抽时间
        public int DmdUsedNumb { get; set; }//钻石总抽次数 
        public int Dmd10UsedNumb { get; set; }//钻石10总抽次数 
        public int DmdFreeNumb { get; set; }//免费金币抽次数 
        public DateTime DmdFreeNextTime { get; set; }//下次免费钻石抽时间
        public int DmdBaseNumb { get; set; }//剩余出钻石保底奖励的次数
        public DateTime DmdLastTime { get; set; }//最后一次钻石抽时间


        public DateTime LastRefreshDay { get; set; }//每日刷新时间
    }
}
