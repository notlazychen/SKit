using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class MallShopCommodity
    {
        [Key]
        public string Id { get; set; }
        public String PlayerId { get; set; }//所属的玩家的id

        public int Type { get; set; }

        public int CommodityId { get; set; }
        /// <summary>
        /// 已卖出
        /// </summary>
        public int SoldCount { get; set; }
    }
}
