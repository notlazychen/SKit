using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class DiKang
    {
        [Key]
        public String PlayerId { get; set; }
        public int Best { get; set; }//最高波数
        public int Current { get; set; }
        public int ResetNumb { get; set; }//剩余重置次数
        public DateTime LastRefreshTime { get; set; }//上次刷新时间（每日刷新）
        public string RecvBox { get; set; }//已领取的宝箱
    }
}
