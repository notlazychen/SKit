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
    }
}
