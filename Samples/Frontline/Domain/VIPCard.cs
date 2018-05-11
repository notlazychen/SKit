using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class VIPCard
    {
        [Key]
        public string Id { get; set; }
        public string PlayerId { get; set; }
        public int VIPLevel { get; set; }
        public DateTime BuyTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
