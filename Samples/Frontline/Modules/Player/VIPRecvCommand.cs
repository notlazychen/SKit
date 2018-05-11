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
    public class VIPRecvCommand : GameCommand<GetVIPGiftRequest>
    {
        PlayerModule _playerModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            if (player.VIPGiftReceved == 1)
            {
                return (int)GameErrorCode.已领取VIP每日奖励;
            }
            var dvip = _playerModule.VIP[player.VIP];
            if (dvip.oneday_recv_gold != 0 || dvip.oneday_recv_diamond != 0)
            {
                player.VIPGiftReceved = 1;

                _playerModule.AddCurrency(player, CurrencyType.GOLD, dvip.oneday_recv_gold, "领取VIP每日奖励");
                _playerModule.AddCurrency(player, CurrencyType.DIAMOND, dvip.oneday_recv_diamond, "领取VIP每日奖励");
                _db.SaveChanges();
                var response = new GetVIPGiftResponse();
                response.rewardInfo = new RewardInfo
                {
                    res = new List<ResInfo>
                    {
                        new ResInfo{ type = CurrencyType.GOLD, count = dvip.oneday_recv_gold },
                        new ResInfo{type = CurrencyType.DIAMOND, count = dvip.oneday_recv_diamond}
                    }
                };

                Session.SendAsync(response);
                return 0;
            }
            else
            {
                return (int)GameErrorCode.无可领取VIP每日奖励;
            }
        }
    }
}
