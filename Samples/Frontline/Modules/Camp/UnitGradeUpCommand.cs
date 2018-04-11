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
    /// <summary>
    /// 单位进阶
    /// </summary>
    public class UnitGradeUpCommand : GameCommand<ClazupUnitRequest>
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
            ClazupUnitResponse response = new ClazupUnitResponse();
            response.id = Request.id;
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            Unit unit = player.Units.First(x => x.Id == Request.id);


            DUnit du = _campModule.DUnits[unit.Tid];

            int maxClaz = du.grade_max;
            int itemId = du.grade_item_id;

            if (unit.Grade >= du.grade_max)
            {
                return (int)GameErrorCode.兵种已经最高阶;
            }
            DUnitGradeUp dug = _campModule.DUnitGrades[du.star][du.type][unit.Grade + 1];
            if (unit.Level < dug.min_level)
            {
                return (int)GameErrorCode.兵种不满足升阶等级; ;
            }
            int itemCount = dug.grade_item_cnt;//碎片数量

            var pkgController = Server.GetModule<PkgModule>();
            var playerModule = Server.GetModule<PlayerModule>();
            string reason = $"兵种进阶{du.tid}";
            if (playerModule.IsCurrencyEnough(player, CurrencyType.GOLD, dug.gold))
            {
                if(!pkgController.IsItemEnough(player, dug.cost_item_id.Object, dug.cost_item_cnt.Object))
                {
                    return (int)GameErrorCode.道具不足;
                }
                if (pkgController.TrySubItem(player, itemId, itemCount, reason, out var item))
                {
                    pkgController.SubItems(player, dug.cost_item_id.Object, dug.cost_item_cnt.Object, reason);
                    playerModule.AddCurrency(player, CurrencyType.GOLD, -dug.gold, reason);
                    unit.Grade += 1;

                    response.unitInfo = _campModule.ToUnitInfo(unit, du, true);
                    response.gold = playerModule.GetCurrencyValue(player, CurrencyType.GOLD);
                    response.itemId = itemId;
                    response.count = item.Count;
                    response.success = true;

                    _db.SaveChanges();

                    Session.SendAsync(response);

                    //任务
                    _campModule.OnUnitGradeUp(new UnitGradeUpEventArgs()
                    {
                        UnitInfo = response.unitInfo,
                        OldGrade = unit.Grade - 1
                    });
                }
            }
            return 0;
        }
    }
}
