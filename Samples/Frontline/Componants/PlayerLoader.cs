using Frontline.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline
{
    public class PlayerLoader
    {
        public IQueryable<Player> Loader { get; set; }
    }
}
