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
    public class CampController : GameController
    {
        private readonly GameDesignContext _designDb;
        private readonly DataContext _db;

        public Dictionary<int, DUnit> DUnits { get; private set; }//tid:x
        public Dictionary<int, DUnitLevelUp> DUnitLevels { get; private set; }//level:x
        public Dictionary<int, Dictionary<int, DUnitGradeUp>> DUnitGrades { get; private set; }//star:{grade:x}
        public Dictionary<int, DUnitUnlock> DUnitUnlock { get; private set; }//tid:x

        public Dictionary<int, DEquip> DEquips { get; private set; }//equiptid:x
        public Dictionary<int, DEquipLevelCost> DequipLevels { get; private set; }//level:x
        public Dictionary<int, DEquipGrade> DEquipGrades { get; private set; }//grade_id:x

        public CampController(DataContext db, GameDesignContext design)
        {
            _db = db;
            _designDb = design;
        }

        protected override void OnReadGameDesignTables()
        {
            DUnits = _designDb.DUnits.AsNoTracking().ToDictionary(x => x.tid, x => x);
            DUnitLevels = _designDb.DUnitLevelUps.AsNoTracking().ToDictionary(x => x.level, x => x);
            DUnitGrades = _designDb.DUnitGradeUps.GroupBy(x => x.star).AsNoTracking().ToDictionary(x => x.Key, x => x.ToDictionary(y => y.grade, y => y));
            DUnitUnlock = _designDb.DUnitUnlocks.AsNoTracking().ToDictionary(x => x.tid, x => x);

            DEquips = _designDb.DEquips.AsNoTracking().ToDictionary(x => x.id, x => x);
            DequipLevels = _designDb.DEquipLevelCosts.AsNoTracking().ToDictionary(x => x.level, x => x);
            DEquipGrades = _designDb.DEquipGrades.AsNoTracking().ToDictionary(x => x.id, x => x);
        }

        protected override void OnRegisterEvents()
        {
            //事件注册
            var playerController = this.Server.GetController<PlayerController>();
            playerController.PlayerCreating += PlayerController_PlayerCreating;
            playerController.PlayerLoading += PlayerController_PlayerLoading;
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
        private UnitInfo AddUnitExp(Player player, Unit unit, int exp, bool usecurrency, bool once, string reason)
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
            var playerController = this.Server.GetController<PlayerController>();
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
                        if (!playerController.IsCurrencyEnough(player, restype, left))
                        {
                            break;//用钱，但钱不足
                        }
                        playerController.AddCurrency(player, restype, -left, reason);
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

            //if (true)
            //{
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
            //}
            //return null;
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

        #region 客户端接口
        /// <summary>
        /// 获取兵种信息
        /// </summary>
        public int Call_UnitList(UnitListRequest request)
        {
            UnitListResponse response = new UnitListResponse();
            response.success = true;
            response.pid = CurrentSession.UserId;
            response.units = new List<UnitInfo>();
            var units = this.CurrentSession.GetBindPlayer().Units;
            foreach (var unit in units)
            {
                var u = this.ToUnitInfo(unit);
                response.units.Add(u);
            }
            CurrentSession.SendAsync(response);
            return 0;
        }

        /// <summary>
        /// 获取阵容信息
        /// </summary>
        public int Call_TeamList(TeamRequest request)
        {
            TeamResponse response = new TeamResponse();
            response.success = true;
            response.pid = CurrentSession.UserId;
            response.teams5 = new List<TeamInfo>();
            response.teams10 = new List<TeamInfo>();

            var player = this.CurrentSession.GetBindPlayer();
            foreach (var team in player.Teams)
            {
                TeamInfo ti = new TeamInfo();
                ti.selected = team.IsSelected;
                ti.id = team.Id;
                ti.bps = team.Units.Object;
                response.teams5.Add(ti);
            }
            foreach (var f in player.Formations)
            {
                TeamInfo ti = new TeamInfo();
                ti.selected = f.IsSelected;
                ti.id = f.Id;
                ti.bps = f.Units.Object;
                response.teams10.Add(ti);
            }
            CurrentSession.SendAsync(response);
            return 0;
        }

        /// <summary>
        /// 设置当前阵容
        /// </summary>
        public int Call_SetCurrentTeam(SetCurrentTeamRequest request)
        {
            SetCurrentTeamResponse response = new SetCurrentTeamResponse();
            response.success = true;
            response.type = request.type;
            response.tid = request.tid;

            var player = this.CurrentSession.GetBindPlayer();
            if (request.type == 1)
            {
                foreach (var t in player.Teams)
                {
                    t.IsSelected = t.Id == request.tid;
                }
            }
            else
            {
                foreach (var t in player.Formations)
                {
                    t.IsSelected = t.Id == request.tid;
                }
            }
            _db.SaveChanges();
            CurrentSession.SendAsync(response);
            return 0;
        }

        /// <summary>
        /// 查看阵容详情
        /// </summary>
        public int Call_ShowTeam(GetTeamInfoRequest request)
        {
            GetTeamInfoResponse response = new GetTeamInfoResponse();
            response.success = true;
            response.pid = request.pid;
            response.team = new List<TeamPlaceInfo>();
            string pid = request.pid;
            var playerController = Server.GetController<PlayerController>();
            var other = playerController.QueryPlayer(pid);
            if(other == null)
            {
                return (int)GameErrorCode.查无此人;
            }
            var team = other.Teams.First(t => t.IsSelected);
            for (int i = 0; i < team.Units.Object.Count; i++)
            {
                TeamPlaceInfo info = new TeamPlaceInfo();
                info.place = i;
                string uid = team.Units.Object[i];
                if (!string.IsNullOrEmpty(uid))
                {
                    var unit = other.Units.FirstOrDefault(u => u.Id == uid);
                    if (unit != null)
                    {
                        info.unitInfo = this.ToUnitInfo(unit);
                    }
                }
                response.team.Add(info);
            }

            CurrentSession.SendAsync(response);
            return 0;
        }

        /// <summary>
        /// 设置阵容
        /// </summary>
        public int Call_SetTeam(TeamSettingRequest request)
        {
            TeamSettingResponse response = new TeamSettingResponse();
            response.success = true;
            response.type = request.type;
            response.tid = request.team.id;
            var player = this.CurrentSession.GetBindPlayer();
            //判断是不是自己的兵
            foreach (var id in request.team.bps)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    if (!player.Units.Any(x => x.Id == id))
                    {
                        return (int)GameErrorCode.阵容设置必须是自己的兵种;
                    }
                }
            }
            if (request.type == 1)
            {
                //判断长度
                if (request.team.bps.Count > 5)
                    return (int)GameErrorCode.阵容不能超过五个兵种;
                var team = player.Teams.First(t => t.Id == request.team.id);
                team.Units = new JsonObject<List<string>>(request.team.bps);
                OnTeamSettingChanged(team);
            }
            else
            {
                if (request.team.bps.Count > 10)
                    return (int)GameErrorCode.阵容不能超过十个兵种;

                var team = player.Formations.First(t => t.Id == request.team.id);
                team.Units = new JsonObject<List<string>>(request.team.bps);
            }
            _db.SaveChanges();

            CurrentSession.SendAsync(response);
            return 0;
        }

        /// <summary>
        /// 单位升级
        /// </summary>
        public int Call_LevelupUnit(LevelupUnitRequest request)
        {
            LevelupUnitResponse response = new LevelupUnitResponse();
            response.success = true;
            response.id = request.id;

            var player = this.CurrentSession.GetBindPlayer();
            var unit = player.Units.First(u => u.Id == request.id);
            int oldLevel = unit.Level;
            string reason = $"兵种[{unit.Tid}]升级";

            UnitInfo ui = this.AddUnitExp(player, unit, 0, true, request.adv, reason);

            if (oldLevel != unit.Level)
            {
                _db.SaveChanges();
                var playerController = this.Server.GetController<PlayerController>();
                response.iron = playerController.GetCurrencyValue(player, CurrencyType.IRON);
                response.supply = playerController.GetCurrencyValue(player, CurrencyType.SUPPLY);
                response.unitInfo = ui;
                Server.SendByUserNameAsync(player.Id, response);
            }
            return 0;
        }

        /// <summary>
        /// 单位进阶
        /// </summary>
        public int Call_UnitGradeUp(ClazupUnitRequest request)
        {
            ClazupUnitResponse response = new ClazupUnitResponse();
            response.id = request.id;
            var player = CurrentSession.GetBindPlayer();
            Unit unit = player.Units.First(x => x.Id == request.id);


            DUnit du = DUnits[unit.Tid];

            int maxClaz = du.grade_max;
            int itemId = du.grade_item_id;

            if (unit.Grade >= du.grade_max)
            {
                return (int)GameErrorCode.兵种已经最高阶;
            }
            DUnitGradeUp dug = DUnitGrades[du.star][unit.Grade + 1];
            if (unit.Level < dug.min_level)
            {
                return (int)GameErrorCode.兵种不满足升阶等级; ;
            }
            int itemCount = dug.item_cnt;

            var pkgController = Server.GetController<PkgController>();
            var playerController = Server.GetController<PlayerController>();
            string reason = $"兵种进阶{du.tid}";
            if (playerController.IsCurrencyEnough(player, CurrencyType.GOLD, dug.gold))
            {
                if (pkgController.TrySubItem(player, itemId, itemCount, reason, out var item))
                {
                    playerController.AddCurrency(player, CurrencyType.GOLD, -dug.gold, reason);

                    unit.Grade += 1;

                    response.unitInfo = this.ToUnitInfo(unit, du, true);
                    response.gold = playerController.GetCurrencyValue(player, CurrencyType.GOLD);
                    response.itemId = itemId;
                    response.count = item.Count;
                    response.success = true;

                    _db.SaveChanges();

                    CurrentSession.SendAsync(response);

                    //任务
                    OnUnitGradeUp(new UnitGradeUpEventArgs()
                    {
                        UnitInfo = response.unitInfo,
                        OldGrade = unit.Grade - 1
                    });
                }
            }
            return 0;
        }

        /// <summary>
        /// 兵种解锁
        /// </summary>
        public int Call_UnlockUnit(UnlockUnitRequest request)
        {
            var player = this.CurrentSession.GetBindPlayer();
            int uid = request.unitId;
            DUnitUnlock duc = DUnitUnlock[uid];
            string reason = $"解锁兵种{uid}";
            var pkgController = Server.GetController<PkgController>();
            if (pkgController.TrySubItem(player, duc.item_id, duc.item_cnt, reason, out var item))
            {
                this.UnlockUnit(player, uid);
                _db.SaveChanges();
                return 0;
            }
            else
            {
                return (int)GameErrorCode.道具不足;
            }
        }

        public int Call_EquipLevelUp(LevelupEquipRequest request)
        {
            var player = this.CurrentSession.GetBindPlayer();
            var unit = player.Units.First(u => u.Tid == request.unitId);

            DUnit du = DUnits[unit.Tid];
            var equip = unit.Equips.First(e => e.Pos == request.position);
            var playerController = this.Server.GetController<PlayerController>();
            string reason = $"兵种装备升级{unit.Tid}:{equip.Tid}";
            int oldlevel = equip.Level;
            DEquip de = DEquips[equip.Tid];
            DEquipGrade deg = DEquipGrades[equip.GradeId];
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
                if (!DequipLevels.TryGetValue(equip.Level, out dl))
                {
                    break;
                }
                int rescont = (int)((du.type == 1 ? dl.soldier_gold : dl.tank_gold) * de.level_k / 10000d);
                if (!playerController.IsCurrencyEnough(player, CurrencyType.GOLD, rescont))
                {
                    break;
                }

                playerController.AddCurrency(player, CurrencyType.GOLD, rescont, reason);
                equip.Level += 1;

                if (!request.multy)
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
                unitInfo = this.ToUnitInfo(unit, du, true);
                OnEquipLevelUp(new EquipLevelUpEventArgs()
                {
                    EquipInfo = equipInfo,
                    UnitInfo = unitInfo,
                    OldLevel = oldlevel
                });
                _db.SaveChanges();
            }
            else
            {
                unitInfo = this.ToUnitInfo(unit, du);
            }

            LevelupEquipResponse response = new LevelupEquipResponse();
            response.success = true;
            response.equipInfo = equipInfo;
            response.unitInfo = unitInfo;
            response.position = equip.Pos;
            response.unitId = unit.Tid;
            CurrentSession.SendAsync(response);
            return 0;
        }

        public int Call_EquipGradeUp(UpGradeEquipRequest request)
        {
            var player = this.CurrentSession.GetBindPlayer();
            var unit = player.Units.First(u => u.Tid == request.unitId);
            DUnit du = DUnits[unit.Tid];
            var equip = unit.Equips.First(e => e.Pos == request.position);
            DEquip de = DEquips[equip.Tid];
            DEquipGrade deg = DEquipGrades[equip.GradeId];
            if (deg.next_id == 0)
                return (int)GameErrorCode.装备已经最高阶;
            var pkgController = this.Server.GetController<PkgController>();
            bool itemenough = pkgController.IsItemEnough(player, deg.grade_item_id.Object, deg.grade_item_cnt.Object);
            if (!itemenough)
                return (int)GameErrorCode.道具不足;
            string reason = $"兵种装备进阶{unit.Tid}:{equip.Tid}";
            pkgController.SubItems(player, deg.grade_item_id.Object, deg.grade_item_cnt.Object, reason);

            DEquipGrade degNext = DEquipGrades[deg.next_id];
            equip.GradeId = degNext.id;
            var unitInfo = this.ToUnitInfo(unit, du, true);

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

            OnEquipGradeUp(new EquipGradeUpEventArgs() { EquipInfo = response.equipInfo, OldGrade = deg.grade, UnitInfo = unitInfo });
            CurrentSession.SendAsync(response);
            return 0;
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
        protected virtual void OnTeamSettingChanged(Team e)
        {
            TeamSettingChanged?.Invoke(this, e);
        }
        protected virtual void OnUnitUnlock(UnitInfo e)
        {
            UnitUnlock?.Invoke(this, e);
        }
        #endregion

    }
}

