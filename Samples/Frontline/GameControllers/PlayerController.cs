using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using protocol;
using SKit;
using SKit.Common;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class PlayerController : GameController
    {
        public const String DES_KEY = "";

        private DataContext _db;
        private GameConfig _config;
        private GameDesignContext _designDb;

        Dictionary<int, DLevel> _dlevels;

        public PlayerController(DataContext db, GameDesignContext design, IOptions<GameConfig> config)
        {
            _db = db;
            _config = config.Value;
            _designDb = design;
        }

        public PlayerController()
        {

        }

        protected override void OnReadGameDesignTables()
        {
            _dlevels = _designDb.DLevels.AsNoTracking().ToDictionary(x => x.level, x => x);
        }

        protected override void OnRegisterEvents()
        {
            base.OnRegisterEvents();
        }

        public override void OnLeave(ClientCloseReason reason)
        {
            base.OnLeave(reason);
            //_db.SaveChanges();
        }

        #region 事件
        /// <summary>
        /// 创建角色的时候
        /// </summary>
        /// <remarks>与读取角色事件互斥</remarks>
        internal event EventHandler<Player> PlayerCreating;
        private void RaisePlayerCreating(Player player)
        {
            PlayerCreating?.Invoke(this, player);
        }
        /// <summary>
        /// 读取角色的时候
        /// </summary>
        /// <remarks>与创建角色事件互斥</remarks>
        internal event EventHandler<PlayerLoader> PlayerLoading;
        private void RaisePlayerLoading(PlayerLoader loader)
        {
            PlayerLoading?.Invoke(this, loader);
        }

        internal event EventHandler<Player> PlayerEntered;
        private void RaisePlayerEntered(Player player)
        {
            PlayerEntered?.Invoke(this, player);
        }
        #endregion

        #region 辅助方法
        public int GetCurrencyValue(Player player, int type)
        {
            var currency = player.Currencies.FirstOrDefault(c => c.Type == type);
            if (currency == null)
            {
                return 0;
            }
            else
            {
                return currency.Value;
            }
        }
        public bool IsCurrencyEnough(Player player, int type, int value)
        {
            if (value == 0)
            {
                return true;
            }
            var currency = player.Currencies.FirstOrDefault(c => c.Type == type);
            if (currency == null)
            {
                return false;
            }
            else
            {
                return currency.Value >= value;
            }
        }
        /// <summary>
        /// 添加资源
        /// </summary>
        public void AddCurrency(Player player, int type, int value, string reason)
        {
            if (value == 0)
            {
                return;
            }
            var currency = player.Currencies.FirstOrDefault(c => c.Type == type);
            if (currency == null)
            {
                currency = new Currency()
                {
                    PlayerId = player.Id,
                    Type = type,
                    Value = value
                };
            }
            else
            {
                currency.Value += value;
            }

            ResourceAmountChangedNotify notify = new ResourceAmountChangedNotify();
            notify.success = true;
            notify.items = new List<ResourceInfo>()
            {
                new ResourceInfo()
                {
                    type = 1,
                    id = type,
                    count = currency.Value
                }
            };
            Server.SendByUserNameAsync(player.Id, notify);
        }
        /// <summary>
        /// 添加经验
        /// </summary>
        public void AddExp(Player player, int exp, string reason)
        {
            player.Exp += exp;
            if (player.Level == _dlevels.Count)
            {
                var dl = _dlevels[_dlevels.Count];
                if(player.Exp >= dl.exp)
                {
                    player.Exp = dl.exp;
                }
            }
            else
            {
                int old = player.Level;
                while (true)
                {
                    DLevel dl;
                    if (_dlevels.TryGetValue(player.Level, out dl))
                    {
                        if (player.Exp >= dl.exp)
                        {
                            player.Level += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (old != player.Level)
                {
                    //任务
                    //通知
                    LevelupNotify notify = new LevelupNotify();
                    notify.exp = player.Exp;
                    notify.level = player.Level;
                    notify.success = true;
                    Server.SendByUserNameAsync(player.Id, notify);//发送给当前player 
                }
            }            
        }
        #endregion


        /// <summary>
        /// 登录
        /// </summary>
        [AllowAnonymous]
        public void Call_Login(AuthRequest au)
        {
            if (CurrentSession.IsAuthorized)
            {
                return;
            }
            var json = JObject.Parse(DES.DesDecrypt(au.loginid, _config.DESKey));
            var ucenterId = json.Value<long>("id");
            var usercode = json.Value<String>("usercode");
            var bind = json.Value<bool>("bind");
            Player player = null;
            if (!_db.Players.Any(p => p.UserCenterId == ucenterId))
            {
                //创建角色信息
                player = new Player();
                player.Id = $"S{CurrentSession.Server.Id}P{ucenterId}";
                int numb = _db.Players.Count();
                player.NickName = "No." + numb;
                player.UserCenterId = ucenterId;
                player.UserCode = usercode;
                player.Camp = 1;
                player.Icon = "touxiang6";
                player.Level = 1;
                player.Version = au.ver;
                player.VIP = 0;
                player.LastVipUpTime = player.LastLvUpTime = player.LastLoginTime = player.CreateTime = DateTime.Now;
                player.IsBind = false;
                player.IP = (CurrentSession.Socket.RemoteEndPoint as IPEndPoint)?.Address.ToString();
                player.Currencies = new List<Currency>();
                //初始化资源
                for (int ct = 1; ct <= CurrencyType.MAX_TYPE; ct++)
                {
                    int v = 0;
                    switch (ct)
                    {
                        case CurrencyType.GOLD: v = 300000; break;
                        case CurrencyType.DIAMOND: v = 12888; break;
                        case CurrencyType.IRON: v = 10000; break;
                        case CurrencyType.SUPPLY: v = 10000; break;
                        case CurrencyType.OIL: v = 300; break;
                    }
                    player.Currencies.Add(new Currency()
                    {
                        PlayerId = player.Id,
                        Type = ct,
                        Value = v
                    });
                }
                _db.Players.Add(player);
                this.RaisePlayerCreating(player);
                _db.SaveChanges();
            }
            else
            {
                var queryPlayer = _db.Players
                    .Where(p => p.UserCode == usercode)
                    .Include(p => p.Currencies);
                PlayerLoader loader = new PlayerLoader()
                {
                    Loader = queryPlayer
                };
                this.RaisePlayerLoading(loader);
                player = loader.Loader.First();
            }
            CurrentSession.Login(player.Id);
            CurrentSession.SetBind(player);

            this.RaisePlayerEntered(player);
            AuthResponse response = new AuthResponse()
            {
                success = true,
                pid = player.Id
            };
            CurrentSession.SendAsync(response);
        }

        //[AllowAnonymous]
        //public void CreatePlayer(CreatePlayerRequest au)
        //{
        //    if (CurrentSession.IsAuthorized)
        //    {
        //        return;
        //    }
        //    CreatePlayerResponse response = new CreatePlayerResponse();
        //    CurrentSession.SendAsync(response);
        //}

        [AllowAnonymous]
        public void Call_Ping(Ping ping)
        {
            CurrentSession.SendAsync(new Pong() { success = true, time = ping.time });
        }

        public void Call_GetPlayerRes(ResRequest request)
        {
            var player = CurrentSession.GetBind<Player>();
            ResResponse response = new ResResponse();
            response.success = true;
            response.pid = player.Id;
            response.level = player.Level;
            response.nickyName = player.NickName;
            response.icon = player.Icon;
            response.exp = player.Exp;
            response.renameCnt = player.RenameNumb;
            response.vip = player.VIP;

            response.resInfos = new List<ResInfo>();
            //顺便检查下初始化资源
            bool checkout = false;
            for (int ct = 1; ct <= CurrencyType.MAX_TYPE; ct++)
            {
                var currency = player.Currencies.FirstOrDefault(c => c.Type == ct);
                if (currency == null)
                {
                    checkout = true;
                    currency = new Currency()
                    {
                        PlayerId = player.Id,
                        Type = ct,
                        Value = 0
                    };
                    player.Currencies.Add(currency);
                }
                response.resInfos.Add(new ResInfo()
                {
                    type = ct,
                    count = currency.Value
                });
            }
            if (checkout)
            {
                _db.SaveChanges();
            }
            //一些配置表的内容
            response.nextExp = _dlevels[player.Level].exp;
            response.resistMaxWave = 1;
            response.preExp = player.Level == 1 ? 0:  _dlevels[player.Level - 1].exp;
            CurrentSession.SendAsync(response);
        }

        public void Call_GetGuide(GuideInfoRequest request)
        {
            var player = CurrentSession.GetBind<Player>();
            GuideInfoResponse response = new GuideInfoResponse();
            response.success = true;
            response.id = player.Id;
            response.guide = 1000;// player.Guide;
            CurrentSession.SendAsync(response);
        }

        public void Call_SetGuide(GuideDoneRequest request)
        {
            var player = CurrentSession.GetBind<Player>();
            player.Guide = request.gindex;

            _db.SaveChanges();

            GuideDoneResponse response = new GuideDoneResponse();
            response.success = true;
            response.gindex = player.Guide;
            CurrentSession.SendAsync(response);
        }

        /// <summary>
        /// 充值详情
        /// </summary>
        /// <param name="session"></param>
        /// <param name="request"></param>
        public void Call_RechargeInfo(RechargeInfoRequest request)
        {
            RechargeInfoResponse response = JsonConvert.DeserializeObject<RechargeInfoResponse>("{ \"rechargeDiamond\":0,\"rechargeInfos\":[],\"diamondConsume\":0,\"success\":true}");
            CurrentSession.SendAsync(response);
        }
    }
}
