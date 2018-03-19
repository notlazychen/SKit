using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class VIPController : GameController
    {
        public void Call_VIPInfoRequest(VIPInfoRequest request)
        {
            VIPInfoResponse response = JsonConvert.DeserializeObject<VIPInfoResponse>("{ \"vipLevel\":0,\"nextLvExp\":1,\"receivedGifts\":[],\"success\":true,\"vipExp\":0}");
            CurrentSession.SendAsync(response);
        }
    }
}
