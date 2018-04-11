using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class LegionApplication
    {
        [Key]
        public string Id { get; set; }
        public string LegionId { get; set; }
        public string PlayerId { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
