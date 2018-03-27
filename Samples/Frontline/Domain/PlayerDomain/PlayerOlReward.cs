using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class PlayerOlReward
    {
        [Key]
        public String PlayerId { get; set; }
        public DateTime NextTime { get; set; }
        public int Round { get; set; }
        public int RewardIndex { get; set; }
    }
}
