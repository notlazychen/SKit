using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class WeekBattleData
    {
        [Key]
        public String PlayerId { get; set; }

        public int Score { get; set; }
        public int UseNumb { get; set; }//今日参与次数
        public int DaysInWeek { get; set; }//本周参与几天
        public DateTime LastRefreshDay { get; set; }//上次刷新时间（每日刷新）
        public DateTime LastRefreshWeek { get; set; }//上次刷新时间（每日刷新）
        [MaxLength(1024)]
        public string RecvBoxes { get; set; }

        public DateTime BattleBeginTime;
        public String BattleToken;
        public int BattleDiff;
        public int BattleDay;        
    }
}
