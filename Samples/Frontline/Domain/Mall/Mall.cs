using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Mall
    {
        [Key]
        public String PlayerId { get; set; }//所属的玩家的id

        public List<MallShop> Shops { get; set; } = new List<MallShop>();  
    }
}
