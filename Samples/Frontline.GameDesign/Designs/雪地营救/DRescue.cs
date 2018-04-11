using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DRescue
    {
        [Key]
        public int mid { get; set; }
        public int diffic { get; set; }
        public int supply { get; set; }
        public int iron { get; set; }
        public JsonObject<int[]> may_drop { get; set; }
    }
}