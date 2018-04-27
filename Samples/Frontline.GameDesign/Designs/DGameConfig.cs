using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DGameConfig
    {
        [Key]
        public string field_name { get; set; }
        [MaxLength(1024)]
        public string field_value { get; set; }
        [MaxLength(64)]
        public String desc { get; set; }// 道具描述
    }
}