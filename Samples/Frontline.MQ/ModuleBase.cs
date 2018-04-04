using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline.MQ
{
    public abstract class ModuleBase
    {
        protected virtual void OnMainloop(DateTime time)
        {
            
        }

        internal void DoLoop(DateTime time)
        {
            OnMainloop(time);
        }
    }
}
