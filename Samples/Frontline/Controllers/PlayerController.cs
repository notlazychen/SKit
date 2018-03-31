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
using SKit;

namespace Frontline.Controllers
{
    public class PlayerController : Controller
    {
        GameServer _server;
        public PlayerController(GameServer server)
        {
            _server = server;
        }
        const string Reason = "管理后台";

        [HttpPost]
        [Route("/river/player/playerInfo.pf")]
        public string PlayerInfo(RiverModel model)
        {
            int type = int.Parse(model["type"]);
            String sid = model["sid"];
            String keyword = model["keyword"];

            Result result = new Result();
            Player p = null;
            _server.InvokeGameTask(() =>
            {
                var playerModule = _server.GetModule<PlayerModule>();
                switch (type)
                {
                    case 0:
                        p = playerModule.QueryPlayer(keyword);
                        break;
                    case 1:
                        p = playerModule.QueryPlayerByNickname(keyword);
                        break;
                    case 2:
                        p = playerModule.QueryPlayerByUsername(keyword);
                        break;
                }
            }, true);
            if (p != null)
            {
                PlayerInfo info = new PlayerInfo();
                info.id = p.Id;
                info.nickyName = p.NickName;
                info.usercode = p.UserCode;
                info.ucenterId = p.UserCenterId.ToString();
                info.vip = p.VIP.ToString();
                info.maxPower = p.MaxPower.ToString();
                info.camp = p.Camp.ToString();
                info.exp = p.Exp.ToString();
                info.icon = p.Icon;
                info.level = p.Level.ToString();
                result.success = true;
                result.info = JsonConvert.SerializeObject(info);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost]
        [Route("/river/player/support.pf")]
        public JsonResult SupportInfo(RiverModel model)
        {
            String pid = model["pid"];
            Result re = new Result();
            Wallet w = null;
            _server.InvokeGameTask(() =>
            {
                var playerModule = _server.GetModule<PlayerModule>();
                w = playerModule.QueryPlayer(pid)?.Wallet;
            }, true);
            if (w != null)
            {
                PlayerSupport su = new PlayerSupport();
                su.diamond = w.DIAMOND.ToString();
                su.gold = w.GOLD.ToString();
                su.wipes = w.WIPES.ToString();
                su.token = w.TOKEN.ToString();
                su.tec = w.TEC.ToString();
                su.supply = w.SUPPLY.ToString();
                su.smoke = w.SMOKE.ToString();
                su.oilBuyTimes = w.OilBuyTimes.ToString();
                su.oil = w.OIL.ToString();
                su.legionCoin = w.LEGIONCOIN.ToString();
                su.horn = w.HORN.ToString();
                su.goldBuyTimes = w.GoldBuyTimes.ToString();
                su.iron = w.IRON.ToString();
                re.success = true;
                re.info = JsonConvert.SerializeObject(su);
            }

            return Json(re);
        }

        [HttpPost]
        [Route("/river/player/addexp.pf")]
        public JsonResult AddExp(RiverModel model)
        {
            int exp = int.Parse(model["exp"]);
            String pid = model["pid"];

            Result re = new Result();
            if (pid != null)
            {
                Player p = null;
                _server.InvokeGameTask(() =>
                {
                    var playerModule = _server.GetModule<PlayerModule>();
                    p = playerModule.QueryPlayer(pid);
                    playerModule.AddExp(p, exp, Reason);
                }, true);

                if (p != null)
                {
                    PlayerInfo info = new PlayerInfo();
                    info.id = p.Id;
                    info.nickyName = p.NickName;
                    info.usercode = p.UserCode;
                    info.ucenterId = p.UserCenterId.ToString();
                    info.vip = p.VIP.ToString();
                    info.maxPower = p.MaxPower.ToString();
                    info.camp = p.Camp.ToString();
                    info.exp = p.Exp.ToString();
                    info.icon = p.Icon;
                    info.level = p.Level.ToString();
                    re.success = true;
                    re.info = JsonConvert.SerializeObject(info);
                }
            }
            return Json(re);
        }

        [HttpPost]
        [Route("/river/player/additem.pf")]
        public JsonResult AddItem(RiverModel model)
        {
            int itemId = int.Parse(model["itemId"]);
            String pid = model["pid"];
            int itemCount = int.Parse(model["itemCount"]);
            Result re = new Result();       
            if (pid != null)
            {
                PlayerItem item = null;
                _server.InvokeGameTask(() =>
                {
                    var playerModule = _server.GetModule<PlayerModule>();
                    var p = playerModule.QueryPlayer(pid);
                    var pkg = _server.GetModule<PkgModule>();
                    item = pkg.AddItem(p, itemId, itemCount, Reason);
                }, true);

                if (item != null)
                {
                    ItemInfo info = new ItemInfo();
                    info.tid = item.Tid;
                    info.lap = item.Count;
                    re.success = true;
                    re.info = JsonConvert.SerializeObject(info);
                }
            }
            return Json(re);
        }
    }

    public class ItemInfo
    {
        public int tid { get; set; }
        public int lap { get; set; }
    }

    public class PlayerSupport
    {
        public string supply { get; set; }
        public string iron { get; set; }
        public string diamond { get; set; }
        public string gold { get; set; }
        public string oil { get; set; }
        public string wipes { get; set; }

        public string horn { get; set; }
        public string token { get; set; }
        public string tec { get; set; }
        public string smoke { get; set; }
        public string legionCoin { get; set; }
        public string goldBuyTimes { get; set; }
        public string oilBuyTimes { get; set; }
    }

    public class PlayerInfo
    {
        public string nickyName { get; set; }
        public string camp { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string exp { get; set; }
        public string level { get; set; }
        public string ucenterId { get; set; }
        public string usercode { get; set; }
        public string vip { get; set; }
        public string maxPower { get; set; }
    }
}