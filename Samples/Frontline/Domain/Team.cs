using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain
{
    public class Team
    {
        [Key]
        public String Id { get; set; }
        public String PlayerId { get; set; } 
        public int Index { get; set; }
        public bool IsSelected { get; set; }
        public JsonObject<List<string>> Units { get; set; } = new JsonObject<List<string>>();
    }
}
