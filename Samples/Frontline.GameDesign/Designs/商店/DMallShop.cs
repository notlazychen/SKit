using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Frontline.GameDesign
{
    public class DMallShop
    {
        [Key]
        public int type{get;set;}
        [MaxLength(64)]
        public String name{get;set;}
        public bool refresh{get;set;}
        public JsonObject<int[]> refresh_hour{get;set;}
        public JsonObject<int[]> res_type{get;set;}
        public int diamond{get;set; }
        public int size { get; set; }
    }
}