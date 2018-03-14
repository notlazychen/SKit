using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class BulletinController : GameController
    {
        /// <summary>
        /// 公告详情
        /// </summary>
        /// <param name="c"></param>
        /// <param name="request"></param>
        public void Info(GameSession session, BulletinRequest request)
        {
            BulletinResponse response = new BulletinResponse();

            response.success = true;
            session.Server.SendBySessionIdAsync(session.Id, response);
        }
    }
}
