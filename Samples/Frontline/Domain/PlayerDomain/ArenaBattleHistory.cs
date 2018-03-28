using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class ArenaBattleHistory
    {
        [Key]
        public String Id { get; set; }

        public string ArenaCertId { get; set; }
        public string PlayerId { get; set; }
        //对手战力
        public int Power { get; set; }
        //战斗结果-1败，1胜，0平
        public int BattleResult { get; set; }
        //对手pid
        public String AdversaryPid { get; set; }
        //对手名字
        public String AdversaryName { get; set; }
        public String Icon { get; set; }
        //战斗时间
        public long BattleTime { get; set; }
        //排名变化，正数上升，负数下降，0不变
        public int RankChange { get; set; }
    }
}
