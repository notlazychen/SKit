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
            _actions.Add("win", Win);
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

        private void Win(string[] args)
        {
            var player = this.CurrentSession.GetBindPlayer();
            var dc = this.Server.GetController<DungeonController>();
            int type = int.Parse(args[0]);
            int sectionIndex = int.Parse(args[1]);
            int missionIndex = int.Parse(args[2]);

            var section = player.Sections.FirstOrDefault(x=>x.Type == type);
            if (section == null)
                return;
            var dungeon = section.Dungeons.FirstOrDefault();
            if (dungeon == null)
                return;

            while (section.Index <= sectionIndex && dungeon.Mission <= missionIndex)
            {
                DDungeon ddungeon = dc.DDungeons[dungeon.Type][dungeon.Section][dungeon.Mission];
                string reason = $"副本{ddungeon.id}:{ddungeon.name}战斗胜利";
                //dungeon.FightTimes += 1;
                //副本评星
                int star = 3;

                if (dungeon.Star == 0)//第一次通关
                {
                    if (dungeon.Next != 0)//开启下一关
                    {
                        var ddnext = dc.DDungeons[dungeon.Type][dungeon.Section][dungeon.Mission + 1];
                        //var section = player.Sections.First(s => s.Id == dungeon.SectionId);
                        var dnext = dc.MakeDungeon(player, ddnext, section);
                        section.Dungeons.Add(dnext);
                    }
                    else//开启下一章
                    {
                        if (dungeon.Type == 1)//普通副本直接开启下一章，尝试打开精英副本当前章
                        {
                            Section secionNext = new Section()
                            {
                                Id = Guid.NewGuid().ToString("D"),
                                PlayerId = player.Id,
                                Index = dungeon.Section + 1,
                                Type = dungeon.Type,
                                Dungeons = new List<Dungeon>()
                            };
                            player.Sections.Add(secionNext);
                            var dd = dc.DDungeons[dungeon.Type][secionNext.Index][1];
                            var dnext = dc.MakeDungeon(player, dd, secionNext);
                            secionNext.Dungeons.Add(dnext);

                            //检查精英副本是否已经通关上一章
                            bool preExSectionPassed = dc.CheckPassedSection(player, 2, dungeon.Section - 1);
                            if (preExSectionPassed)
                            {
                                Section secionEx = new Section()
                                {
                                    Id = Guid.NewGuid().ToString("D"),
                                    PlayerId = player.Id,
                                    Index = dungeon.Section,
                                    Type = 2,
                                    Dungeons = new List<Dungeon>()
                                };
                                player.Sections.Add(secionEx);
                                var ddEx = dc.DDungeons[2][secionEx.Index][1];
                                var dnextEx = dc.MakeDungeon(player, ddEx, secionEx);
                                secionEx.Dungeons.Add(dnextEx);
                            }
                        }
                        else//精英副本检查普通本是否通关下一章，通关则开启下一章
                        {
                            bool nextNormalSectionPassed = dc.CheckPassedSection(player, 1, dungeon.Section + 1);
                            if (nextNormalSectionPassed)
                            {
                                Section secionEx = new Section()
                                {
                                    Id = Guid.NewGuid().ToString("D"),
                                    PlayerId = player.Id,
                                    Index = dungeon.Section + 1,
                                    Type = 2,
                                    Dungeons = new List<Dungeon>()
                                };
                                player.Sections.Add(secionEx);
                                var ddEx = dc.DDungeons[2][secionEx.Index][1];
                                var dnextEx = dc.MakeDungeon(player, ddEx, secionEx);
                                secionEx.Dungeons.Add(dnextEx);
                            }
                        }
                    }
                }

                if (dungeon.Star < star)
                {
                    dungeon.Star = star;
                }

                //派发奖励
                var playerController = this.Server.GetController<PlayerController>();

                int costoil = ddungeon.oil_cost;
                int addexp = ddungeon.exp;
                int addunitexp = ddungeon.exp_element;
                //扣体力
                //playerController.AddCurrency(player, CurrencyType.OIL, -costoil, reason);
                playerController.AddExp(player, addexp, reason);
                //发放兵种经验
                var campController = this.Server.GetController<CampController>();

                campController.GrantUnitExp(player, addunitexp, reason);
                var pkgController = this.Server.GetController<PkgController>();

                pkgController.RandomReward(player, ddungeon.random_id, 1, reason);

                if (dungeon.IsLast)
                {
                    section = player.Sections.FirstOrDefault(s=>s.Type == type && s.Index == section.Index + 1);
                    if(section == null)
                    {
                        break;
                    }
                    dungeon = section.Dungeons.FirstOrDefault(x => x.Mission == 1);
                    if (dungeon == null)
                    {
                        break;
                    }
                }
                else
                {
                    dungeon = section.Dungeons.FirstOrDefault(x => x.Mission == dungeon.Mission + 1);
                    if (dungeon == null)
                    {
                        break;
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

