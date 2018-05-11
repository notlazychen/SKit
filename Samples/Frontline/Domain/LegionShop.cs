using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class LegionShop
    {
        [Key]
        public String PlayerId { get; set; }//所属的玩家的id

        /// <summary>
        /// 已卖出数量
        /// </summary>
        [MaxLength(2048)]
        public string SoldItems { get; set; } = string.Empty;
        public Dictionary<int, int> SoldItemsDict = new Dictionary<int, int>();

        public DateTime LastRefreshTime { get; set; }

        public void ToSave()
        {
            this.SoldItems = string.Join(",", SoldItemsDict.Select(item => $"{item.Key}:{item.Value}"));
        }
    }
}
