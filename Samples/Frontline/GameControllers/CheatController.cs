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
            _actions.Add("addres", AddResource);
            _actions.Add("additem", AddItem);
            _actions.Add("addunit", AddUnit);
            _actions.Add("setunit", SetUnit);
        }
        #region 事件
        #endregion

        #region 辅助方法
        #endregion

        #region 客户端接口
        private const string reason = "GM命令";
        private Dictionary<string, Action<string[]>> _actions = new Dictionary<string, Action<string[]>>();

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
            camp.UnlockUnit(player, uid, true);

            _db.SaveChanges();
        }

        private void SetUnit(string[] args)
        {
            int uid = int.Parse(args[0]);
            int lv = int.Parse(args[1]);
            int grade = int.Parse(args[2]);

            var player = this.CurrentSession.GetBindPlayer();
            var unit = player.Units.First(u=>u.Tid == uid);
            unit.Level = lv;
            unit.Grade = grade;

            _db.SaveChanges();
        }

        private void SetUnitEquip(string[] args)
        {
            int uid = int.Parse(args[0]);
            int pos = int.Parse(args[1]);
            int lv = int.Parse(args[2]);
            int grade = int.Parse(args[3]);

            var player = this.CurrentSession.GetBindPlayer();
            var unit = player.Units.First(u => u.Tid == uid);
            var equip = unit.Equips.First(e => e.Pos == pos);
            equip.Level = lv;
            var camp = this.Server.GetController<CampController>();
            DEquipGrade deg = null;
            DEquip de = camp.DEquips[equip.Tid];

            var degt = camp.DEquipGrades[de.gradeid];
            while (true)
            {
                
                if(degt.grade == grade)
                {
                    deg = degt;
                    break;
                }
                if (degt.next_id == 0)
                {
                    break;
                }
                degt = camp.DEquipGrades[degt.next_id];
            }
            equip.GradeId = degt.grade;
            var unitInfo = camp.ToUnitInfo(unit);
            var equipInfo = new EquipInfo()
            {
                grade = equip.GradeId,
                equipId = equip.Tid,
                level = equip.Level
            };
            LevelupEquipResponse response1 = new LevelupEquipResponse();
            response1.success = true;
            response1.equipInfo = equipInfo;
            response1.unitInfo = unitInfo;
            response1.position = equip.Pos;
            response1.unitId = unit.Tid;
            CurrentSession.SendAsync(response1);

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

            //camp.EquipGradeUp?.Invoke(this, new EquipGradeUpEventArgs() { EquipInfo = response.equipInfo, OldGrade = deg.grade, UnitInfo = unitInfo });
            CurrentSession.SendAsync(response);
            _db.SaveChanges();
        }

        public void Call_Cheat(CheatRequest request)
        {
            String[] strs = request.action.Split(new[] { ',', ' ', '.'});
            string cmd = strs[0];
            string[] args = new string[strs.Length - 1];
            Array.Copy(strs, 1, args, 0, args.Length);
            CheatResponse response = new CheatResponse();
            Action<string[]> action;
            if(_actions.TryGetValue(cmd, out action)){
                response.success = true;
                response.type = 1;

                action(args);

                CurrentSession.SendAsync(response);
            }
            response.success = false;           
        }
        #endregion
    }
}

