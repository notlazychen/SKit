using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline.Common.WebServerProtocols
{
    public class LadderBattle
    {
        public List<LadderBattlePlayer> infos { get; set; }
        public List<string> pids { get; set; }
        public string winner_pid { get; set; }
        public long battle_end_time { get; set; }
        public long battle_use_time { get; set; }
    }

    public class LadderBattlePlayer
    {
        public bool win { get; set; }
        public string pid { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int vip { get; set; }
        public int score { get; set; }
        public int mrank { get; set; }
        public string serName { get; set; }
        //public int score1;
        //public int mrank1;
        //public int score2;
        //public int mrank2;
        //public List<int> units;
    }
}
