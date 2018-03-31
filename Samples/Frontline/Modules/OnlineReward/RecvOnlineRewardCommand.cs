using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
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
    public class RecvOnlineRewardCommand : GameCommand<RecvOnlineRewardRequest>
    {
        PlayerModule _playerModule;
        OnlineRewadModule _onlineModule;
        PkgModule _pkg;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _onlineModule = Server.GetModule<OnlineRewadModule>();
            _pkg = Server.GetModule<PkgModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            RecvOnlineRewardResponse response = new RecvOnlineRewardResponse();
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var ol = player.OlReward;
            var now = DateTime.Now;
            if (ol.NextTime <= now)
            {
                RewardInfo reward = new RewardInfo() { items = new List<RewardItem>(), res = new List<ResInfo>() };
                int type, cnt;
                if (ol.Round + 1 == _onlineModule.DOlReward.t)
                {
                    type = _onlineModule.DOlReward.adv_id.Object[ol.RewardIndex];
                    cnt = _onlineModule.DOlReward.adv_cnt.Object[ol.RewardIndex];
                }
                else
                {
                    type = _onlineModule.DOlReward.low_id.Object[ol.RewardIndex];
                    cnt = _onlineModule.DOlReward.low_cnt.Object[ol.RewardIndex];
                }
                string reason = "领取在线奖励";
                if (type < 20)
                {
                    _playerModule.AddCurrency(player, type, cnt, reason);

                    reward.res.Add(new ResInfo() { type = type, count = cnt });
                }
                else
                {
                    _pkg.AddItem(player, type, cnt, reason);
                    reward.items.Add(new RewardItem() { id = type, count = cnt });
                }

                ol.NextTime = now.Add(_onlineModule.DOlReward.time);
                ol.Round = (ol.Round + 1) % _onlineModule.DOlReward.t;
                int r;
                if (ol.Round + 1 == _onlineModule.DOlReward.t)
                {
                    r = MathUtils.RandomNumber(0, _onlineModule.DOlReward.adv_id.Object.Length);
                }
                else
                {
                    r = MathUtils.RandomNumber(0, _onlineModule.DOlReward.low_id.Object.Length);
                }
                ol.RewardIndex = r;
                _db.SaveChanges();
                response.reward = reward;
                response.success = true;
                response.nextRecvTime = ol.NextTime.ToUnixTime();
                response.nextReward = _onlineModule.ToRewardInfo(ol);

                Session.SendAsync(response);
            }
            return 0;
        }
    }
}
