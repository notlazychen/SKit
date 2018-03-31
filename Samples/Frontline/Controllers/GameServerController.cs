using Frontline.Common;
using Frontline.Common.Reflection;
using Microsoft.AspNetCore.Mvc;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Frontline.Controllers
{
    public class GameServerController : Controller
    {
        GameServer _server;

        public GameServerController(GameServer server)
        {
            _server = server;
        }

        public IActionResult Index()
        {
            return View();
        }

        public int Connections()
        {
            return _server.ClientCount;
        }

        public IActionResult Handlers()
        {
            var hs = _server.CommandInfos.Select(x =>
            {
                string name = $"{x.Command.ToString()}";
                string type = x.CMD;
                int cmd = x.RequestType.GetCustomAttribute<ProtoAttribute>().value;

                return new GameHandlerInfo (){ CMD = cmd, Type = type, Name = name };
            }).OrderBy(x=>x.CMD).ToList();

            return View(hs);
        }

        public IActionResult DownloadProtocols()
        {
            string text = ProtocolMinFileHelper.ToFileContent();
            var data = Encoding.UTF8.GetBytes(text);
            return File(data, "text/html", "Protocols.cs");
        }
    }
}
