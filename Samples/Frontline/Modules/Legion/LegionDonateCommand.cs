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
    //军团捐献
    public class LegionDonateCommand : GameCommand<PayPartyRequest>
    {
        PlayerModule _playerModule;
        PkgModule _pkgModule;
        LegionModule _legionModule;
        DataContext _db;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _legionModule = Server.GetModule<LegionModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            var pm = _legionModule.QueryLegionMember(Session.PlayerId);
            if (string.IsNullOrEmpty(pm.LegionId))
            {
                return (int)GameErrorCode.军团不存在;
            }
            var legion = _legionModule.QueryLegion(pm.LegionId);
            var player = _playerModule.QueryPlayer(pm.PlayerId);

            String pid = Session.PlayerId;
            int contri = Request.contri;
            
            if (pm.IsTodayDonated) {
                return (int)GameErrorCode.今日已捐献;
            }

            DLegionDonate dc = _legionModule.DLegionDonates[contri];
            if (!_playerModule.IsCurrencyEnough(player, dc.type, dc.cost))
            {
                return (int)GameErrorCode.资源不足;
            }
            string reason = "军团捐献";
            _playerModule.AddCurrency(player, dc.type, -dc.cost, reason);
            _playerModule.AddCurrency(player, CurrencyType.LEGIONCOIN, dc.party_coin, reason);
            pm.IsTodayDonated = true;
            pm.Contribution += dc.party_contri;//军团贡献
            pm.LastContriTime = DateTime.Now;
            var rewardInfo = _pkgModule.RandomReward(player, dc.contri, 1, reason);

            legion.Exp += dc.exp_party;//军团也会获得军团经验
            DLegion de = _legionModule.DLegions[legion.Level];
            while (de.exp > 0 && legion.Exp >= de.exp)
            {
                legion.Level++;
                de = _legionModule.DLegions[legion.Level];
            }
            _db.SaveChanges();
            PayPartyResponse response = new PayPartyResponse();
            response.success = true;
            response.rewardInfo = rewardInfo;
            response.cur = 1;
            Session.SendAsync(response);
            //todo: 任务和记录捐献日志
            return 0;
        }
    }
}
