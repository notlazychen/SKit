using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Domain.Temporary
{
    public class Battle
    {
        public string Id { get; set; }
        public DateTime BeginTime { get; set; }        
        public bool IsEnd { get; set; }
        public Dungeon Dungeon { get; set; }
    }
}
