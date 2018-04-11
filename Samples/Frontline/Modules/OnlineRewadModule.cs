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

namespace Frontline.Modules
{
    public class OnlineRewadModule : GameModule
    {
        private DataContext _db;
        private ILogger _logger;

        public DOlReward DOlReward { get; private set; }

        public OnlineRewadModule(DataContext db, ILogger<OnlineRewadModule> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        protected override void OnConfiguringModules()
        {
            var playerModule = Server.GetModule<PlayerModule>();
            playerModule.PlayerCreating += PlayerController_PlayerCreating;
            playerModule.PlayerLoaded += PlayerController_PlayerLoaded;
            playerModule.PlayerLoading += PlayerController_PlayerLoading;

            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DOlReward = designDb.DOlReward.AsNoTracking().First();
            });
        }

        private void PlayerController_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader.Include(x => x.OlReward);
        }

        private void PlayerController_PlayerLoaded(object sender, Player e)
        {
            if (e.OlReward == null)
            {
                int r = MathUtils.RandomNumber(0, DOlReward.low_id.Object.Length);
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
            int r = MathUtils.RandomNumber(0, DOlReward.low_id.Object.Length);
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
        public RewardInfo ToRewardInfo(PlayerOlReward ol)
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
    }
}

