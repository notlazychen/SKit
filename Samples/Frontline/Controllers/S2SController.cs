using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Frontline.Componants;
using Frontline.Domain;
using Frontline.Modules;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using protocol;
using SKit;
using SKit.Common.Utils;

namespace Frontline.Controllers
{
    public class S2SController : Controller
    {
        GameServer _server;
        public S2SController(GameServer server)
        {
            _server = server;
        }
        const string Reason = "服务器间同步";

        [HttpPost]
        [Route("/river/s2s/res.pf")]
        public string ResSet(RiverModel model)
        {
            String pid = model["pid"];
            String objStr = model["obj"];
            int op = int.Parse(model["op"]);
            var ress = JsonConvert.DeserializeObject<Dictionary<int, int>>(objStr);
            var ressResult = new Dictionary<int, int>();
            bool can = true;
            switch (op)
            {
                case 1:
                    _server.InvokeGameTask(() =>
                    {
                        var playerModule = _server.GetModule<PlayerModule>();
                        var player = playerModule.QueryPlayer(pid);
                        foreach (var en in ress)
                        {
                            ressResult[en.Key] = playerModule.AddCurrency(player, en.Key, en.Value, Reason);
                        }
                    });
                    break;
                case 2:
                    _server.InvokeGameTask(() =>
                    {
                        var playerModule = _server.GetModule<PlayerModule>();
                        var player = playerModule.QueryPlayer(pid);
                        foreach (var en in ress)
                        {
                            if (!playerModule.IsCurrencyEnough(player, en.Key, en.Value))
                            {
                                can = false;
                                break;
                            }
                        }
                        if (can)
                        {
                            foreach (var en in ress)
                            {
                                ressResult[en.Key] = playerModule.AddCurrency(player, en.Key, en.Value, Reason);
                            }
                        }
                    }, true);
                    break;
            }
            S2SSupportResult re = new S2SSupportResult();
            re.ok = can;
            re.ress = ressResult;

            return JsonConvert.SerializeObject(re);
        }

        [HttpPost]
        [Route("/river/s2s/item.pf")]
        public string ItemSet(RiverModel model)
        {
            String pid = model["pid"];
            String objStr = model["obj"];
            int op = int.Parse(model["op"]);

            var items = JsonConvert.DeserializeObject<Dictionary<int, int>>(objStr);
            //var itemsResult = new Dictionary<int, int>();
            bool can = true;
            switch (op)
            {
                case 1:
                    _server.InvokeGameTask(() =>
                    {
                        var playerModule = _server.GetModule<PlayerModule>();
                        var pkgModule = _server.GetModule<PkgModule>();
                        var player = playerModule.QueryPlayer(pid);
                        foreach (var en in items)
                        {
                            pkgModule.AddItem(player, en.Key, en.Value, Reason);
                        }
                    });
                    break;
                case 2:
                    break;
            }
            S2SItemResult re = new S2SItemResult();
            re.ok = can;
            re.items = items;

            return JsonConvert.SerializeObject(re);
        }

        [HttpPost]
        [Route("/river/s2s/mail.pf")]
        public string Mail(RiverModel model)
        {
            String receiver = model["receiver"];
            String sender = model["sender"];
            String title = model["title"];
            String content = model["content"];
            int type = int.Parse(model["type"]);
            bool all = model["all"] != null && model["all"].Length > 0;

            var items = JsonConvert.DeserializeObject<Dictionary<int, int>>(model["items"]);
            var ress = JsonConvert.DeserializeObject<Dictionary<int, int>>(model["ress"]);

            Result re = new Result();
            if (all)
            {
                _server.InvokeGameTask(() =>
                {
                    var playerModule = _server.GetModule<PlayerModule>();
                    var mailModule = _server.GetModule<MailModule>();
                    mailModule.BroadcastAllSystemMail(type, title, content,
                        items.Keys.ToArray(),
                        items.Values.ToArray(),
                        ress.Keys.ToArray(),
                        ress.Values.ToArray());
                });
            } else {
                _server.InvokeGameTask(() =>
                {
                    var playerModule = _server.GetModule<PlayerModule>();
                    var mailModule = _server.GetModule<MailModule>();
                    var player = playerModule.QueryPlayer(receiver);
                    mailModule.SendSystemMail(player, type, title, content,
                        items.Keys.ToArray(),
                        items.Values.ToArray(),
                        ress.Keys.ToArray(),
                        ress.Values.ToArray());
                });
            }

            return JsonConvert.SerializeObject(re);
        }
    }


    public class S2SSupportResult
    {
        public bool ok { get; set; }
        public Dictionary<int, int> ress { get; set; }//剩余的资源上数量
    }

    public class S2SItemResult
    {
        public bool ok { get; set; }
        public Dictionary<int, int> items { get; set; }//剩余的资源上数量
    }
}