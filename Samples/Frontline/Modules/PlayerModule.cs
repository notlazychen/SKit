using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
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

namespace Frontline.Modules
{
    public class PlayerModule : GameModule
    {
        public const String DES_KEY = "";

        private DataContext _db;
        private GameConfig _config;
        private ILogger<PlayerModule> _logger;

        public Dictionary<int, DLevel> DLevels;
        public Dictionary<int, VIPPrivilege> VIP { get; private set; }

        Dictionary<string, Player> _players = new Dictionary<string, Player>();
        Dictionary<string, PlayerBaseInfo> _simplePlayers = new Dictionary<string, PlayerBaseInfo>();


        public PlayerModule(DataContext db, IOptions<GameConfig> config, ILogger<PlayerModule> logger)
        {
            _db = db;
            _config = config.Value;
            _logger = logger;
        }

        protected override void OnConfiguringModules()
        {
            var camp = Server.GetModule<CampModule>();
            camp.UnitLevelUp += (o, e) => UpdateMaxPower();
            camp.UnitGradeUp += (o, e) => UpdateMaxPower();
            camp.EquipLevelUp += (o, e) => UpdateMaxPower();
            camp.EquipGradeUp += (o, e) => UpdateMaxPower();
            camp.TeamSettingChanged += (o, e) => UpdateMaxPower();

            Server.GameTaskDone += Server_GameTaskDone;
            Server.SessionClosed += Server_SessionClosed;

            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DLevels = designDb.DLevels.AsNoTracking().ToDictionary(x => x.level, x => x);
                VIP = designDb.VIPPrivileges.AsNoTracking().ToDictionary(x => x.lv, x => x);
            });
        }
        
        private void Server_SessionClosed(object sender, SessionCloseEventArgs e)
        {
            if(e.Reason == ClientCloseReason.Displacement)
            {
                KickOutNotify notify = new KickOutNotify();
                notify.success = true;
                Server.SendToSession(e.GameSession, notify);
            }
        }

        private void Server_GameTaskDone(object sender, GameTaskDoneEventArgs e)
        {
            //错误码统一管理
            if(e.ResultCode > 0)
            {
                var code = (GameErrorCode)e.ResultCode;
                e.GameSession.SendAsync(new LevelupUnitResponse()
                {
                    success = false,
                    info = code.ToString()
                });
            }
        }

        private void UpdateMaxPower()
        {
            var player = this.QueryPlayer(Session.PlayerId);
            var team = player.Teams.FirstOrDefault(x=>x.IsSelected);
            if(team != null)
            {
                int power = player.Units.Where(x =>team.Units.Object.Contains(x.Id)).Sum(x => x.Power);
                if (player.MaxPower < power)
                {
                    player.MaxPower = power;
                    _db.SaveChanges();
                    //最大战力改变了
                    _logger.LogDebug($"玩家{player.Id}:{player.NickName}最大战力改变{player.MaxPower}");

                    MaxPowerChangeNotify notify = new MaxPowerChangeNotify()
                    {
                        Power = (int)player.MaxPower,
                        success = true,
                    };
                    Session.SendAsync(notify);
                }
            }
        }

        #region API
        public Player QueryPlayerByUsername(string username)
        {
            string playerId = _db.Players.Where(p=> p.UserCode == username).Select(p=>p.Id).FirstOrDefault();
            return this.QueryPlayer(playerId);
        }

        public Player QueryPlayerByNickname(string nickname)
        {
            string playerId = _db.Players.Where(p => p.NickName == nickname).Select(p => p.Id).FirstOrDefault();
            return this.QueryPlayer(playerId);
        }

        public Player QueryPlayer(string pid)
        {
            if (string.IsNullOrEmpty(pid))
                return null;
            if(!_players.TryGetValue(pid, out var player))
            {
                var queryPlayer = _db.Players
                     .Where(p => p.Id == pid);
                PlayerLoader loader = new PlayerLoader()
                {
                    Loader = queryPlayer
                };
                this.OnPlayerLoading(loader);
                player = loader.Loader.FirstOrDefault();
                if(player != null)
                {
                    OnPlayerLoaded(player);
                    //check new day refresh
                    _db.SaveChanges();

                    _players.Add(pid, player);
                }
            }

            //检查每日刷新
            if (player.LastDayRefreshTime.Date != DateTime.Today)
            {
                //需要刷新
                OnPlayerEverydayRefresh(player);

                player.LastDayRefreshTime = DateTime.Today;
                _db.SaveChanges();
            }
            return player;
        }

        public PlayerBaseInfo QueryPlayerBaseInfo(string pid)
        {
            if (_players.TryGetValue(pid, out var player))
            {
                return player;
            }
            if (!_simplePlayers.TryGetValue(pid, out var simple))
            {
                simple = _db.Players
                     .Where(p => p.Id == pid).AsNoTracking().FirstOrDefault();
                if(simple != null)
                {
                    _simplePlayers.Add(pid, simple);
                }
            }
            return simple;
        }

        public Player CreatePlayer(long ucenterId, string usercode, string ver, string ip)
        {
            //创建角色信息
            var player = new Player();
            player.Id = $"S{Server.Id}P{ucenterId}";
            int numb = _db.Players.Count();
            player.NickName = "No." + numb;
            player.UserCenterId = ucenterId;
            player.UserCode = usercode;
            player.Camp = 1;
            player.Icon = "touxiang6";
            player.Level = 1;
            player.Version = ver;
            player.VIP = 0;
            player.LastVipUpTime = player.LastLvUpTime = player.LastLoginTime = player.CreateTime = DateTime.Now;
            player.IsBind = false;
            player.IP = ip;
            player.Wallet = new Wallet()
            {
                PlayerId = player.Id,
            };
            //初始化资源
            player.Wallet.AddCurrency(CurrencyType.GOLD, 300000);
            player.Wallet.AddCurrency(CurrencyType.DIAMOND, 12888);
            player.Wallet.AddCurrency(CurrencyType.IRON, 10000);
            player.Wallet.AddCurrency(CurrencyType.SUPPLY, 10000);
            player.Wallet.AddCurrency(CurrencyType.OIL, 300);

            _db.Players.Add(player);
            this.OnPlayerCreating(player);
            player.MaxPower = player.Units.Sum(x => x.Power);
            _db.SaveChanges();

            _players.Add(player.Id, player);
            return player;
        }

        public int GetCurrencyValue(Player player, int type)
        {
            return player.Wallet.GetCurrency(type);
        }

        public bool IsCurrencyEnough(Player player, int type, int value)
        {
            if (value == 0)
            {
                return true;
            }
            var currency = player.Wallet.GetCurrency(type);
            return currency >= value;
        }

        public void AddCurrencies(Player player, int[] types, int[] values, string reason, double addex = 0)
        {
            ResourceAmountChangedNotify notify = new ResourceAmountChangedNotify();
            notify.success = true;
            notify.items = new List<ResourceInfo>();
            for (int i = 0; i < types.Length; i++)
            {
                int type = types[i];
                int value = (int)(values[i] * (1 + addex));
                if (value == 0)
                {
                    continue;
                }
                var currency = player.Wallet.AddCurrency(type, value);
                notify.items.Add(new ResourceInfo()
                {
                    type = 1,
                    id = type,
                    count = currency
                });
            }
            Server.SendByUserNameAsync(player.Id, notify);
        }

        /// <summary>
        /// 添加资源
        /// </summary>
        public int AddCurrency(Player player, int type, int value, string reason)
        {
            if (value == 0)
            {
                return player.Wallet.GetCurrency(type);
            }
            var currency = player.Wallet.AddCurrency(type, value);

            ResourceAmountChangedNotify notify = new ResourceAmountChangedNotify();
            notify.success = true;
            notify.items = new List<ResourceInfo>()
            {
                new ResourceInfo()
                {
                    type = 1,
                    id = type,
                    count = currency
                }
            };
            Server.SendByUserNameAsync(player.Id, notify);
            return currency;
        }
        /// <summary>
        /// 添加经验
        /// </summary>
        public void AddExp(Player player, int exp, string reason)
        {
            player.Exp += exp;
            if (player.Level == DLevels.Count)
            {
                var dl = DLevels[DLevels.Count];
                if (player.Exp >= dl.exp)
                {
                    player.Exp = dl.exp;
                }
            }
            else
            {
                int old = player.Level;
                while (true)
                {
                    if (player.Level == DLevels.Count)
                    {
                        break;
                    }
                    DLevel dl;
                    if (DLevels.TryGetValue(player.Level, out dl))
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

        #region 事件
        /// <summary>
        /// 创建角色的时候
        /// </summary>
        /// <remarks>与读取角色事件互斥</remarks>
        public event EventHandler<Player> PlayerCreating;
        internal void OnPlayerCreating(Player player)
        {
            PlayerCreating?.Invoke(this, player);
        }
        /// <summary>
        /// 读取角色的时候
        /// </summary>
        /// <remarks>与创建角色事件互斥</remarks>
        public event EventHandler<PlayerLoader> PlayerLoading;
        internal void OnPlayerLoading(PlayerLoader loader)
        {
            loader.Loader = loader.Loader.Include(p => p.Wallet);
            PlayerLoading?.Invoke(this, loader);            
        }

        public event EventHandler<Player> PlayerLoaded;
        internal void OnPlayerLoaded(Player player)
        {
            PlayerLoaded?.Invoke(this, player);
        }

        public event EventHandler<Player> PlayerEntered;
        internal void OnPlayerEntered(Player player)
        {
            PlayerEntered?.Invoke(this, player);
        }

        public event EventHandler<Player> PlayerEverydayRefresh;
        internal void OnPlayerEverydayRefresh(Player player)
        {
            PlayerEverydayRefresh?.Invoke(this, player);
        }
        #endregion
    }
}
