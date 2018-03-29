using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class VIPPrivilege
    {
        /// <summary>
        /// VIP等级
        /// </summary>
        [Key]
        [Ignore]
        public string id { get; set; }

        public int lv { get; set; }
        /// <summary>
        /// 可购买的工人数量
        /// </summary>
        public int work_total_hire_n { get; set; }
        /// <summary>
        /// 每天可刷新招募次数
        /// </summary>
        public int work_day_hire_n { get; set; }
        /// <summary>
        /// 可购买巨匠工人数量
        /// </summary>
        public int work_worker4_hire_n { get; set; }
        /// <summary>
        /// 刷新出巨匠工人的概率
        /// </summary>
        public float work_worker4_prob { get; set; }
        /// <summary>
        /// 额外奖励增加概率
        /// </summary>
        public float work_reward_ex_prob { get; set; }
    }
}
