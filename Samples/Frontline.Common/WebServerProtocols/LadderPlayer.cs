using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline.Common.WebServerProtocols
{
    public class LadderPlayer : IComparable<LadderPlayer>
    {
        public string pid { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int score { get; set; }
        public int mrank { get; set; }
        public int rank { get; set; }
        public int level { get; set; }
        public int vip { get; set; }
        public string serName { get; set; }
        public DateTime updateTime { get; set; }

        public int CompareTo(LadderPlayer other)
        {
            int ret = - score.CompareTo(other.score);
            if (ret == 0)
            {
                ret = updateTime.CompareTo(other.updateTime);
            }
            return ret;
        }
    }
}
