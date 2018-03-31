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
    public class GetLotteryInfoCommand : GameCommand<GetLotteryInfoRequest>
    {
        LotteryModule _lotteryModule;
        DataContext _db;

        protected override void OnInit()
        {
            //_playerModule = Server.GetModule<PlayerModule>();
            _lotteryModule = Server.GetModule<LotteryModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            GetLotteryInfoResponse response = new GetLotteryInfoResponse();
            var lottery = _lotteryModule.QueryLottery(Session.PlayerId);
            response.success = true;
            response.goldUsedNumb = lottery.GoldUsedNumb;//今日金币抽次数  
            response.goldFreeNextTime = lottery.GoldFreeNextTime.ToUnixTime();//下次免费金币抽刷新时间
            response.goldBaseNumb = lottery.GoldBaseNumb;//剩余出金币抽保底奖励的次数
            response.goldFreeNumb = lottery.GoldFreeNumb;
            response.diamondUsedNumb = lottery.DmdUsedNumb;//今日钻石抽次数   
            response.diamondFreeNextTime = lottery.DmdFreeNextTime.ToUnixTime();//下次免费钻石抽时间
            response.diamondBaseNumb = lottery.DmdBaseNumb;//剩余出钻石保底奖励的次数
            response.diamondFreeNumb = lottery.DmdFreeNumb;
            Session.SendAsync(response);
            return 0;
        }
    }
}
