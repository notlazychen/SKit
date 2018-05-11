using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class PlayerBaseInfo
    {
        [Key]
        public string Id { get; set; }
        [MaxLength(32)]
        public string NickName { get; set; }
        [MaxLength(32)]
        public string Icon { get; set; }
        public int VIP { get; set; }
        public int Level { get; set; }
        /// <summary>
        /// 历史最高战力
        /// </summary>
        public int MaxPower { get; set; }
        //[MaxLength(64)]
        //public string LegionId { get; set; }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
    }
}
