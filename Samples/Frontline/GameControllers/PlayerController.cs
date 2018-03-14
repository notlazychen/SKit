using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using protocol;
using SKit;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class PlayerController : GameController
    {
        public static String DES_KEY = "421w6tW1ivg=";//des key

        public void Login(GameSession session, AuthRequest au)
        {
            if (session.IsAuthorized)
            {
                return;
            }
            var json = JObject.Parse(DES.DesDecrypt(au.loginid, DES_KEY));
            var ucenterId = json.Value<string>("id");
            var usercode = json.Value<String>("usercode");
            var bind = json.Value<bool>("bind");

            AuthResponse response = JsonConvert.DeserializeObject<AuthResponse>("{\"pid\":\"10000f2\",\"success\":true}");

            session.Login(response.pid);
            session.Server.SendBySessionIdAsync(session.Id, response);
        }

        public void Ping(GameSession session, Ping ping)
        {
            session.Server.SendBySessionIdAsync(session.Id, new Pong() { success = true, time = DateTime.Now.ToUnixTime() });
        }

        public void GetPlayerRes(GameSession session, ResRequest request)
        {
            ResResponse response = JsonConvert.DeserializeObject<ResResponse>("{\"level\":1,\"icon\":\"touxiang6\",\"resistMaxWave\":0,\"pid\":\"10000f2\",\"preExp\":0,\"sid\":10000,\"nickyName\":\"BotolfeOton\",\"resInfos\":[{\"count\":0,\"type\":3},{\"count\":0,\"type\":4},{\"count\":0,\"type\":2},{\"count\":200,\"type\":5},{\"count\":0,\"type\":1},{\"count\":1,\"type\":10},{\"count\":0,\"type\":6},{\"count\":0,\"type\":9},{\"count\":0,\"type\":8},{\"count\":0,\"type\":11},{\"count\":0,\"type\":12}],\"success\":true,\"renameCnt\":0,\"exp\":0,\"vip\":0,\"nextExp\":100}");

            session.Server.SendBySessionIdAsync(session.Id, response);
        }

        public void Guide(GameSession session, GuideInfoRequest request)
        {
            GuideInfoResponse response = JsonConvert.DeserializeObject<GuideInfoResponse>("{\"id\":\"10000f2\",\"guide\":0,\"success\":true}");
            session.Server.SendBySessionIdAsync(session.Id, response);
        }

        /// <summary>
        /// 充值详情
        /// </summary>
        /// <param name="session"></param>
        /// <param name="request"></param>
        public void RechargeInfo(GameSession session, RechargeInfoRequest request)
        {
            RechargeInfoResponse response = JsonConvert.DeserializeObject<RechargeInfoResponse>("{ \"rechargeDiamond\":0,\"rechargeInfos\":[],\"diamondConsume\":0,\"success\":true}");
            session.Server.SendBySessionIdAsync(session.Id, response);
        }
    }
}
