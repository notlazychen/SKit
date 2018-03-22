using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class GameSettings
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
