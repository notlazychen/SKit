using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class ArenaCert
    {
        [Key]
        public string Id { get; set; }
        public string PlayerId { get; set; }
        public int ChallengeTimes { get; set; }//已挑战次数
        public int BoughtChallengeTimes { get; set; }//已购买次数
        public int CurrentRank { get; set; }
        public int Score { get; set; }
        [MaxLength(64)]
        public string ReceivedRewards { get; set; } = string.Empty;
        public int MaxRank { get; set; }//最大排名
        public int NextRecvRank { get; set; }//下次可领取排名等级
        public DateTime CD { get; set; }
        public int TotalBattleNumb { get; set; }//竞技场战斗总数

        public bool IsRobot { get; set; }
        public String BattleEnemyPid;
        public bool IsBattling;

        public List<ArenaBattleHistory> ArenaBattleHistories { get; set; } = new List<ArenaBattleHistory>();
    }
}
