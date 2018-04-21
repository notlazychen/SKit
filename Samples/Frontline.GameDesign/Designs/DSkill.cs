using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DSkill
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int lv { get; set; }
        public int unit_grade { get; set; }
    }
}