using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class PkgController :GameController
    {
        public void pkgInfo(GameSession session, PkgInfoRequest request)
        {
            PkgInfoResponse response = JsonConvert.DeserializeObject<PkgInfoResponse>("{\"pid\":\"10000f2\",\"items\":[{\"breakUnitId\":0,\"icon\":14001,\"breakRandomId\":60000001,\"synthCost\":0,\"type\":9,\"tid\":40000001,\"quality\":1,\"useable\":true,\"overlap\":1,\"breakCount\":0,\"synthCount\":0,\"price\":0,\"name\":\"新手礼包\",\"lap\":1,\"id\":\"10000f2i40000001\",\"synthId\":0,\"desc\":\"新手发展必不可少的礼包\"}],\"success\":true}");

            session.SendAsync(response);
        }
    }
}
