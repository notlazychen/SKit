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
    public class EquipLevelupCommand : GameCommand<LevelupEquipRequest>
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
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var unit = player.Units.First(u => u.Tid == Request.unitId);

            DUnit du = _campModule.DUnits[unit.Tid];
            var equip = unit.Equips.First(e => e.Pos == Request.position);
            var playerModule = this.Server.GetModule<PlayerModule>();
            string reason = $"兵种装备升级{unit.Tid}:{equip.Tid}";
            int oldlevel = equip.Level;
            DEquip de = _campModule.DEquips[equip.Tid];
            DEquipGrade deg = _campModule.DEquipGrades[equip.GradeId];
            while (true)
            {
                if (equip.Level >= player.Level)
                {
                    break;
                }

                if (equip.Level >= deg.max_level)
                {
                    break;
                }
                //扣资源升级
                DEquipLevelCost dl;
                if (!_campModule.DequipLevels.TryGetValue(equip.Level, out dl))
                {
                    break;
                }
                int rescont = (int)((du.type == 1 ? dl.soldier_gold : dl.tank_gold) * de.level_k / 10000d);
                if (!playerModule.IsCurrencyEnough(player, CurrencyType.GOLD, rescont))
                {
                    break;
                }

                playerModule.AddCurrency(player, CurrencyType.GOLD, rescont, reason);
                equip.Level += 1;

                if (!Request.multy)
                {
                    break;
                }
            }
            var equipInfo = new EquipInfo()
            {
                grade = equip.GradeId,
                equipId = equip.Tid,
                level = equip.Level
            };

            UnitInfo unitInfo;
            if (oldlevel != equip.Level)
            {
                unitInfo = _campModule.ToUnitInfo(unit, du, true);
                _campModule.OnEquipLevelUp(new EquipLevelUpEventArgs()
                {
                    EquipInfo = equipInfo,
                    UnitInfo = unitInfo,
                    OldLevel = oldlevel
                });
                _db.SaveChanges();
            }
            else
            {
                unitInfo = _campModule.ToUnitInfo(unit, du);
            }

            LevelupEquipResponse response = new LevelupEquipResponse();
            response.success = true;
            response.equipInfo = equipInfo;
            response.unitInfo = unitInfo;
            response.position = equip.Pos;
            response.unitId = unit.Tid;
            Session.SendAsync(response);
            return 0;
        }
    }
}
