using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Common
{
    public class GameConfig
    {
        public string Secret { get; set; } = String.Empty;
        public string DESKey { get; set; } = String.Empty;
        public bool LogIO { get; set; } = true;


        public static readonly int TYPE_SCIENCE = 1;
        public static readonly int TYPE_UNIT_UNLOCK = 2;
        public static readonly int TYPE_INDUSTRY = 3;
        public static readonly int TYPE_UNITREST = 4;//兵种休整
    }
}
