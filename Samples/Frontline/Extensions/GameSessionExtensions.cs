using Frontline.Domain;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline
{
    public static class GameSessionExtensions
    {
        public static Player GetBindPlayer(this GameSession session)
        {
            return session.GetBind<Player>();
        }
    }
}