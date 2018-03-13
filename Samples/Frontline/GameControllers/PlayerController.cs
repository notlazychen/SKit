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
            AuthResponse response = new AuthResponse();
            if (session.IsAuthorized)
            {
                return;
            }
            var json = JObject.Parse(DES.DesDecrypt(au.loginid, DES_KEY));
            var ucenterId = json.Value<string>("id");
            var usercode = json.Value<String>("usercode");
            var bind = json.Value<bool>("bind");

            response.success = true;
            response.pid = "aa";
            session.Server.SendBySessionIdAsync(session.Id, response);
        }

        public void Ping(GameSession session, Ping ping)
        {
            session.Server.SendBySessionIdAsync(session.Id, new Pong() { success = true, time = ping.time });
        }

        public void GetPlayerRes(GameSession session, ResRequest request)
        {
            ResResponse response = new ResResponse();
            response.success = true;
            response.pid = "aa";
            response.preExp = 1;
            response.nickyName = "aa";
            response.sid = 1;
            response.resInfos = new List<ResInfo>();
            for(int i = 0; i< 12; i++)
            {
                response.resInfos.Add(new ResInfo() { type = i, count = 999 });
            }

            session.Server.SendBySessionIdAsync(session.Id, response);
        }

        public void Guide(GameSession session, GuideInfoRequest request)
        {
            GuideInfoResponse response = new GuideInfoResponse();
            response.id= "aa";
            response.guide = 666;
            response.success = true;
            session.Server.SendBySessionIdAsync(session.Id, response);
        }


        public void RechargeInfo(GameSession session, RechargeInfoRequest request)
        {
            RechargeInfoResponse response = new RechargeInfoResponse();
            
            response.success = true;
            response.rechargeInfos = new List<RechargeInfo>();
            response.rechargeDiamond = 666;

            session.Server.SendBySessionIdAsync(session.Id, response);
        }
    }
}
