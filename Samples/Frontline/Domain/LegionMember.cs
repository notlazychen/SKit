using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class LegionMember
    {
        [Key]
        public string PlayerId { get; set; }
        
        public long Contribution { get; set; }//贡献
        public int ContriTimes { get; set; }//贡献次数
        public DateTime LastContriTime { get; set; }//上次交党费的时间 

        public LegionCareer Career { get; set; }

        public string LegionId { get; set; }
        public DateTime LastLeftTime { get; set; }//上次离开军团的时间
        public DateTime LastRefreshTime { get; set; }   
    }

    public enum LegionCareer
    {
        Free = 0,//没有军团
        Member,//普通成员
        Captain,
        ViceCommander,//副军团长
        Commander,//军团长
    }
}
