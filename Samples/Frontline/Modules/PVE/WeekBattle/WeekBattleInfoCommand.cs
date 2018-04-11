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
    public class WeekBattleInfoCommand : GameCommand<GetWeekInfoRequest>
    {
        WeekBattleModule _weekModule;
        DataContext _db;

        protected override void OnInit()
        {
            _weekModule = Server.GetModule<WeekBattleModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            GetWeekInfoResponse response = new GetWeekInfoResponse();
            var ww = _weekModule.QueryWeekData(Session.PlayerId);
            response.success = true;
            response.battleDays = ww.DaysInWeek;
            int totalCnt = GameConfig.week_challenge_number;
            response.numb = totalCnt - ww.UseNumb;
            response.recevedBoxes = ww.RecvBoxes.StringToMany(int.Parse);
            response.score = ww.Score;
            int rank = 0;
            response.rank = rank;
            int day = DateTime.Now.GetWeekDay();
            response.day = day;
            Session.SendAsync(response);
            return 0;
        }
    }
}
