using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class MallShop
    {
        /// <summary>
        /// PlayerI+Type组合主键
        /// </summary>
        public String PlayerId { get; set; }//所属的玩家的id        
        public int Type { get; set; }

        public DateTime LastRefreshTime { get; set; }
        public List<MallShopCommodity> ShopCommodities { get; set; } = new List<MallShopCommodity>();
    }
}
