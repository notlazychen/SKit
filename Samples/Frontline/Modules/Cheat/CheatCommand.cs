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
    public class CheatCommand : GameCommand<CheatRequest>
    {
        PlayerModule _playerModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;

            _actions.Add("addexp", AddExp);
            _actions.Add("addres", AddResource);
            _actions.Add("additem", AddItem);
            _actions.Add("addunit", AddUnit);
            _actions.Add("ul", UnlockAll);
            _actions.Add("invincible", Invincible);
            _actions.Add("无敌", Invincible);
            _actions.Add("win", Win);
            _actions.Add("buyvip", BuyVIP);
            _actions.Add("juntuandengji", SetLegionLv);
        }

        private const string reason = "GM命令";
        private readonly Dictionary<string, Action<string[]>> _actions = new Dictionary<string, Action<string[]>>();

        private void SetLegionLv(string[] args)
        {
            int lv = int.Parse(args[0]);
            var legionModule = Server.GetModule<LegionModule>();
            var lm = legionModule.QueryLegionMember(Session.PlayerId);
            var legion = legionModule.QueryLegion(lm.LegionId);

            if(legionModule.DLegions.TryGetValue(lv, out var de))
            {
                legion.Level = de.level;
                legion.Exp = de.exp;

                _db.SaveChanges();
            }    
        }        

        private void BuyVIP(string[] args)
        {
            int viplevel = int.Parse(args[0]);
            if (_playerModule.VIP.TryGetValue(viplevel, out var vip))
            {
                _playerModule.BuyVIP(Session.PlayerId, vip);
            }
        }

        private void AddExp(string[] args)
        {
            int exp = int.Parse(args[0]);

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var playerModule = this.Server.GetModule<PlayerModule>();
            playerModule.AddExp(player, exp, reason);
            _db.SaveChanges();
        }

        private void AddResource(string[] args)
        {
            int type = int.Parse(args[0]);
            int cnt = int.Parse(args[1]);

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var playerModule = this.Server.GetModule<PlayerModule>();
            playerModule.AddCurrency(player, type, cnt, reason);
            _db.SaveChanges();
        }

        private void AddItem(string[] args)
        {
            int itemid = int.Parse(args[0]);
            int cnt = int.Parse(args[1]);

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var pkg = this.Server.GetModule<PkgModule>();
            pkg.AddItem(player, itemid, cnt, reason);
            _db.SaveChanges();
        }

        private void AddUnit(string[] args)
        {
            int uid = int.Parse(args[0]);

            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var camp = this.Server.GetModule<CampModule>();
            UnitInfo ui = camp.UnlockUnit(player, uid);

            _db.SaveChanges();
        }

        private void UnlockAll(string[] args)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var camp = this.Server.GetModule<CampModule>();
            foreach (var du in camp.DUnits.Values)
            {
                camp.UnlockUnit(player, du.tid);
            }
            _db.SaveChanges();
        }

        private void Invincible(string[] args)
        {

            var player = _playerModule.QueryPlayer(Session.PlayerId);

            var camp = this.Server.GetModule<CampModule>();
            foreach (var unit in player.Units)
            {
                var du = camp.DUnits[unit.Tid];
                var dugs = camp.DUnitGrades[du.star][du.type];
                var dug = dugs[dugs.Max(d => d.Value.grade)];
                unit.Level = dug.max_level;
                unit.Grade = dug.grade;
                camp.OnUnitLevelUp(new UnitLevelUpEventArgs() { UnitInfo = camp.ToUnitInfo(unit), OldLevel = 1 });
                camp.OnUnitGradeUp(new UnitGradeUpEventArgs() { OldGrade = 0, UnitInfo = camp.ToUnitInfo(unit) });
                foreach (var equip in unit.Equips)
                {
                    DEquip de = camp.DEquips[equip.Tid];
                    var equipMaxLevel = camp.DequipLevels.Count;
                    equip.Level = equipMaxLevel;

                    DEquipGrade deg = camp.DEquipGrades[de.gradeid];
                    while (true)
                    {
                        if (deg.next_id == 0 || !camp.DEquipGrades.ContainsKey(deg.next_id))
                        {
                            equip.GradeId = deg.id;
                            break;
                        }
                        deg = camp.DEquipGrades[deg.next_id];
                    }
                    var ui = camp.ToUnitInfo(unit, du);
                    var equipInfo = new EquipInfo()
                    {
                        grade = equip.GradeId,
                        equipId = equip.Tid,
                        level = equip.Level
                    };
                    camp.OnEquipLevelUp(new EquipLevelUpEventArgs()
                    {
                        EquipInfo = equipInfo,
                        UnitInfo = ui,
                        OldLevel = 1,
                    });
                    camp.OnEquipGradeUp(new EquipGradeUpEventArgs() { EquipInfo = equipInfo, OldGrade = 0, UnitInfo = ui });
                }
                camp.ToUnitInfo(unit, du, true);
            }

            _db.SaveChanges();
        }

        private void Win(string[] args)
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var dc = this.Server.GetModule<DungeonModule>();
            int type = int.Parse(args[0]);
            int sectionIndex = int.Parse(args[1]);
            int missionIndex = int.Parse(args[2]);

            var section = player.Sections.FirstOrDefault(x => x.Type == type);
            if (section == null)
                return;
            var dungeon = section.Dungeons.FirstOrDefault();
            if (dungeon == null)
                return;

            while (section.Index < sectionIndex || (section.Index == sectionIndex && dungeon.Mission <= missionIndex))
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
                var playerModule = this.Server.GetModule<PlayerModule>();

                int costoil = ddungeon.oil_cost;
                int addexp = ddungeon.exp;
                int addunitexp = ddungeon.exp_element;
                //扣体力
                //playerModule.AddCurrency(player, CurrencyType.OIL, -costoil, reason);
                playerModule.AddExp(player, addexp, reason);
                //发放兵种经验
                var campController = this.Server.GetModule<CampModule>();

                campController.GrantUnitExp(player, addunitexp, reason);
                var pkgController = this.Server.GetModule<PkgModule>();

                pkgController.RandomReward(player, ddungeon.random_id, 1, reason);

                if (dungeon.IsLast)
                {
                    section = player.Sections.FirstOrDefault(s => s.Type == type && s.Index == section.Index + 1);
                    if (section == null)
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

        public override int ExecuteCommand()
        {
            String[] strs = Request.action.ToLower().Split(new[] { ',', ' ', '.', '。', '，' });
            string cmd = strs[0];
            string[] args = new string[strs.Length - 1];
            Array.Copy(strs, 1, args, 0, args.Length);
            CheatResponse response = new CheatResponse();
            if (_actions.TryGetValue(cmd, out var action))
            {
                response.success = true;
                response.type = 1;
                action(args);
                Session.SendAsync(response);
            }
            return 0;
        }
    }
}
