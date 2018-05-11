using Microsoft.Extensions.Logging;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKit.Common;

namespace ChatRoomSample.GameControllers
{
    public class ChatRoomController: GameModule
    {
        private GameServer _server;
        private ILogger<ChatRoomController> _logger;
        public ChatRoomController(GameServer server, ILogger<ChatRoomController> logger)
        {
            _server = server;
            _logger = logger;
        }

        [GameCommandOptions(allowAnonymous:true, asynchronous:true)]
        public int Call_Chat(string msg)
        {
            string str;
            //if (s.IsAuthorized)
            //{
            //    str = $"{s.UserName}: {msg}";
            //}
            //else
            //{
            //    str = $"{s.Id}: {msg}";
            //}
            str = msg;
            _server.BroadcastAllSessionAsync(str);
            _logger.LogDebug(str);
            return 0;
        }
    }
}
