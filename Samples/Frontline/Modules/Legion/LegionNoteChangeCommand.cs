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
    public class LegionNoteChangeCommand : GameCommand<ModifyPartyRequest>
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
        
        public override int ExecuteCommand()
        {
            var pm = _legionModule.QueryLegionMember(Session.PlayerId);
            if (string.IsNullOrEmpty(pm.LegionId))
            {
                return (int)GameErrorCode.军团不存在;
            }
            var legion = _legionModule.QueryLegion(pm.LegionId);
            var player = _playerModule.QueryPlayerBaseInfo(pm.PlayerId);

            ModifyPartyResponse response = new ModifyPartyResponse();
            //判断是否修改名字
            if(legion.Name != Request.name)
            {
                //判断是否重名
            }
            if (pm.Career == LegionCareer.Commander)
            {
                legion.Icon = Request.icon;
                legion.Note = Request.note;
                _db.SaveChanges();
            }
            response.success = true;
            response.party = Request.party;
            response.icon = Request.icon;
            response.name = Request.name;
            response.note = Request.note;
            Session.SendAsync(response);
            return 0;
        }
    }
}
