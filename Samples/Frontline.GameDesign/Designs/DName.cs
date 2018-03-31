using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DName
    {
        [Key]
        public string Name { get; set; }
        public bool IsUsed { get; set; }
    }

    public class NameTable
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
