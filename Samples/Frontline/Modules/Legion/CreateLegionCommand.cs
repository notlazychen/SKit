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
    public class CreateLegionCommand : GameCommand<CreatePartyRequest>
    {
        PlayerModule _playerModule;
        LegionModule _legionModule;
        DataContext _db;

        protected override void OnInit()
        {
            _legionModule = Server.GetModule<LegionModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        //客户端请求任务信息
        public override int ExecuteCommand()
        {
            //验证名字是否和谐
            if (Request.name == null || Request.name.Length < 2 || Request.name.Length > 30)
            {
                return (int)GameErrorCode.军团名不符合规则;
            }
            if (Request.shortName == null || Request.shortName.Length != 3)
            {
                return (int)GameErrorCode.军团名不符合规则;
            }
            //todo: 和谐字检查

            //检查退团CD
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            //检查等级是否满足
            if (player.Level < GameConfig.LegionCreateLevel)
            {
                return (int)GameErrorCode.等级不符合要求;
            }
            var playerCon = Server.GetModule<PlayerModule>();
            if (!playerCon.IsCurrencyEnough(player, CurrencyType.DIAMOND, GameConfig.LegionCreateCostDiamond))
            {
                return (int)GameErrorCode.资源不足;
            }
            var member = _legionModule.QueryLegionMember(player.Id);
            if (member.Career != LegionCareer.Free)
            {
                return 0;
            }
            if ((DateTime.Now - member.LastLeftTime).TotalDays < 1)
            {
                return (int)GameErrorCode.退团时间未满24小时不能加入和创建军团;
            }
            //检查名字和缩写名字是否重名
            bool dup = _db.Legions.Any(l => l.Name == Request.name);
            if (dup)
            {
                return (int)GameErrorCode.军团重名;
            }
            dup = _db.Legions.Any(l => l.ShortName == Request.shortName);
            if (dup)
            {
                return (int)GameErrorCode.军团缩写重名;
            }
            CreatePartyResponse response = new CreatePartyResponse();
            playerCon.AddCurrency(player, CurrencyType.DIAMOND, -GameConfig.LegionCreateCostDiamond, "创建军团");
            Legion legion = new Legion();

            legion.Id = Guid.NewGuid().ToString();
            legion.Icon = Request.icon;
            legion.Name = Request.name;
            legion.ShortName = Request.shortName;
            legion.Note = Request.note;
            legion.Creater = player.Id;
            legion.Level = 1;
            legion.NeedCheck = Request.check;//是否需要审核 true:需要 false:不需要
            legion.LeaderId = member.PlayerId;
            _db.Legions.Add(legion);

            _legionModule.FreeLegion.Members.Remove(member);
            legion.Members.Add(member);
            member.Career = LegionCareer.Commander;
            _db.SaveChanges();

            //todo: 创建成功移除申请列表

            response.success = true;
            response.party = _legionModule.ToLegionInfo(legion);

            Session.SendAsync(response);

            _legionModule.OnPlayerJoinLegion(member, legion);
            return 0;
        }
    }
}
