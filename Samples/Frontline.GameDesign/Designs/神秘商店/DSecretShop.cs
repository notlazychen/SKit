using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DSecretShop
    {
        public int vip { get; set; }
        public int group { get; set; }
        public int w { get; set; }
        public int interval_second { get; set; }
        public int duration_second { get; set; }
    }
}