using Frontline.Data;
using Frontline.GameDesign;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using SKit.Common.Utils;
using Frontline.Common;
using Microsoft.Extensions.Logging;

namespace Frontline.GameControllers
{
    public class OnlineRewadController : GameController
    {
        private GameDesignContext _designDb;
        private DataContext _db;
        private ILogger _logger;

        public DOlReward DOlReward { get; private set; }

        public OnlineRewadController(DataContext db, GameDesignContext design, ILogger<OnlineRewadController> logger)
        {
            _db = db;
            _designDb = design;
            _logger = logger;
        }

        protected override void OnReadGameDesignTables()
        {
            DOlReward = _designDb.DOlRewards.AsNoTracking().First();
        }

        protected override void OnRegisterEvents()
        {
            var playerController = Server.GetController<PlayerController>();
            playerController.PlayerCreating += PlayerController_PlayerCreating;
            playerController.PlayerLoaded += PlayerController_PlayerLoaded;
            playerController.PlayerLoading += PlayerController_PlayerLoading;
        }

        private void PlayerController_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader.Include(x => x.OlReward);
        }

        private void PlayerController_PlayerLoaded(object sender, Player e)
        {
            if (e.OlReward == null)
            {
                int r = MathUtil.RandomNumber(0, DOlReward.low_id.Object.Length);
                e.OlReward = new PlayerOlReward()
                {
                    PlayerId = e.Id,
                    NextTime = DateTime.Now.Add(DOlReward.time),
                    RewardIndex = r,
                    Round = 0
                };
            }
        }

        private void PlayerController_PlayerCreating(object sender, Player e)
        {
            int r = MathUtil.RandomNumber(0, DOlReward.low_id.Object.Length);
            e.OlReward = new PlayerOlReward()
            {
                PlayerId = e.Id,
                NextTime = DateTime.Now.Add(DOlReward.time),
                RewardIndex = r,
                Round = 0
            };
        }

        #region 事件
        #endregion

        #region 辅助方法
        private RewardInfo ToRewardInfo(PlayerOlReward ol)
        {
            RewardInfo reward = new RewardInfo()
            {
                items = new List<RewardItem>(),
                res = new List<ResInfo>()
            };
            int type, cnt;
            if (ol.Round + 1 == DOlReward.t)
            {
                type = DOlReward.adv_id.Object[ol.RewardIndex];
                cnt = DOlReward.adv_cnt.Object[ol.RewardIndex];
            }
            else
            {
                type = DOlReward.low_id.Object[ol.RewardIndex];
                cnt = DOlReward.low_cnt.Object[ol.RewardIndex];
            }
            if (type < 20)
            {
                reward.res.Add(new ResInfo() { type = type, count = cnt });
            }
            else
            {
                reward.items.Add(new RewardItem() { id = type, count = cnt });
            }
            return reward;
        }
        #endregion

        #region 客户端接口
        public int Call_OlRewardInfo(GetOnlineRewardInfoRequest request)
        {
            GetOnlineRewardInfoResponse response = new GetOnlineRewardInfoResponse();
            var player = CurrentSession.GetBindPlayer();
            var ol = player.OlReward;
            response.recvTime = ol.NextTime.ToUnixTime();
            response.reward = this.ToRewardInfo(ol);
            response.success = true;
            CurrentSession.SendAsync(response);
            return 0;
        }
        public int Call_RecvOlReward(RecvOnlineRewardRequest request)
        {
            RecvOnlineRewardResponse response = new RecvOnlineRewardResponse();
            var player = CurrentSession.GetBindPlayer();
            var ol = player.OlReward;
            var now = DateTime.Now;
            if (ol.NextTime <= now)
            {
                RewardInfo reward = new RewardInfo() { items = new List<RewardItem>(), res = new List<ResInfo>() };
                int type, cnt;
                if (ol.Round + 1 == DOlReward.t)
                {
                    type = DOlReward.adv_id.Object[ol.RewardIndex];
                    cnt = DOlReward.adv_cnt.Object[ol.RewardIndex];
                }
                else
                {
                    type = DOlReward.low_id.Object[ol.RewardIndex];
                    cnt = DOlReward.low_cnt.Object[ol.RewardIndex];
                }
                var playercontroller = Server.GetController<PlayerController>();
                var pkg = Server.GetController<PkgController>();
                string reason = "领取在线奖励";
                if (type < 20)
                {
                    playercontroller.AddCurrency(player, type, cnt, reason);

                    reward.res.Add(new ResInfo() { type = type, count = cnt });
                }
                else
                {
                    pkg.AddItem(player, type, cnt, reason);

                    reward.items.Add(new RewardItem() { id = type, count = cnt });
                }

                ol.NextTime = now.Add(DOlReward.time);
                ol.Round = (ol.Round + 1) % DOlReward.t;
                int r;
                if (ol.Round + 1 == DOlReward.t)
                {
                    r = MathUtil.RandomNumber(0, DOlReward.adv_id.Object.Length);
                }
                else
                {
                    r = MathUtil.RandomNumber(0, DOlReward.low_id.Object.Length);
                }
                ol.RewardIndex = r;
                _db.SaveChanges();
                response.reward = reward;
                response.success = true;
                response.nextRecvTime = ol.NextTime.ToUnixTime();
                response.nextReward = this.ToRewardInfo(ol);

                CurrentSession.SendAsync(response);
            }
            return 0;
        }
        #endregion
    }
}

