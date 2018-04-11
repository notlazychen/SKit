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
    public class FriendModule : GameModule
    {
        
        private DataContext _db;
        private ILogger _logger;

        private PlayerModule _playerModule;

        public FriendModule(DataContext db, ILogger<FriendModule> logger)
        {
            _db = db;
            _logger = logger;
        }

        protected override void OnConfiguringModules()
        {
            base.OnConfiguringModules();
            _playerModule = this.Server.GetModule<PlayerModule>();
            //_playerModule.PlayerCreating += PlayerController_PlayerCreating;
            //_playerModule.PlayerLoading += PlayerController_PlayerLoading;
            //_playerModule.PlayerLoaded += PlayerController_PlayerLoaded;
            //_playerModule.PlayerEverydayRefresh += PlayerController_PlayerEverydayRefresh;
        }
        #region 事件
        #endregion

        //private void PlayerController_PlayerEverydayRefresh(object sender, Player e)
        //{
        //    if (e.FriendList.LastRefreshTime.Date != DateTime.Today)
        //    {
        //        e.FriendList.LastRefreshTime = DateTime.Today;
        //        e.FriendList.RecvTimes = GameConfig.FriendMaxOilTimes;
        //        foreach (var f in e.FriendList.Friends)
        //        {
        //            if (f.CanRecvOil)
        //            {
        //                f.CanRecvOil = false;
        //            }
        //            if (!f.CanSendOil)
        //            {
        //                f.CanSendOil = true;
        //            }
        //        }
        //    }
        //}

        #region 辅助函数
        private Dictionary<string, FriendList> _friendlists = new Dictionary<string, FriendList>();
        public FriendList QueryPlayerFriendList(string playerId)
        {
            bool needsave = false;
            if(!_friendlists.TryGetValue(playerId, out var friendList))
            {
                friendList = _db.FriendLists
                    .Include(fl => fl.Friends)
                    .Include(fl => fl.FriendApplications)
                    .FirstOrDefault(fl => fl.PlayerId == playerId);
                if (friendList == null)
                {
                    needsave = true;
                    friendList = new FriendList()
                    {
                        PlayerId = playerId,
                        RecvTimes = GameConfig.FriendMaxOilTimes,
                        FriendApplications = new List<FriendApplication>(),
                        Friends = new List<Friendship>(),
                        LastRefreshTime = DateTime.Now
                    };
                    _db.FriendLists.Add(friendList);
                }
            }
            if (friendList.LastRefreshTime.Date != DateTime.Today)
            {
                needsave = true;
                friendList.LastRefreshTime = DateTime.Today;
                friendList.RecvTimes = GameConfig.FriendMaxOilTimes;
                foreach (var f in friendList.Friends)
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
            if (needsave)
            {
                _db.SaveChanges();
            }
            return friendList;
        }
        #endregion

        #region 客户端接口
        public int Call_FriendList(FriendListRequest request)
        {
            FriendListResponse response = new FriendListResponse();
            response.success = true;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            FriendList fl = this.QueryPlayerFriendList(player.Id);

            response.pid = player.Id;
            response.oilTimes = fl.RecvTimes;
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
            FriendList fl = this.QueryPlayerFriendList(player.Id);

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

            FriendList myFl = this.QueryPlayerFriendList(player.Id);
            if (myFl.Friends.Any(f => f.PlayerId == fid))
            {
                return (int)GameErrorCode.已经是好友;
            }
            if (myFl.Friends.Count == GameConfig.FriendMaxCount)
            {
                return (int)GameErrorCode.好友列表已满;
            }

            var other = _playerModule.QueryPlayerBaseInfo(fid);
            if (other == null)
            {
                return (int)GameErrorCode.查无此人;
            }

            FriendList hisfl = this.QueryPlayerFriendList(other.Id);//获取想要加的好友的朋友列表
            if (hisfl.FriendApplications.Any(f => f.PlayerId == player.Id))
            {                
                Session.SendAsync(new AddFriendResponse()
                {
                    success = true,
                    id = request.id
                });
                return 0;
                //return (int)GameErrorCode.已提交过好友申请;
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

            this.OnRequestFriendApplication(myFl, hisfl);
            return 0;
        }

        public int Call_ProcessFriendApplication(ProcessFriendAddRequest request)
        {
            string fid = request.id;
            bool pass = request.pass;

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            FriendList fl = this.QueryPlayerFriendList(player.Id);
            
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
                var other = _playerModule.QueryPlayerBaseInfo(fid);
                if (other == null)
                {
                    return (int)GameErrorCode.查无此人;
                }
                var otherFlist = this.QueryPlayerFriendList(other.Id);
                if (otherFlist.Friends.Count >= GameConfig.FriendMaxCount)
                {
                    return (int)GameErrorCode.对方好友列表已满;
                }
                //检查是否已经是好友
                if (!fl.Friends.Any(f => f.PlayerId == fid))
                {
                    fl.Friends.Add(new Friendship() { CanRecvOil = false, CanSendOil = true, FriendListId = player.Id, PlayerId = fid, FromTime = DateTime.Now });
                }
                FriendList hisfl = otherFlist;//获取想要加的好友的朋友列表
                if (!hisfl.Friends.Any(f=> f.PlayerId == player.Id))
                {
                    var otherFs = new Friendship() { CanRecvOil = false, CanSendOil = true, FriendListId = fid, PlayerId = player.Id, FromTime = DateTime.Now };
                    hisfl.Friends.Add(otherFs);


                    NewFriendNotify notify = new NewFriendNotify();
                    notify.success = true;
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
                    Server.SendByUserNameAsync(fid, notify);
                }                    
                _db.SaveChanges();
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
            FriendList fl = this.QueryPlayerFriendList(player.Id);
            var friend = fl.Friends.FirstOrDefault(x => x.PlayerId == fid);
            if (friend == null)
            {
                Session.SendAsync(new DelFriendResponse()
                {
                    id = fid,
                    success = true,
                });
                return -1;
            }
            _db.Friendships.Remove(friend);

            var otherFl = this.QueryPlayerFriendList(fid);
            var otherFs = otherFl.Friends.FirstOrDefault(x => x.PlayerId == player.Id);
            if (otherFs != null)
            {
                _db.Friendships.Remove(otherFs);
                FriendDelNotify notify = new FriendDelNotify();
                notify.success = true;
                notify.pid = player.Id;
                Server.SendByUserNameAsync(request.id, notify);
            }
            _db.SaveChanges();

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
            var myfriendList = this.QueryPlayerFriendList(player.Id);
            var friendsId = myfriendList.Friends.Select(x => x.PlayerId).ToList();
            friendsId.AddRange(myfriendList.FriendApplications.Select(x => x.PlayerId));

            DateTime yestoday = DateTime.Today.AddDays(-3);
            var fsl = _db.FriendLists
                .Where(p => p.LastRefreshTime >= yestoday)
                .Where(p => p.PlayerId != player.Id && !friendsId.Contains(p.PlayerId))
                .Include(p => p.FriendApplications)
                .Where(p => !p.FriendApplications.Any(f => f.PlayerId == player.Id))
                .Take(5)
                .AsNoTracking().ToList();
            response.friends = fsl.Select(f =>
            {
                var p = _playerModule.QueryPlayerBaseInfo(f.PlayerId);
                return new FriendInfo()
                {
                    id = p.Id,
                    icon = p.Icon,
                    level = p.Level,
                    nickyName = p.NickName,
                    power = p.MaxPower,
                    vip = p.VIP,
                };
            }).ToList();
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
            var friendlist = this.QueryPlayerFriendList(player.Id);
            bool change = false;
            if (all)
            {                
                foreach (var fs in friendlist.Friends)
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

                        this.OnSendFriendOil(friendlist.PlayerId, friend.PlayerId);
                    }
                }
            }
            else
            {
                String fid = request.id;//朋友的id
                var fs = friendlist.Friends.FirstOrDefault(x => x.PlayerId == fid);
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

                    this.OnSendFriendOil(friendlist.PlayerId, friend.PlayerId);
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
            var friendlist = this.QueryPlayerFriendList(player.Id);
            bool all = request.all;
            int oil = 0;
            if (all)
            {
                foreach (var f in friendlist.Friends)
                {
                    if (friendlist.RecvTimes <= 0)
                    {
                        break;
                    }
                    if (f.CanRecvOil)
                    {
                        f.CanRecvOil = false;
                        oil += GameConfig.FriendOil;
                        friendlist.RecvTimes--;
                    }
                }
            }
            else
            {
                if (friendlist.RecvTimes > 0)
                {
                    String fid = request.id;//好友id
                    var f = friendlist.Friends.FirstOrDefault(x => x.PlayerId == fid);
                    if (f.CanRecvOil)
                    {
                        f.CanRecvOil = false;
                        oil += GameConfig.FriendOil;
                        friendlist.RecvTimes--;
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
                response.oilTimes = friendlist.RecvTimes;
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
            FriendList fl = this.QueryPlayerFriendList(player.Id);
            foreach (var app in fl.FriendApplications)
            {
                response.fs.Add(app.PlayerId);
                string fid = app.PlayerId;
                if (fl.Friends.Count >= GameConfig.FriendMaxCount)
                {
                    break;
                }
                var otherFriendList = this.QueryPlayerFriendList(fid);
                if (otherFriendList.Friends.Count >= GameConfig.FriendMaxCount)
                {
                    continue;//对方好友列表已满
                }
                if (!otherFriendList.Friends.Any(f=>f.PlayerId == player.Id))
                {
                    var other = _playerModule.QueryPlayerBaseInfo(fid);
                    var otherFs = new Friendship() { CanRecvOil = false, CanSendOil = true, FriendListId = fid, PlayerId = player.Id, FromTime = DateTime.Now };
                    otherFriendList.Friends.Add(otherFs);
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
                if(!fl.Friends.Any(f=>f.PlayerId == fid))
                {
                    fl.Friends.Add(new Friendship() { CanRecvOil = false, CanSendOil = true, FriendListId = player.Id, PlayerId = fid, FromTime = DateTime.Now });                    
                }
            }
            if (fl.FriendApplications.Any())
            {
                _db.FriendApplications.RemoveRange(fl.FriendApplications);
                _db.SaveChanges();
            }
            Session.SendAsync(response);
            return 0;
        }

        #endregion


        public event GamePlayerEventHandler<FriendList, FriendList> SendFriendApplicationRequest;
        public void OnRequestFriendApplication(FriendList player, FriendList other)
        {
            SendFriendApplicationRequest?.Invoke(player, other);
        }
        public event GamePlayerEventHandler<string, string> SendFriendOil;
        public void OnSendFriendOil(string player, string other)
        {
            SendFriendOil?.Invoke(player, other);
        }
    }
}
