using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DTransport
    {
        [Key]
        public int tid { get; set; }
        public int diff { get; set; }
        public int gold { get; set; }
        public int truck_id { get; set; }
        public JsonObject<int[]> robbers1 { get; set; }
        public JsonObject<int[]> robbers2 { get; set; }
        public JsonObject<int[]> robbers3 { get; set; }
    }
}