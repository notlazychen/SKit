using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DArenaChallengeReward
    {
        [Key]
        public int id { get; set; }
        public int times { get; set; }
        public int random_id { get; set; }
    }
}
