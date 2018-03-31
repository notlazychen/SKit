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

namespace Frontline.Modules
{
    public class CampModule : GameModule
    {
        private readonly DataContext _db;

        public Dictionary<int, DUnit> DUnits { get; private set; }//tid:x
        public Dictionary<int, DUnitLevelUp> DUnitLevels { get; private set; }//level:x
        public Dictionary<int, Dictionary<int, DUnitGradeUp>> DUnitGrades { get; private set; }//star:{grade:x}
        public Dictionary<int, DUnitUnlock> DUnitUnlock { get; private set; }//tid:x

        public Dictionary<int, DEquip> DEquips { get; private set; }//equiptid:x
        public Dictionary<int, DEquipLevelCost> DequipLevels { get; private set; }//level:x
        public Dictionary<int, DEquipGrade> DEquipGrades { get; private set; }//grade_id:x

        public CampModule(DataContext db)
        {
            _db = db;
        }
        
        protected override void OnConfiguringModules()
        {
            //事件注册
            var playerModule = this.Server.GetModule<PlayerModule>();
            playerModule.PlayerCreating += PlayerController_PlayerCreating;
            playerModule.PlayerLoading += PlayerController_PlayerLoading;

            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DUnits = designDb.DUnits.AsNoTracking().ToDictionary(x => x.tid, x => x);
                DUnitLevels = designDb.DUnitLevelUps.AsNoTracking().ToDictionary(x => x.level, x => x);
                DUnitGrades = designDb.DUnitGradeUps.GroupBy(x => x.star).AsNoTracking().ToDictionary(x => x.Key, x => x.ToDictionary(y => y.grade, y => y));
                DUnitUnlock = designDb.DUnitUnlocks.AsNoTracking().ToDictionary(x => x.tid, x => x);

                DEquips = designDb.DEquips.AsNoTracking().ToDictionary(x => x.id, x => x);
                DequipLevels = designDb.DEquipLevelCosts.AsNoTracking().ToDictionary(x => x.level, x => x);
                DEquipGrades = designDb.DEquipGrades.AsNoTracking().ToDictionary(x => x.id, x => x);
            });
        }

        private void PlayerController_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader
                .Include(p => p.Units).ThenInclude(u => u.Equips)
                .Include(p => p.Teams)
                .Include(p => p.Formations);
        }

        private void PlayerController_PlayerCreating(object sender, Player e)
        {
            int[] uus = new int[] { 21140101 };
            for (int i = 0; i < uus.Length; i++)
            {
                int uid = uus[i];

                Unit unit = new Unit()
                {
                    Id = Guid.NewGuid().ToString("D"),
                    PlayerId = e.Id,
                    Tid = uid,
                    Number = 81,
                    Level = 1,
                    Equips = new List<Equip>()
                };

                DUnit du = DUnits[uid];
                foreach (int deid in du.equip.Object)
                {
                    DEquip de = DEquips[deid];
                    Equip eq = new Equip()
                    {
                        Id = Guid.NewGuid().ToString("D"),
                        Level = 1,
                        GradeId = de.gradeid,
                        PlayerId = e.Id,
                        Pos = de.pos,
                        Tid = deid,
                        UnitId = unit.Id
                    };
                    unit.Equips.Add(eq);
                }
                var unitInfo = this.ToUnitInfo(unit, du, true);
                e.Units.Add(unit);
            }

            for (int i = 0; i < 2; i++)
            {
                List<string> us = new List<string>();
                if (i == 0)
                {
                    int j = 0;
                    foreach (var unit in e.Units)
                    {
                        us.Add(unit.Id);
                        j++;
                    }

                    for (; j < 5; j++)
                    {
                        us.Add(string.Empty);
                    }

                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        us.Add(string.Empty);
                    }
                }
                Team t = new Team()
                {
                    Index = i,
                    IsSelected = i == 0,
                    PlayerId = e.Id,
                    Units = us
                };
                e.Teams.Add(t);
            }

            for (int i = 0; i < 3; i++)
            {
                List<string> us = new List<string>();
                for (int j = 0; j < 10; j++)
                {
                    us.Add(string.Empty);
                }
                PVPFormation t = new PVPFormation()
                {
                    Index = i,
                    IsSelected = i == 0,
                    PlayerId = e.Id,
                    Units = us
                };
                e.Formations.Add(t);
            }
        }


        #region 辅助方法
        public UnitInfo AddUnitExp(Player player, Unit unit, int exp, bool usecurrency, bool once, string reason)
        {
            DUnit du;
            if (!DUnits.TryGetValue(unit.Tid, out du))
            {
                return null;
            }
            int grade = unit.Grade == 0 ? 1 : unit.Grade;
            DUnitGradeUp dug = DUnitGrades[du.star][grade];
            int oldlevel = unit.Level;
            int restype = du.type == 2 ? CurrencyType.IRON : CurrencyType.SUPPLY;
            var playerModule = this.Server.GetModule<PlayerModule>();
            while (unit.Level < player.Level && dug.max_level >= unit.Level)
            {
                DUnitLevelUp dul = DUnitLevels[unit.Level];
                int costExp = 0;
                switch (du.star)
                {
                    case 1:
                        costExp = dul.star1;
                        break;
                    case 2:
                        costExp = dul.star2;
                        break;
                    case 3:
                        costExp = dul.star3;
                        break;
                    case 4:
                        costExp = dul.star4;
                        break;
                    case 5:
                        costExp = dul.star5;
                        break;
                }
                unit.Exp += exp;
                if (unit.Exp < costExp)
                {
                    if (usecurrency)
                    {
                        int left = costExp - unit.Exp;
                        //判断资源是否足够
                        if (!playerModule.IsCurrencyEnough(player, restype, left))
                        {
                            break;//用钱，但钱不足
                        }
                        playerModule.AddCurrency(player, restype, -left, reason);
                        unit.Exp = costExp;
                    }
                    else
                    {
                        break;//不用钱，经验不足
                    }
                }
                if (unit.Level < DUnitLevels.Count)
                {
                    unit.Level += 1;
                }
                else
                {
                    unit.Exp = costExp;
                }
                //Spring.bean(QuestService.class).onUnitLvUp(u.getPid(), u.getUid(), u.getLevel());
                if (usecurrency && !once)
                {
                    break;
                }
            }

            if (oldlevel != unit.Level)
            {
                UnitInfo ui = this.ToUnitInfo(unit, du, true);

                OnUnitLevelUp(new UnitLevelUpEventArgs()
                {
                    UnitInfo = ui,
                    OldLevel = oldlevel
                });
                return ui;
            }
            else
            {
                return this.ToUnitInfo(unit, du); ;
            }
        }

        public UnitInfo ToUnitInfo(Unit u, DUnit du = null, bool calcPower = false)
        {
            UnitInfo info = new UnitInfo();
            if (du == null)
            {
                du = DUnits[u.Tid];
            }
            info.id = u.Id;
            info.number = u.Number;
            info.tid = u.Tid;
            info.exp = u.Exp;
            info.level = u.Level;
            info.claz = u.Grade;
            info.pid = u.PlayerId;

            if (u.IsResting && u.RestEndTime <= DateTime.Now)
            {
                u.IsResting = false;
                u.Number = du.max_energy;
                //推送
                TimesUpNotify notify = new TimesUpNotify();
                notify.id = u.Tid;
                notify.lv = u.Number;
                notify.unitid = u.Id;
                notify.success = true;
                notify.type = GameConfig.TYPE_UNITREST;
                this.Server.SendByUserNameAsync(u.PlayerId, notify);
            }
            info.prepareEndTime = u.RestEndTime.ToUnixTime();
            info.preparing = u.IsResting;
            info.equips = new List<EquipInfo>();


            info.prepareEndTime = u.RestEndTime.ToUnixTime();
            if (du != null)
            {
                info.name = du.name;
                info.type = du.type;
                info.nation = du.nation;
                info.desc = du.desc;
                info.star = du.star;

                info.crit = du.crit;
                info.crit_hurt = du.crit_hurt;
                info.hurt_add = du.hurt_add;
                info.hurt_sub = du.hurt_sub;
                info.crit_v = du.crit_v;
                info.hurt_add_v = du.hurt_add_v;
                info.hurt_sub_v = du.hurt_sub_v;
                info.armor = du.armor;
                info.hurt_multiple = du.hurt_multiple;
                info.cd = du.cd;
                info.distance = du.distance;
                info.r = du.r;
                info.off = du.off;
                info.rev = du.rev;
                info.rev_body = du.rev_body;
                info.speed = du.speed;
                info.mob = du.mob;
                info.hp_add = du.hp_add;
                info.att_add = du.att_add;
                info.def_add = du.def_add;

                info.type_detail = du.type_detail;
                info.levelLimit = 0;
                info.gain = null;
                info.count = du.count;
                info.last_time = du.last_time;
                info.bullet_count = du.bullet_count;
                info.rank = 0;
                info.exist = du.exist;
                info.energy = du.energy;
                for (int i = 0; i < du.res_type.Object.Length; i++)
                {
                    switch (du.res_type.Object[i])
                    {
                        case CurrencyType.GOLD:
                            info.gold = du.res_cnt.Object[i];
                            break;
                        case CurrencyType.SUPPLY:
                            info.supply = du.res_cnt.Object[i];
                            break;
                        case CurrencyType.IRON:
                            info.iron = du.res_cnt.Object[i];
                            break;
                    }
                }
                info.pvp_point = du.pvp_point;
                info.pvp_dec_score = du.pvp_dec_score;
                info.max_energy = du.max_energy;
                info.unitSkills = du.skills.Object;
                //info.hp_ex = du.hp_add;
                //info.att_ex = ;
                //info.def_ex = ;

                //todo: 计算兵种属性和战力
                info.hp = (int)du.prop_val.Object[2];
                info.att = (int)du.prop_val.Object[0];
                info.defence = (int)du.prop_val.Object[1];

                info.hp_growth = du.prop_grow_val.Object[2];
                info.att_growth = du.prop_grow_val.Object[0];
                info.defence_growth = du.prop_grow_val.Object[1];

                //等级加成
                info.hp = (int)(info.hp + info.hp_growth * u.Level);
                info.defence = (int)(info.defence + info.defence_growth * u.Level);
                info.att = (int)(info.att + info.att_growth * u.Level);
                //进阶加成
                if (u.Grade > 0)
                {
                    DUnitGradeUp dug = DUnitGrades[du.star][u.Grade];

                    info.att += (int)((du.prop_val.Object[0] + (100 - 1) * du.prop_grow_val.Object[0]) * dug.atk / 10000d);
                    info.defence += (int)((du.prop_val.Object[1] + (100 - 1) * du.prop_grow_val.Object[1]) * dug.defence / 10000d);
                    info.hp += (int)((du.prop_val.Object[2] + (100 - 1) * du.prop_grow_val.Object[2]) * dug.hp / 10000d);
                }
                //装备加成
                foreach (var eq in u.Equips)
                {
                    DEquip de = DEquips[eq.Tid];
                    DEquipGrade deg = DEquipGrades[eq.GradeId];
                    var ei = new EquipInfo();
                    ei.grade = eq.GradeId;
                    ei.equipId = eq.Tid;
                    ei.level = eq.Level;
                    info.equips.Add(ei);

                    int v = de.base_attr_value + de.level_grow * (eq.Level - 1);
                    //升阶增加的属性 =（基础属性 +（100 - 1）*成长属性）*（升阶增加属性万分比）
                    v += (int)((de.base_attr_value + (100 - 1) * de.level_grow) * deg.grade_grow / 10000d);
                    switch (de.base_attr_type)
                    {
                        case 1:
                            {
                                info.att += v;
                            }
                            break;
                        case 2:
                            {
                                info.defence += v;
                            }
                            break;
                        case 3:
                            {
                                info.hp += v;
                            }
                            break;
                    }
                }
                //战力计算
                if (calcPower)
                {
                    info.power = CalcPower(info);
                    u.Power = info.power;
                }
                else
                {
                    info.power = u.Power;
                }

            }

            return info;
        }

        public int CalcPower(UnitInfo info)
        {
            //B的最终战斗力 = B的生命 /（1 - B的防御 /（B的防御 + A的攻击））+B的攻击 *（B的攻击 /（B的攻击 + A的防御））*战斗回合数N + B的防御 * 防御系数M，战斗回合数N和防御系数M最好从表里读取，方便调整。
            //B为需要计算战斗力的单位，A为标准模型，标准模型A只有两个属性：攻击和防御，需要从表里读取（方便调整）
            //如果不能读表：   战斗回合数 = 5，防御系数M = 0.3，    标准单位的攻击 = 276，防御 = 276
            return info.power = (int)(info.hp / (1d - info.defence / (info.defence + GameConfig.BASE_ATK)) + info.att * (info.att / (info.att + GameConfig.BASE_DEF)) * GameConfig.BASE_ROUND + info.defence * GameConfig.BASE_DEF_K);
        }

        public UnitInfo UnlockUnit(Player player, int uid)
        {
            var unit = player.Units.FirstOrDefault(u => u.Tid == uid);
            if (unit != null)
            {
                return null;
            }

            DUnit du = DUnits[uid];
            
            unit = new Unit()
            {
                Id = Guid.NewGuid().ToString("D"),
                Level = 1,
                Number = du.max_energy,
                Tid = uid,
                Equips = new List<Equip>()
            };
            foreach (int deid in du.equip.Object)
            {
                DEquip de = DEquips[deid];
                Equip eq = new Equip()
                {
                    Id = Guid.NewGuid().ToString("D"),
                    Level = 1,
                    GradeId = de.gradeid,
                    PlayerId = player.Id,
                    Pos = de.pos,
                    Tid = deid,
                    UnitId = unit.Id
                };
                unit.Equips.Add(eq);
            }
            player.Units.Add(unit);

            var unitInfo = this.ToUnitInfo(unit);
            OnUnitUnlock(unitInfo);

            UnlockUnitResponse response = new UnlockUnitResponse
            {
                success = true,
                unitId = uid,
                unitInfo = unitInfo
            };
            Server.SendByUserNameAsync(player.Id, response);

            return unitInfo;
        }

        public List<UnitInfo> GetCurrentTeamUnitInfos(Player player)
        {
            var team = player.Teams.First(x => x.IsSelected);
            var uids = team.Units.Object.Where(uid => !string.IsNullOrEmpty(uid)).ToList();
            var us = player.Units.Where(u => uids.Contains(u.Id)).Select(u => ToUnitInfo(u)).ToList();
            return us;
        }

        public List<UnitInfo> GrantUnitExp(Player player, int addunitexp, string reason)
        {
            List<UnitInfo> units = new List<UnitInfo>();
            var team = player.Teams.FirstOrDefault(t => t.IsSelected);
            if (team != null)
            {
                foreach (var unit in player.Units.Where(u => team.Units.Object.Contains(u.Id)))
                {
                    UnitInfo ui = this.AddUnitExp(player, unit, addunitexp, false, true, reason);
                    units.Add(ui);
                }
            }
            return units;
        }
        #endregion


        #region 事件
        public event EventHandler<UnitInfo> UnitUnlock;
        public event EventHandler<UnitLevelUpEventArgs> UnitLevelUp;
        public event EventHandler<UnitGradeUpEventArgs> UnitGradeUp;
        public event EventHandler<EquipLevelUpEventArgs> EquipLevelUp;
        public event EventHandler<EquipGradeUpEventArgs> EquipGradeUp;
        public event EventHandler<Team> TeamSettingChanged;

        public virtual void OnUnitLevelUp(UnitLevelUpEventArgs e)
        {
            UnitLevelUp?.Invoke(this, e);
        }

        public virtual void OnUnitGradeUp(UnitGradeUpEventArgs e)
        {
            UnitGradeUp?.Invoke(this, e);
        }
        public virtual void OnEquipLevelUp(EquipLevelUpEventArgs e)
        {
            EquipLevelUp?.Invoke(this, e);
        }

        public virtual void OnEquipGradeUp(EquipGradeUpEventArgs e)
        {
            EquipGradeUp?.Invoke(this, e);
        }
        public virtual void OnTeamSettingChanged(Team e)
        {
            TeamSettingChanged?.Invoke(this, e);
        }
        public virtual void OnUnitUnlock(UnitInfo e)
        {
            UnitUnlock?.Invoke(this, e);
        }
        #endregion

    }
}

