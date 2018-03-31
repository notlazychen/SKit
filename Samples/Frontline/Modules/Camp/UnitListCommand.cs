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
    /// <summary>
    /// 获取兵种信息
    /// </summary>
    public class UnitListCommand : GameCommand<UnitListRequest>
    {
        PlayerModule _playerModule;
        CampModule _campModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _campModule = Server.GetModule<CampModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            UnitListResponse response = new UnitListResponse();
            response.success = true;
            response.pid = Session.PlayerId;
            response.units = new List<UnitInfo>();
            var units = _playerModule.QueryPlayer(Session.PlayerId).Units;
            foreach (var unit in units)
            {
                var u = _campModule.ToUnitInfo(unit);
                response.units.Add(u);
            }
            Session.SendAsync(response);
            return 0;
        }
    }
}
