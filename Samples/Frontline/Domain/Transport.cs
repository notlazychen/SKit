using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Transport
    {
        [Key]
        public String PlayerId { get; set; }

        public int UseNumb { get; set; }
        public DateTime LastRefreshTime { get; set; }//上次刷新时间（每日刷新）
        public int LastTodayDiff { get; set; }

        public DateTime MissionBeginTime;
        public String MissionToken;
        public int MissionDiff;
    }
}
