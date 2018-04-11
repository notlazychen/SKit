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
    public class LegionScienceInfoCommand : GameCommand<LegionScienceRequest>
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

        //查询个人的军团科技
        public override int ExecuteCommand()
        {
            var pm = _legionModule.QueryLegionMember(Session.PlayerId);
            if (string.IsNullOrEmpty(pm.LegionId))
            {
                return (int)GameErrorCode.军团不存在;
            }
            var legion = _legionModule.QueryLegion(pm.LegionId);
            var player = _playerModule.QueryPlayer(pm.PlayerId);

            LegionScienceResponse response = new LegionScienceResponse();
            response.LegionSciences = new List<LegionScienceInfo>();
            foreach(var s in pm.LegionSciences)
            {
                var info = new LegionScienceInfo();
                info.id = s.Tid;
                info.level = s.Level;
                response.LegionSciences.Add(info);
            }
            Session.SendAsync(response);

            return 0;
        }
    }
}
