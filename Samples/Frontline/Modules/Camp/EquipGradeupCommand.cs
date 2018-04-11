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
    public class EquipGradeupCommand : GameCommand<UpGradeEquipRequest>
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
            DEquip de = _campModule.DEquips[equip.Tid];
            DEquipGrade deg = _campModule.DEquipGrades[equip.GradeId];
            if (deg.next_id == 0)
                return (int)GameErrorCode.装备已经最高阶;
            var pkgController = this.Server.GetModule<PkgModule>();
            bool itemenough = pkgController.IsItemEnough(player, deg.grade_item_id.Object, deg.grade_item_cnt.Object);
            if (!itemenough)
                return (int)GameErrorCode.道具不足;
            for(int i = 0; i< deg.grade_res_type.Object.Length; i++)
            {
                int type = deg.grade_res_type.Object[i];
                int cnt = deg.grade_res_cnt.Object[i];
                bool resenough = _playerModule.IsCurrencyEnough(player, type, cnt);
                if (!resenough)
                {
                    return (int)GameErrorCode.资源不足;
                }
            }
            string reason = $"兵种装备进阶{unit.Tid}:{equip.Tid}";
            pkgController.SubItems(player, deg.grade_item_id.Object, deg.grade_item_cnt.Object, reason);
            _playerModule.SubCurrencies(player, deg.grade_res_type.Object, deg.grade_res_cnt.Object, reason);
            DEquipGrade degNext = _campModule.DEquipGrades[deg.next_id];
            equip.GradeId = degNext.id;
            var unitInfo = _campModule.ToUnitInfo(unit, du, true);

            _db.SaveChanges();
            UpGradeEquipResponse response = new UpGradeEquipResponse();
            response.success = true;
            response.position = equip.Pos;
            response.unitId = unit.Tid;
            response.unitInfo = unitInfo;
            response.equipInfo = new EquipInfo()
            {
                grade = equip.GradeId,
                equipId = equip.Tid,
                level = equip.Level
            };

            _campModule.OnEquipGradeUp(new EquipGradeUpEventArgs() { EquipInfo = response.equipInfo, OldGrade = deg.grade, UnitInfo = unitInfo });
            Session.SendAsync(response);
            return 0;
        }
    }
}
