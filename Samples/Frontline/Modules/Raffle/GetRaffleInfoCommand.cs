using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
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
    public class GetRaffleInfoCommand : GameCommand<LotteryInfoRequest>
    {
        RaffleModule _lotteryModule;
        DataContext _db;

        protected override void OnInit()
        {
            //_playerModule = Server.GetModule<PlayerModule>();
            _lotteryModule = Server.GetModule<RaffleModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            var response = new LotteryInfoResponse();
            response.LotteryInfos = new List<LotteryInfo>();
            foreach (var g in _lotteryModule.DRaffleGroups.Values)
            {
                var lottery = _lotteryModule.QueryRaffle(Session.PlayerId, g.type);
                var info = new LotteryInfo()
                {
                    baseNumb = lottery.BaseNumb,
                    endTime = g.endtime == null ? 0 : g.endtime.Value.ToUnixTime(),
                    itemId = g.cost_item,
                    nextFreeTime = lottery.FreeNextTime.ToUnixTime(),
                    type = g.type,
                    theme_unit_id = g.theme_unit_id?.Object,
                };
                response.LotteryInfos.Add(info);
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
