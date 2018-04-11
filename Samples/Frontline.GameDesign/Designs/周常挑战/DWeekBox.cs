using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DWeekBox
    {
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 挑战次数
        /// </summary>
        public int count { get; set; }
        public int item_id { get; set; }
    }
}
