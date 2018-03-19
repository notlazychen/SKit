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
        private GameDesignContext _designDb;
        private DataContext _db;

        Dictionary<int, DUnit> _dunits;//tid:x
        Dictionary<int, DUnitLevelUp> _dunitlevels;//level:x
        Dictionary<int, Dictionary<int, DUnitGradeUp>> _dunitgrades;//star:{grade:x}
        Dictionary<int, DUnitUnlock> _dunitunlocks;//tid:x

        public CampController(DataContext db, GameDesignContext design)
        {
            _db = db;
            _designDb = design;
        }

        protected override void OnReadGameDesignTables()
        {
            _dunits = _designDb.DUnits.AsNoTracking().ToDictionary(x => x.tid, x => x);
            _dunitlevels = _designDb.DUnitLevelUps.AsNoTracking().ToDictionary(x => x.level, x => x);
            _dunitgrades = _designDb.DUnitGradeUps.GroupBy(x => x.star).AsNoTracking().ToDictionary(x => x.Key, x => x.ToDictionary(y => y.grade, y => y));
            _dunitunlocks = _designDb.DUnitUnlocks.AsNoTracking().ToDictionary(x => x.tid, x => x);
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
                .Include(p => p.Units)
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
                    Id = Guid.NewGuid().ToString(),
                    PlayerId = e.Id,
                    Tid = uid,
                    Number = 81,
                    Level = 1,
                };
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
        public void AddUnitExp(Player player, Unit unit, int exp, bool usecurrency, bool once, string reason)
        {

            if (unit == null)
            {
                return;
            }
            DUnit du;
            if(!_dunits.TryGetValue(unit.Tid, out du))
            {
                return;
            }
            int grade = unit.Grade == 0 ? 1 : unit.Grade;
            DUnitGradeUp dug = _dunitgrades[du.star][grade];

            int restype = du.type == 2 ? CurrencyType.IRON : CurrencyType.SUPPLY;
            var playerController = this.Server.GetController<PlayerController>();
            while (unit.Level < player.Level && dug.max_level >= unit.Level)
            {
                DUnitLevelUp dul = _dunitlevels[unit.Level];
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
                if(unit.Level < _dunitlevels.Count)
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
        }

        public UnitInfo ToUnitInfo(Unit u, DUnit du = null)
        {
            UnitInfo info = new UnitInfo();
            if (du == null)
            {
                du = _dunits[u.Tid];
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
            //info.power = du.;
            //info.equips = du.equip.Object;

            info.prepareEndTime = u.RestEndTime.ToUnixTime();
            if (du != null)
            {
                info.name = du.name;
                info.type = du.type;
                info.nation = du.nation;
                info.desc = du.desc;
                info.star = du.star;
                info.hp = du.prop_val.Object[2];
                info.att = du.prop_val.Object[0];
                info.defence = du.prop_val.Object[1];
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
                info.hp_growth = du.prop_grow_val.Object[2];
                info.att_growth = du.prop_grow_val.Object[0];
                info.defence_growth = du.prop_grow_val.Object[1];

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
            }

            return info;
        }

        public Unit UnlockUnit(Player player, int uid, bool force = false)
        {
            var unit = player.Units.FirstOrDefault(u => u.Tid == uid);
            if (unit != null)
            {
                return null;
            }

            DUnitUnlock duc = _dunitunlocks[uid];
            DUnit du = _dunits[uid];
            var pkgController = Server.GetController<PkgController>();

            string reason = $"解锁兵种{uid}";
            PlayerItem item = null;
            if (force || pkgController.TrySubItem(player, duc.item_id, duc.item_cnt, reason, out item))
            {
                unit = new Unit()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Level = 1,
                    Number = du.max_energy,
                    Tid = uid,
                };
                player.Units.Add(unit);
                UnlockUnitResponse response = new UnlockUnitResponse();
                response.success = true;
                response.unitId = uid;
                response.unitInfo = this.ToUnitInfo(unit);
                Server.SendByUserNameAsync(player.Id, response);
            }
            return unit;
        }
        #endregion

        #region 客户端接口
        /// <summary>
        /// 获取兵种信息
        /// </summary>
        public void Call_UnitList(UnitListRequest request)
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
        }

        /// <summary>
        /// 获取阵容信息
        /// </summary>
        public void Call_TeamList(TeamRequest request)
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
        }

        /// <summary>
        /// 设置当前阵容
        /// </summary>
        public void Call_SetCurrentTeam(SetCurrentTeamRequest request)
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
        }

        /// <summary>
        /// 查看阵容详情
        /// </summary>
        public void Call_ShowTeam(GetTeamInfoRequest request)
        {
            GetTeamInfoResponse response = new GetTeamInfoResponse();
            response.success = true;
            response.pid = request.pid;
            response.team = new List<TeamPlaceInfo>();
            var player = this.CurrentSession.GetBindPlayer();
            var team = player.Teams.First(t => t.IsSelected);
            for (int i = 0; i < team.Units.Object.Count; i++)
            {
                TeamPlaceInfo info = new TeamPlaceInfo();
                info.place = i;
                var unit = player.Units.First(u => u.Id == team.Units.Object[i]);
                info.unitInfo = this.ToUnitInfo(unit);
                response.team.Add(info);
            }

            CurrentSession.SendAsync(response);
        }

        /// <summary>
        /// 设置阵容
        /// </summary>
        public void Call_SetTeam(TeamSettingRequest request)
        {
            TeamSettingResponse response = new TeamSettingResponse();
            response.success = true;
            response.type = request.type;
            response.tid = request.team.id;
            var player = this.CurrentSession.GetBindPlayer();
            if (request.type == 1)
            {
                var team = player.Teams.First(t => t.Id == request.team.id);
                team.Units = new JsonObject<List<string>>(request.team.bps);
            }
            else
            {
                var team = player.Formations.First(t => t.Id == request.team.id);
                team.Units = new JsonObject<List<string>>(request.team.bps);
            }
            _db.SaveChanges();

            CurrentSession.SendAsync(response);
        }

        /// <summary>
        /// 单位升级
        /// </summary>
        public void Call_LevelupUnit(LevelupUnitRequest request)
        {
            LevelupUnitResponse response = new LevelupUnitResponse();
            response.success = true;
            response.id = request.id;

            var player = this.CurrentSession.GetBindPlayer();
            var unit = player.Units.FirstOrDefault(u => u.Id == request.id);
            int oldLevel = unit.Level;
            string reason = $"兵种[{unit.Tid}]升级";

            this.AddUnitExp(player, unit, 0, true, request.adv, reason);

            if (oldLevel != unit.Level)
            {
                _db.SaveChanges();
                var playerController = this.Server.GetController<PlayerController>();
                response.iron = playerController.GetCurrencyValue(player, CurrencyType.IRON);
                response.supply = playerController.GetCurrencyValue(player, CurrencyType.SUPPLY);
                response.unitInfo = this.ToUnitInfo(unit);
                //Spring.bean(PlayerService.class).TryUpdateMaxPower(u.getPid(), rojo);
                Server.SendByUserNameAsync(player.Id, response);
            }
        }

        /// <summary>
        /// 单位进阶
        /// </summary>
        public void Call_UnitGradeUp(ClazupUnitRequest request)
        {
            ClazupUnitResponse response = new ClazupUnitResponse();
            response.id = request.id;
            var player = CurrentSession.GetBindPlayer();
            Unit unit = player.Units.First(x => x.Id == request.id);


            DUnit du = _dunits[unit.Tid];

            int maxClaz = du.grade_max;
            int itemId = du.grade_item_id;

            if (du.grade_max >= unit.Grade)
            {
                return;
            }
            DUnitGradeUp dug = _dunitgrades[du.star][unit.Grade + 1];
            int itemCount = dug.item_cnt;

            var pkgController = Server.GetController<PkgController>();
            var playerController = Server.GetController<PlayerController>();
            string reason = $"兵种进阶{du.tid}";
            PlayerItem item;
            if (playerController.IsCurrencyEnough(player, CurrencyType.GOLD, dug.gold))
            {
                if (pkgController.TrySubItem(player, itemId, itemCount, reason, out item))
                {
                    playerController.AddCurrency(player, CurrencyType.GOLD, -dug.gold, reason);

                    unit.Grade += 1;

                    response.unitInfo = this.ToUnitInfo(unit, du);
                    response.gold = playerController.GetCurrencyValue(player, CurrencyType.GOLD);
                    response.itemId = itemId;
                    response.count = item.Count;
                    response.success = true;

                    CurrentSession.SendAsync(response);
                    //任务
                    //Spring.bean(PlayerService.class).TryUpdateMaxPower(u.getPid(), rojo);
                    //Spring.bean(QuestService.class).onUnitGradeUp(u.getPid(), u.getUid(), u.getClaz());
                    //Spring.bean(PlayerService.class).TryUpdateMaxPower(u.getPid(), rojo);
                    //Spring.bean(LogService.class).logHeroCount(u.getPid(), u.getUid(), "" + u.getUid(), 3, getUnitPower(rojo, u.getId()));
                }
            }

        }

        /// <summary>
        /// 兵种解锁
        /// </summary>
        public void Call_UnlockUnit(UnlockUnitRequest request)
        {
            var player = this.CurrentSession.GetBindPlayer();
            this.UnlockUnit(player, request.unitId, false);
            _db.SaveChanges();
        }

        public void Call_EquipLevelUp(LevelupEquipRequest request)
        {
            var player = this.CurrentSession.GetBindPlayer();


        }

        public void Call_EquipGradeUp(UpGradeEquipRequest request)
        {

        }
        #endregion
    }
}

