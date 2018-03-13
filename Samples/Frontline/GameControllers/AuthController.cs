using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class AuthController : GameController
    {
        public void Login(GameSession session, AuthRequest au)
        {
            Console.WriteLine("{0}", au.loginid);
        }
    }
}
