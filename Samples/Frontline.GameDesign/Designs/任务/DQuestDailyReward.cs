using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.GameDesign
{
    public class DQuestDailyReward
    {
        public int id { get; set; }
        public JsonObject<int[]> lv { get; set; }
        public int point { get; set; }
        public int item_id { get; set; }
    }
}
