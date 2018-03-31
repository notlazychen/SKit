using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using protocol;
using SKit;
using SKit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class FriendController : GameModule
    {
        
        private DataContext _db;
        private ILogger _logger;

        private PlayerModule _playerModule;

        public FriendController(DataContext db, ILogger<FriendController> logger)
        {
            _db = db;
            _logger = logger;
        }

        protected override void OnConfiguringModules()
        {
            base.OnConfiguringModules();
            _playerModule = this.Server.GetModule<PlayerModule>();
            _playerModule.PlayerCreating += PlayerController_PlayerCreating;
            _playerModule.PlayerLoading += PlayerController_PlayerLoading;
            _playerModule.PlayerLoaded += PlayerController_PlayerLoaded;
            _playerModule.PlayerEverydayRefresh += PlayerController_PlayerEverydayRefresh;
        }
        #region 事件
        #endregion

        private void PlayerController_PlayerEverydayRefresh(object sender, Player e)
        {
            if (e.FriendList.LastRefreshTime.Date != DateTime.Today)
            {
                e.FriendList.LastRefreshTime = DateTime.Today;
                e.FriendList.RecvTimes = GameConfig.FriendMaxOilTimes;
                foreach (var f in e.FriendList.Friends)
                {
                    if (f.CanRecvOil)
                    {
                        f.CanRecvOil = false;
                    }
                    if (!f.CanSendOil)
                    {
                        f.CanSendOil = true;
                    }
                }
            }
        }

        private void PlayerController_PlayerLoaded(object sender, Player e)
        {
            if (e.FriendList == null)
            {
                e.FriendList = new FriendList()
                {
                    PlayerId = e.Id,
                    RecvTimes = GameConfig.FriendMaxOilTimes,
                    FriendApplications = new List<FriendApplication>(),
                    Friends = new List<Friendship>(),
                    LastRefreshTime = DateTime.Now
                };
            }
        }

        private void PlayerController_PlayerCreating(object sender, Domain.Player e)
        {
            e.FriendList = new FriendList()
            {
                PlayerId = e.Id,
                RecvTimes = GameConfig.FriendMaxOilTimes,
                FriendApplications = new List<FriendApplication>(),
                Friends = new List<Friendship>(),
                LastRefreshTime = DateTime.Now
            };
        }

        private void PlayerController_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader
                .Include(x => x.FriendList)
                .ThenInclude(fl => fl.Friends)
                .Include(x => x.FriendList)
                .ThenInclude(fl => fl.FriendApplications);
        }

        #region 辅助函数
        public Player FindPlayerFriendListOnly(string fid)
        {
            var playerModule = Server.GetModule<PlayerModule>();
            var other = playerModule.QueryPlayer(fid);
            if(other != null)
            {
                if (other.FriendList.LastRefreshTime.Date != DateTime.Today)
                {
                    other.FriendList.LastRefreshTime = DateTime.Today;
                    other.FriendList.RecvTimes = GameConfig.FriendMaxOilTimes;
                    foreach (var f in other.FriendList.Friends)
                    {
                        if (f.CanRecvOil)
                        {
                            f.CanRecvOil = false;
                        }
                        if (!f.CanSendOil)
                        {
                            f.CanSendOil = true;
                        }
                    }
                }
            }
            return other;
        }
        #endregion

        #region 客户端接口
        public int Call_FriendList(FriendListRequest request)
        {
            FriendListResponse response = new FriendListResponse();
            response.success = true;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            FriendList fl = player.FriendList;

            response.pid = player.Id;
            response.oilTimes = player.FriendList.RecvTimes;
            response.maxOilTimes = GameConfig.FriendMaxOilTimes;
            response.friends = new List<FriendInfo>();

            var friendsId = fl.Friends.Select(x => x.PlayerId).ToList();
            var friends = _db.Players
                .Where(p => friendsId.Contains(p.Id))
                .Select(p => new FriendInfo()
                {
                    id = p.Id,
                    icon = p.Icon,
                    level = p.Level,
                    nickyName = p.NickName,
                    power = (int)p.MaxPower,
                    vip = p.VIP,
                }).AsNoTracking().ToList();
            List<Friendship> notfriends = null;
            foreach (var f in fl.Friends)
            {
                FriendInfo fi = friends.FirstOrDefault(p => p.id == f.PlayerId);
                if (fi != null)
                {
                    fi.canGetOil = f.CanRecvOil;
                    fi.canGiveOil = f.CanSendOil;
                    response.friends.Add(fi);
                }
                else
                {
                    if (notfriends == null)
                    {
                        notfriends = new List<Friendship>();
                    }
                    notfriends.Add(f);
                }
            }
            if (notfriends != null)
            {
                _db.Friendships.RemoveRange(notfriends);
                _db.SaveChanges();
            }

            Session.SendAsync(response);
            return 0;
        }

        public int Call_FriendAddList(FriendAddListRequest request)
        {
            FriendAddListResponse response = new FriendAddListResponse();
            response.success = true;
            response.pid = request.pid;
            response.ps = new List<FriendInfo>();

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            FriendList fl = player.FriendList;

            var friendsId = fl.FriendApplications.Select(x => x.PlayerId).ToList();
            var friends = _db.Players
                .Where(p => friendsId.Contains(p.Id))
                .Select(p => new FriendInfo()
                {
                    id = p.Id,
                    icon = p.Icon,
                    level = p.Level,
                    nickyName = p.NickName,
                    power = (int)p.MaxPower,
                    vip = p.VIP,
                }).AsNoTracking().ToList();
            List<FriendApplication> notfriends = null;
            foreach (FriendApplication f in fl.FriendApplications)
            {
                FriendInfo fi = friends.FirstOrDefault(p => p.id == f.PlayerId);
                if (fi != null)
                {
                    response.ps.Add(fi);
                }
                else
                {
                    if (notfriends == null)
                    {
                        notfriends = new List<FriendApplication>();
                    }
                    notfriends.Add(f);
                }
            }
            if (notfriends != null)
            {
                _db.FriendApplications.RemoveRange(notfriends);
                _db.SaveChanges();
            }
            //FriendAddListResponse response = JsonConvert.DeserializeObject<FriendAddListResponse>("{\"pid\":\"10000f2\",\"ps\":[],\"success\":true}");
            Session.SendAsync(response);
            return 0;
        }

        public int Call_SendFriendApplication(AddFriendRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            string fid = request.id;
            if (string.IsNullOrEmpty(fid) || player.Id == fid)
            {

                return (int)GameErrorCode.不能添加自己为好友;
            }

            FriendList myFl = player.FriendList;
            if (myFl.Friends.Any(f => f.PlayerId == fid))
            {
                return (int)GameErrorCode.已经是好友;
            }
            if (myFl.Friends.Count == GameConfig.FriendMaxCount)
            {
                return (int)GameErrorCode.好友列表已满;
            }

            var other = this.FindPlayerFriendListOnly(fid);
            if (other == null)
            {
                return (int)GameErrorCode.查无此人;
            }

            FriendList hisfl = other.FriendList;//获取想要加的好友的朋友列表
            if (hisfl.FriendApplications.Any(f => f.PlayerId == player.Id))
            {
                return (int)GameErrorCode.已提交过好友申请;
            }
            if (hisfl.FriendApplications.Count >= GameConfig.FriendApplicationsMax)
            {
                return (int)GameErrorCode.对方好友申请已达上限;
            }
            hisfl.FriendApplications.Add(new FriendApplication() { CreateTime = DateTime.Now, FriendListId = hisfl.PlayerId, PlayerId = player.Id });
            _db.SaveChanges();

            AddFriendResponse response = new AddFriendResponse();
            response.success = true;
            response.id = request.id;
            Session.SendAsync(response);

            FriendAddRequestNotify notify = new FriendAddRequestNotify();
            notify.success = true;
            notify.friend = new FriendInfo()
            {
                id = other.Id,
                icon = other.Icon,
                level = other.Level,
                nickyName = other.NickName,
                power = other.MaxPower,
                vip = other.VIP
            };

            Server.SendByUserNameAsync(other.Id, notify);

            return 0;
        }

        public int Call_ProcessFriendApplication(ProcessFriendAddRequest request)
        {
            string fid = request.id;
            bool pass = request.pass;

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            FriendList fl = player.FriendList;

            var app = fl.FriendApplications.FirstOrDefault(x => x.PlayerId == fid);
            if (app != null)
            {
                _db.FriendApplications.Remove(app);
                _db.SaveChanges();
            }
            else
            {
                return 0;
            }

            if (pass)
            {
                if (fl.Friends.Count >= GameConfig.FriendMaxCount)
                {
                    return (int)GameErrorCode.好友列表已满;
                }
                var other = FindPlayerFriendListOnly(fid);
                if (other == null)
                {
                    return (int)GameErrorCode.查无此人;
                }
                if (other.FriendList.Friends.Count >= GameConfig.FriendMaxCount)
                {
                    return (int)GameErrorCode.对方好友列表已满;
                }
                fl.Friends.Add(new Friendship() { CanRecvOil = false, CanSendOil = true, FriendListId = fl.PlayerId, PlayerId = fid, FromTime = DateTime.Now });
                FriendList hisfl = other.FriendList;//获取想要加的好友的朋友列表
                var otherFs = new Friendship() { CanRecvOil = false, CanSendOil = true, FriendListId = hisfl.PlayerId, PlayerId = player.Id, FromTime = DateTime.Now };
                hisfl.Friends.Add(otherFs);
                _db.SaveChanges();

                NewFriendNotify notify = new NewFriendNotify();
                notify.friend = new FriendInfo()
                {
                    canGetOil = otherFs.CanRecvOil,
                    canGiveOil = otherFs.CanSendOil,
                    id = other.Id,
                    icon = other.Icon,
                    level = other.Level,
                    nickyName = other.NickName,
                    power = other.MaxPower,
                    vip = other.VIP
                };
                notify.success = true;
                Server.SendByUserNameAsync(fid, notify);
            }

            ProcessFriendAddResponse response = new ProcessFriendAddResponse();
            response.id = request.id;
            response.pass = request.pass;
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }

        public int Call_DelFriend(DelFriendRequest request)
        {
            string fid = request.id;

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            FriendList fl = player.FriendList;
            var friend = fl.Friends.FirstOrDefault(x => x.PlayerId == fid);
            if (friend == null)
            {
                return 0;
            }
            _db.Friendships.Remove(friend);

            var other = FindPlayerFriendListOnly(fid);
            var otherFs = other.FriendList.Friends.FirstOrDefault(x => x.PlayerId == player.Id);
            if (otherFs != null)
            {
                _db.Friendships.Remove(otherFs);
            }
            _db.SaveChanges();


            FriendDelNotify notify = new FriendDelNotify();
            notify.success = true;
            notify.pid = player.Id;
            Server.SendByUserNameAsync(request.id, notify);

            DelFriendResponse response = new DelFriendResponse();
            response.id = fid;
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }

        public int Call_RecommendFriendList(RecommendFriendListRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            RecommendFriendListResponse response = new RecommendFriendListResponse();
            response.pid = request.pid;
            response.success = true;
            var friendsId = player.FriendList.Friends.Select(x => x.PlayerId).ToList();
            friendsId.AddRange(player.FriendList.FriendApplications.Select(x => x.PlayerId));

            DateTime yestoday = DateTime.Today.AddDays(-3);
            var fsl = _db.Players
                .Where(p => p.LastLoginTime >= yestoday)
                .Where(p => p.Id != player.Id && !friendsId.Contains(p.Id))
                .Include(p=>p.FriendList).ThenInclude(p=>p.FriendApplications)
                .Where(p=>!p.FriendList.FriendApplications.Any(f=>f.PlayerId == player.Id))
                .Take(5)
                .Select(p => new FriendInfo()
                {
                    id = p.Id,
                    icon = p.Icon,
                    level = p.Level,
                    nickyName = p.NickName,
                    power = p.MaxPower,
                    vip = p.VIP,
                })
                .AsNoTracking().ToList();
            response.friends = fsl;
            Session.SendAsync(response);
            return 0;
        }

        public int Call_SendFriendOil(GiveOilToFriendRequest request)
        {
            bool all = request.all;
            GiveOilToFriendResponse response = new GiveOilToFriendResponse();
            response.id = request.id;
            response.all = request.all;
            response.success = true;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            bool change = false;
            if (all)
            {
                foreach (var fs in player.FriendList.Friends)
                {
                    if (fs.CanSendOil)
                    {
                        fs.CanSendOil = false;
                        var friend = _db.Friendships.FirstOrDefault(s => s.FriendListId == fs.PlayerId && s.PlayerId == player.Id);
                        if (friend != null)
                        {
                            friend.CanRecvOil = true;
                            GiveOilNotify notify = new GiveOilNotify();
                            notify.success = true;
                            notify.pid = player.Id;
                            Server.SendByUserNameAsync(friend.FriendListId, notify);
                        }
                        change = true;
                    }
                }
            }
            else
            {
                String fid = request.id;//朋友的id
                var fs = player.FriendList.Friends.FirstOrDefault(x => x.PlayerId == fid);
                if (fs != null && fs.CanSendOil)
                {
                    fs.CanSendOil = false;
                    var friend = _db.Friendships.FirstOrDefault(s => s.FriendListId == fs.PlayerId && s.PlayerId == player.Id);
                    if (friend != null)
                    {
                        friend.CanRecvOil = true;
                        GiveOilNotify notify = new GiveOilNotify();
                        notify.success = true;
                        notify.pid = player.Id;
                        Server.SendByUserNameAsync(friend.FriendListId, notify);
                    }
                    change = true;
                }
            }

            if (change)
            {
                _db.SaveChanges();
            }

            Session.SendAsync(response);
            return 0;
        }

        public int Call_RecvFriendOil(GetOilFromFriendRequest request)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            bool all = request.all;
            int oil = 0;
            if (all)
            {
                foreach (var f in player.FriendList.Friends)
                {
                    if (player.FriendList.RecvTimes <= 0)
                    {
                        break;
                    }
                    if (f.CanRecvOil)
                    {
                        f.CanRecvOil = false;
                        oil += GameConfig.FriendOil;
                        player.FriendList.RecvTimes--;
                    }
                }
            }
            else
            {
                if (player.FriendList.RecvTimes > 0)
                {
                    String fid = request.id;//好友id
                    var f = player.FriendList.Friends.FirstOrDefault(x => x.PlayerId == fid);
                    if (f.CanRecvOil)
                    {
                        f.CanRecvOil = false;
                        oil += GameConfig.FriendOil;
                        player.FriendList.RecvTimes--;
                    }
                }
                else
                {
                    return (int)GameErrorCode.收取好友原油次数不足;
                }
            }
            GetOilFromFriendResponse response = new GetOilFromFriendResponse();
            response.success = true;
            response.all = request.all;
            response.id = request.id;
            response.maxOilTimes = GameConfig.FriendMaxOilTimes;
            if (oil != 0)
            {
                var playerModule = Server.GetModule<PlayerModule>();
                playerModule.AddCurrency(player, CurrencyType.OIL, oil, "领取好友赠送原油");
                _db.SaveChanges();

                response.oilRemain = playerModule.GetCurrencyValue(player, CurrencyType.OIL);
                response.id = request.id;
                response.oilTimes = player.FriendList.RecvTimes;
            }
            Session.SendAsync(response);
            return 0;
        }

        public int Call_PassAllFriendApplications(ProcessAllFriendAddRequest request)
        {
            ProcessAllFriendAddResponse response = new ProcessAllFriendAddResponse();
            response.success = true;
            response.pid = request.pid;
            response.fs = new List<string>();

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            FriendList fl = player.FriendList;
            foreach (var app in player.FriendList.FriendApplications)
            {
                string fid = app.PlayerId;
                if (fl.Friends.Count >= GameConfig.FriendMaxCount)
                {
                    break;
                }
                var other = FindPlayerFriendListOnly(fid);
                if (other == null)
                {
                    continue;
                }
                if (other.FriendList.Friends.Count >= GameConfig.FriendMaxCount)
                {
                    continue;
                }
                fl.Friends.Add(new Friendship() { CanRecvOil = false, CanSendOil = true, FriendListId = fl.PlayerId, PlayerId = fid, FromTime = DateTime.Now });
                FriendList hisfl = other.FriendList;//获取想要加的好友的朋友列表
                var otherFs = new Friendship() { CanRecvOil = false, CanSendOil = true, FriendListId = hisfl.PlayerId, PlayerId = player.Id, FromTime = DateTime.Now };
                hisfl.Friends.Add(otherFs);
                _db.SaveChanges();

                NewFriendNotify notify = new NewFriendNotify();
                notify.friend = new FriendInfo()
                {
                    canGetOil = otherFs.CanRecvOil,
                    canGiveOil = otherFs.CanSendOil,
                    id = other.Id,
                    icon = other.Icon,
                    level = other.Level,
                    nickyName = other.NickName,
                    power = other.MaxPower,
                    vip = other.VIP
                };
                notify.success = true;
                Server.SendByUserNameAsync(fid, notify);
            }
            Session.SendAsync(response);
            return 0;
        }

        #endregion
    }
}
