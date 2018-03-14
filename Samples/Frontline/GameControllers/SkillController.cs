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
        public void SkillInfo(GameSession session, SkillsInfoRequest request)
        {
            SkillsInfoResponse response = new SkillsInfoResponse();
            String pid = session.UserId;
            List<SkillInfo> l = new List<SkillInfo>()
            {
            };
            response.skills = l;
            response.success = true;
            session.SendAsync(response);
        }
    }
}
