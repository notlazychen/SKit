using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    /// <summary>
    /// 其实是玩家副本进度
    /// </summary>
    public class Section
    {
        [Key]
        public String Id { get; set; }//id
        public int Index { get; set; }
        public String PlayerId { get; set; }//所属的player
        public int Type { get; set; }//类型

        public List<Dungeon> Dungeons { get; set; }
        public int RecvdStarReward { get; set; }
    }

    [Flags]
    public enum StarReward
    {
        First = 1 << 1,
        Second = 1 << 2,
        Third = 1 << 3,
        Fourth = 1 << 4,
        Fifth = 1 << 5,
    }
}
