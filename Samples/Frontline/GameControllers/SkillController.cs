using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class SkillController : GameController
    {
        public int Call_SkillInfo(SkillsInfoRequest request)
        {
            SkillsInfoResponse response = new SkillsInfoResponse();
            String pid = CurrentSession.UserId;
            List<SkillInfo> l = new List<SkillInfo>()
            {
            };
            response.skills = l;
            response.success = true;
            CurrentSession.SendAsync(response);

            return 0;
        }
    }
}
