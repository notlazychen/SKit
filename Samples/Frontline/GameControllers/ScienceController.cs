using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class ScienceController : GameModule
    {
        public int Call_Info(ScienceInfoRequest request)
        {
            ScienceInfoResponse response = new ScienceInfoResponse();
            response.success = true;
            response.totalDevs = 1;
            response.sciences = new List<ScienceInfo>();
            response.devs = new List<int>();
            Session.SendAsync(response);
            return 0;
        }

    }
}
