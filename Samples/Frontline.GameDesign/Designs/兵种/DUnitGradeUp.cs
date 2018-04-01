using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DUnitGradeUp
    {
        public int star { get; set; }
        public int grade { get; set; }
        public int min_level { get; set; }
        public int max_level { get; set; }
        public int item_cnt { get; set; }
        public int gold { get; set; }
        public float atk { get; set; }
        public float defence { get; set; }
        public float hp { get; set; }
    }
}
