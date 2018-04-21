using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class SecretShop
    {
        [Key]
        public String PlayerId { get; set; }

        //public bool IsOpen { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }

        public List<SecretShopItem> SecretShopItems { get; set; } = new List<SecretShopItem>();
    }
}
