using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class JJCController : GameController
    {
        public void Call_GrabFlagScoreInfo(GrabFlagScoreRequest request)
        {
            GrabFlagScoreResponse response = JsonConvert.DeserializeObject<GrabFlagScoreResponse>("{\"score\":0,\"scoreInfos\":[{\"score\":1,\"id\":72000002},{\"score\":3,\"id\":72000004},{\"score\":5,\"id\":72000006},{\"score\":8,\"id\":72000008},{\"score\":10,\"id\":72000010}],\"nextTime\":0,\"success\":true}");
            CurrentSession.SendAsync(response);
        }
    }
}
