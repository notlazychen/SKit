using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    /// <summary>
    /// 其实是玩家副本进度
    /// </summary>
    public class PlayerDungeon
    {
        [Key]
        public String Id { get; set; }//id
        [MaxLength(20)]
        public String PlayerId { get; set; }//所属的player
        public int Tid { get; set; }//副本id
        public int Type { get; set; }//类型
        public int Section { get; set; }//章
        public int Mission { get; set; }//节
        public int Star { get; set; }//副本战绩（0星表示刚刚打开）
        public int FightTimes { get; set; }//今日已经攻打的次数
        public DateTime LastRefreshTime { get; set; }//最近一次刷新的时间(每天都需要刷新一次副本可攻打次数)
        [MaxLength(32)]
        public int Next { get; set; }//连接的一个副本
        public int ResetNumb { get; set; }//今日已经重置次数
        public bool IsLast { get; set; }
        public bool IsOpen { get; set; }//是否已经打开

        public string PlayerSectionId { get; set; }
    }
}
