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
    /// 单位升级
    /// </summary>
    public class UnitLevelupCommand : GameCommand<LevelupUnitRequest>
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
            LevelupUnitResponse response = new LevelupUnitResponse();
            response.success = true;
            response.id = Request.id;

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var unit = player.Units.First(u => u.Id == Request.id);
            int oldLevel = unit.Level;
            string reason = $"兵种[{unit.Tid}]升级";

            UnitInfo ui = _campModule.AddUnitExp(player, unit, 0, true, Request.adv, reason);

            if (oldLevel != unit.Level)
            {
                _db.SaveChanges();
                var playerModule = this.Server.GetModule<PlayerModule>();
                response.iron = playerModule.GetCurrencyValue(player, CurrencyType.IRON);
                response.supply = playerModule.GetCurrencyValue(player, CurrencyType.SUPPLY);
                response.unitInfo = ui;
                Server.SendByUserNameAsync(player.Id, response);
            }
            return 0;
        }
    }
}
