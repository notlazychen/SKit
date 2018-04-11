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
    public class LegionProcessApplicationCommand : GameCommand<ProcessApplyRequest>
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
            var app = legion.LegionApplications.FirstOrDefault(ap=>ap.Id == Request.id);
            if (app == null)
                return -2;
            
            if (Request.pass)
            {
                //判断军团人数是否已满
                var dl = _legionModule.DLegions[legion.Level];
                if(dl.max <= legion.Members.Count)
                {
                    return (int)GameErrorCode.军团人数已满;
                }
                var pmother = _legionModule.QueryLegionMember(app.PlayerId);
                pmother.LegionId = legion.Id;
                pmother.Career = LegionCareer.Member;
                legion.Members.Add(pmother);
                _db.LegionApplications.Remove(app);
                _db.SaveChanges();
            }
            else
            {
                _db.LegionApplications.Remove(app);
                _db.SaveChanges();
            }

            ProcessApplyResponse response = new ProcessApplyResponse();
            response.id = Request.id;
            response.pass = Request.pass;
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
