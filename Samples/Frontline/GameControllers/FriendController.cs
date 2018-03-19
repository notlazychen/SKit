using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class FriendController : GameController
    {
        public void Call_FriendList(FriendListRequest request)
        {
            FriendListResponse response = JsonConvert.DeserializeObject<FriendListResponse>("{\"oilTimes\":0,\"friends\":[],\"success\":true,\"maxOilTimes\":10}");
            CurrentSession.SendAsync(response);
        }

        public void Call_FriendAddList(FriendAddListRequest request)
        {
            FriendAddListResponse response = JsonConvert.DeserializeObject<FriendAddListResponse>("{\"pid\":\"10000f2\",\"ps\":[],\"success\":true}");
            CurrentSession.SendAsync(response);
        }
    }
}
