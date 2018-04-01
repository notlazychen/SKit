using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class PlayerQuestData
    {
        [Key]
        public string PlayerId { get; set; }

        public DateTime LastRefreshDay { get; set; }
        public int DailyPoint { get; set; }
        public string RecvedDailyPointReward { get; set; } = string.Empty;
        public string DailyPointReward { get; set; } = string.Empty;

        public List<Quest> Quests { get; set; } = new List<Quest>();
        public List<QuestDaily> QuestDailys { get; set; } = new List<QuestDaily>();
    }
}
