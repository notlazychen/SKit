using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class BulletinModule : GameModule
    {
        /// <summary>
        /// 公告详情
        /// </summary>
        /// <param name="c"></param>
        /// <param name="request"></param>
        public int Call_Info(BulletinRequest request)
        {
            BulletinResponse response = new BulletinResponse();


            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
