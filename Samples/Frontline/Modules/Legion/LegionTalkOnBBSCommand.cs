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
    public class LegionTalkOnBBSCommand : GameCommand<TalkOnBBSRequest>
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

            LegionBBS bm = new LegionBBS();
            bm.Content = Request.message;
            bm.Id = Guid.NewGuid().ToString();
            bm.Time = DateTime.Now;
            bm.PlayerId = pm.PlayerId;
            bm.LegionId = legion.Id;

            if (legion.LegionBBS.Count >= GameConfig.LegionBBSLength)
            {
                _db.LegionBBS.Remove(legion.LegionBBS.First());
            }
            legion.LegionBBS.Add(bm);
            _db.SaveChanges();

            TalkOnBBSResponse response = new TalkOnBBSResponse();
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
