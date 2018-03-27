using Frontline.Data;
using Frontline.GameDesign;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using SKit.Common.Utils;
using Frontline.Common;

namespace Frontline.GameControllers
{
    public class CheatController : GameController
    {
        private GameDesignContext _designDb;
        private DataContext _db;

        public CheatController(DataContext db, GameDesignContext design)
        {
            _db = db;
            _designDb = design;
        }

        protected override void OnReadGameDesignTables()
        {
        }

        protected override void OnRegisterEvents()
        {
            _actions.Add("addexp", AddExp);
            _actions.Add("addres", AddResource);
            _actions.Add("additem", AddItem);
            _actions.Add("addunit", AddUnit);
            _actions.Add("invincible", Invincible);
        }
        #region 事件
        #endregion

        #region 辅助方法
        private const string reason = "GM命令";
        private readonly Dictionary<string, Action<string[]>> _actions = new Dictionary<string, Action<string[]>>();

        private void AddExp(string[] args)
        {
            int exp = int.Parse(args[0]);

            var player = this.CurrentSession.GetBindPlayer();
            var playerController = this.Server.GetController<PlayerController>();
            playerController.AddExp(player, exp, reason);
            _db.SaveChanges();
        }

        private void AddResource(string[] args)
        {
            int type = int.Parse(args[0]);
            int cnt = int.Parse(args[1]);

            var player = this.CurrentSession.GetBindPlayer();
            var playerController = this.Server.GetController<PlayerController>();
            playerController.AddCurrency(player, type, cnt, reason);
            _db.SaveChanges();
        }

        private void AddItem(string[] args)
        {
            int itemid = int.Parse(args[0]);
            int cnt = int.Parse(args[1]);

            var player = this.CurrentSession.GetBindPlayer();
            var pkg = this.Server.GetController<PkgController>();
            pkg.AddItem(player, itemid, cnt, reason);
            _db.SaveChanges();
        }

        private void AddUnit(string[] args)
        {
            int uid = int.Parse(args[0]);

            var player = this.CurrentSession.GetBindPlayer();
            var camp = this.Server.GetController<CampController>();
            UnitInfo ui = camp.UnlockUnit(player, uid);

            _db.SaveChanges();
        }

        private void Invincible(string[] args)
        {

            var player = this.CurrentSession.GetBindPlayer();

            var camp = this.Server.GetController<CampController>();
            foreach (var unit in player.Units)
            {
                var du = camp.DUnits[unit.Tid];
                int maxLeve = camp.DUnitLevels.Count;
                unit.Level = maxLeve;
                unit.Grade = du.grade_max;
                //camp.OnUnitLevelUp(new UnitLevelUpEventArgs() { UnitInfo = camp.ToUnitInfo(unit), OldLevel = oldlevel });
                //camp.OnUnitGradeUp(new UnitGradeUpEventArgs() { OldGrade = oldgrade, UnitInfo = camp.ToUnitInfo(unit) });
                foreach (var equip in unit.Equips)
                {
                    DEquip de = camp.DEquips[equip.Tid];
                    var equipMaxLevel = camp.DequipLevels.Count;
                    equip.Level = equipMaxLevel;

                    DEquipGrade deg = camp.DEquipGrades[de.gradeid];
                    while (true)
                    {
                        if (deg.next_id == 0)
                        {
                            equip.GradeId = deg.id;
                            break;
                        }
                    }
                }
            }

            _db.SaveChanges();
        }
        #endregion

        #region 客户端接口

        public int Call_Cheat(CheatRequest request)
        {
            String[] strs = request.action.ToLower().Split(new[] { ',', ' ', '.', '。', '，'});
            string cmd = strs[0];
            string[] args = new string[strs.Length - 1];
            Array.Copy(strs, 1, args, 0, args.Length);
            CheatResponse response = new CheatResponse();
            if(_actions.TryGetValue(cmd, out var action)){
                response.success = true;
                response.type = 1;
                action(args);
                CurrentSession.SendAsync(response);
            }
            return 0;
        }
        #endregion
    }
}

