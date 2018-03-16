using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class ScienceController : GameController
    {
        public void info(ScienceInfoRequest request)
        {
            ScienceInfoResponse response = new ScienceInfoResponse();
            response.success = true;
            response.totalDevs = 1;
            response.sciences = new List<ScienceInfo>();
            response.devs = new List<int>();
            CurrentSession.SendAsync(response);
        }

    }
}
