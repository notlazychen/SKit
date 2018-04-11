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
    public class WeekBoxRecvCommand : GameCommand<RecvWeekBoxRequest>
    {
        PlayerModule _playerModule;
        WeekBattleModule _weekModule;
        CampModule _campModule;
        PkgModule _pkgModule;
        DataContext _db;

        protected override void OnInit()
        {
            _campModule = Server.GetModule<CampModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _weekModule = Server.GetModule<WeekBattleModule>();
            _pkgModule = Server.GetModule<PkgModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var ww = _weekModule.QueryWeekData(player.Id);
            String reason = "领取周常宝箱";

            RecvWeekBoxResponse response = new RecvWeekBoxResponse();
            DWeekBox dwb = _weekModule.DWeekBoxs[Request.id];
            //判断次数够不够
            if (ww.DaysInWeek < dwb.count)
            {
                return (int)GameErrorCode.周常挑战次数不足;
            }
            var recvd = ww.RecvBoxes.StringToMany(int.Parse);
            if (recvd.Contains(dwb.id))
            {
                return (int)GameErrorCode.已领取此周常宝箱;
            }
            recvd.Add(dwb.id);

            DItem ditem = _pkgModule.DItems[dwb.item_id];
            int randomId = ditem.breakRandomId;
            ww.RecvBoxes = recvd.ManyToString(x => x.ToString());
            RewardInfo ri = _pkgModule.RandomReward(player, randomId, 1, reason);
            _db.SaveChanges();
            response.success = true;
            response.id = dwb.id;
            response.reward = ri;
            Session.SendAsync(response);
            return 0;
        }
    }
}
