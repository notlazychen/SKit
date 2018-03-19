using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Equip
    {
        [Key]
        public String Id { get; set; }
        public String UnitId { get; set; }
        public String PlayerId { get; set; }
        public int Pos { get; set; }
        public int Tid { get; set; }
        public int Level { get; set; }
        public int Grade { get; set; }
    }
}
