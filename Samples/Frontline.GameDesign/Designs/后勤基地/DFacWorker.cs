using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DFacWorker
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        public int star { get; set; }
        public int weight { get; set; }
        public int res_type { get; set; }
        public int res_cnt { get; set; }
        public int output_p { get; set; }
        public int itemes_p { get; set; }
    }
}
