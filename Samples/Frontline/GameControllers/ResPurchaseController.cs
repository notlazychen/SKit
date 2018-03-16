using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class ResPurchaseController : GameController
    {
        /// <summary>
        /// 资源购买详情
        /// </summary>
        /// <param name="c"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public void ResPurchaseInfo(ResPurchaseInfoRequest request)
        {
            ResPurchaseInfoResponse response = JsonConvert.DeserializeObject<ResPurchaseInfoResponse>("{ \"success\":true,\"buyResInfos\":[{\"count\":800,\"times\":0,\"cost\":60,\"timesRemain\":1,\"type\":1},{\"count\":800,\"times\":0,\"cost\":60,\"timesRemain\":1,\"type\":2},{\"count\":10000,\"times\":0,\"cost\":50,\"timesRemain\":1,\"type\":4},{\"count\":200,\"times\":0,\"cost\":30,\"timesRemain\":1,\"type\":5}]}");            
            CurrentSession.SendAsync(response);
        }
    }
}
