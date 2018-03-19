using Frontline.Data;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using Frontline.GameDesign;
using Frontline.Domain.Temporary;

namespace Frontline.GameControllers
{
    public class DungeonController : GameController
    {
        private GameDesignContext _designDb;
        private DataContext _db;

        List<DDungeon> _ddungeons;
        List<DMonster> _dmonsters;
        List<DMonsterAbility> _dmonsterAbilities;
        List<DMonsterInDungeon> _dmonsterInDungeons;

        public DungeonController(DataContext db, GameDesignContext design)
        {
            _db = db;
            _designDb = design;
        }

        protected override void OnRegisterEvents()
        {
            //事件注册
            var playerController = this.Server.GetController<PlayerController>();
            playerController.PlayerCreating += _PlayerController_PlayerCreating;
            playerController.PlayerLoading += PlayerController_PlayerLoading;

            _ddungeons = _designDb.DDungeons.AsNoTracking().ToList();
            _dmonsters = _designDb.DMonsters.AsNoTracking().ToList();
            _dmonsterAbilities = _designDb.DMonsterAbilities.AsNoTracking().ToList();
            _dmonsterInDungeons = _designDb.DMonsterInDungeons.AsNoTracking().ToList();
        }

        private void PlayerController_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader
                .Include(p => p.Sections)
                .ThenInclude(s => s.Dungeons);
        }

        private void _PlayerController_PlayerCreating(object sender, Domain.Player e)
        {
            //在创建玩家的时候进行副本的初始化操作
            List<DDungeon> dds = _ddungeons.Where(d => d.section == 1 && d.type == 1).ToList();
            Section section = new Section()
            {
                //Id = $"{e.Id}T1S1",
                PlayerId = e.Id,
                Index = 1,
                Type = 1,
                Dungeons = new List<Dungeon>()
            };
            e.Sections.Add(section);
            foreach (var dd in dds)
            {
                var dungeon = this.MakeDungeon(e, dd);
                if (dungeon.Mission == 1)
                    dungeon.IsOpen = true;
                dungeon.PlayerSectionId = section.Id;
                section.Dungeons.Add(dungeon);
            }
        }

        #region 辅助方法
        public Dungeon MakeDungeon(Player p, DDungeon dd)
        {
            Dungeon dungeon = new Dungeon()
            {
                //Id = $"{p.Id}T{dd.type}S{dd.section}M{dd.mission}",
                PlayerId = p.Id,
                Tid = dd.id,
                Type = dd.type,
                Section = dd.section,
                Mission = dd.mission,
                Star = 0,
                FightTimes = 0,
                LastRefreshTime = DateTime.Now,
                Next = dd.next,
                ResetNumb = 0,
                IsLast = dd.next == 0,
            };
            return dungeon;
        }

        public MonsterInfo ToMonsterInfo(int mid, int lv)
        {
            var dm = _dmonsters.Single(m => m.id == mid);
            var dma = _dmonsterAbilities.Single(a => a.level == lv);

            MonsterInfo mi = new MonsterInfo()
            {
                id = mid,
                name = dm.name,
                lv = lv,
                type = dm.type,
                type_detail = dm.type_detail,
                nation = dm.nation,
                desc = dm.desc,
                //hp =  dm.hp,
                //att = dm.att,
                //defence = dm.defence,
                crit = dm.crit,
                crit_hurt = dm.crit_hurt,
                hurt_add = dm.hurt_add,
                hurt_sub = dm.hurt_sub,
                armor = dm.armor,
                hurt_multiple = dm.hurt_multiple,
                cd = dm.cd,
                distance = dm.distance,
                r = dm.r,
                off = dm.off,
                rev = dm.rev,
                rev_body = dm.rev_body,
                speed = dm.speed,
                count = dm.count,
                last_time = dm.last_time,
                bullet_count = dm.bullet_count,
                model = dm.model,
                scale = dm.scale,
                att_effect = dm.att_effect,
                move_effect = dm.move_effect,
                die_model = dm.die_model,
                energy = dm.energy,
                //power = 0,
            };
            if (dm.type == 1)
            {
                mi.hp = (int)(dma.s_hp * (1 + dm.hp / 10000d));
                mi.att = (int)(dma.s_atk * (1 + dm.att / 10000d));
                mi.defence = (int)(dma.s_def * (1 + dm.defence / 10000d));
            }
            else
            {
                mi.hp = (int)(dma.t_hp * (1 + dm.hp / 10000d));
                mi.att = (int)(dma.t_atk * (1 + dm.att / 10000d));
                mi.defence = (int)(dma.t_def * (1 + dm.defence / 10000d));
            }
            return mi;
        }
        #endregion

        #region 通讯接口
        /// <summary>
        /// 章
        /// </summary>
        public void SectionInfo(SectionInfoRequest request)
        {
            var sections = CurrentSession.GetBindPlayer().Sections;
            SectionInfoResponse response = new SectionInfoResponse();
            response.success = true;
            response.id = this.CurrentSession.UserId;
            response.sections = new List<SectionInfo>();
            foreach (var section in sections)
            {
                SectionInfo si = new SectionInfo();
                si.id = section.Index;
                si.type = section.Type;
                si.open = true;
                si.name = "初临战场";
                response.sections.Add(si);
            }

            //var response = JsonConvert.DeserializeObject<SectionInfoResponse>("{\"id\":\"10000f3\",\"sections\":[{\"name\":\"初临战场\",\"id\":1,\"type\":1,\"open\":true},{\"name\":\"初临战场\",\"id\":1,\"type\":2,\"open\":false},{\"name\":\"激烈交战\",\"id\":2,\"type\":1,\"open\":false},{\"name\":\"激烈交战\",\"id\":2,\"type\":2,\"open\":false},{\"name\":\"白色方案\",\"id\":3,\"type\":1,\"open\":false},{\"name\":\"白色方案\",\"id\":3,\"type\":2,\"open\":false},{\"name\":\"闪电战\",\"id\":4,\"type\":1,\"open\":false},{\"name\":\"闪电战\",\"id\":4,\"type\":2,\"open\":false},{\"name\":\"西线战场\",\"id\":5,\"type\":1,\"open\":false},{\"name\":\"西线战场\",\"id\":5,\"type\":2,\"open\":false},{\"name\":\"北非战场\",\"id\":6,\"type\":1,\"open\":false},{\"name\":\"北非战场\",\"id\":6,\"type\":2,\"open\":false},{\"name\":\"巴巴罗萨计划\",\"id\":7,\"type\":1,\"open\":false},{\"name\":\"巴巴罗萨计划\",\"id\":7,\"type\":2,\"open\":false},{\"name\":\"霸王行动\",\"id\":8,\"type\":1,\"open\":false},{\"name\":\"霸王行动\",\"id\":8,\"type\":2,\"open\":false},{\"name\":\"突破包围网\",\"id\":9,\"type\":1,\"open\":false},{\"name\":\"突破包围网\",\"id\":9,\"type\":2,\"open\":false},{\"name\":\"帝国的毁灭\",\"id\":10,\"type\":1,\"open\":false},{\"name\":\"帝国的毁灭\",\"id\":10,\"type\":2,\"open\":false},{\"name\":\"斩首行动\",\"id\":11,\"type\":1,\"open\":false},{\"name\":\"斩首行动\",\"id\":11,\"type\":2,\"open\":false},{\"name\":\"殊死一战\",\"id\":12,\"type\":1,\"open\":false},{\"name\":\"殊死一战\",\"id\":12,\"type\":2,\"open\":false}],\"success\":true}");
            this.CurrentSession.SendAsync(response);
        }

        /// <summary>
        /// 节
        /// </summary>
        public void FbInfo(FBInfoRequest request)
        {
            var sections = CurrentSession.GetBindPlayer().Sections;
            var section = sections.FirstOrDefault(s => s.Index == request.section && s.Type == request.type);
            if (section == null)
            {
                return;
            }
            FBInfoResponse response = new FBInfoResponse();
            response.success = true;
            response.section = request.section;
            response.type = request.type;
            response.fbs = new List<FBInfo>();
            response.receiveds = new List<int>();
            response.id = section.PlayerId;

            List<DDungeon> dds = _ddungeons.Where(d => d.section == section.Index && d.type == section.Type).ToList();
            foreach (var dd in dds)
            {
                var dungeon = section.Dungeons.FirstOrDefault(d => d.Tid == dd.id);
                if (dungeon != null)
                {
                    FBInfo fi = new FBInfo();
                    fi.star = dungeon.Star;
                    fi.fid = dungeon.Id;
                    fi.id = dungeon.Tid;
                    fi.open = dungeon.IsOpen;
                    fi.remainTimes = dd.fight_times - dungeon.FightTimes;
                    fi.type = dd.type;
                    fi.desc = dd.desc;
                    fi.name = dd.name;
                    fi.icon = dd.icon;
                    fi.screen_id = dd.screen_id;
                    fi.level_limit = dd.level_limit;
                    fi.exp = dd.exp;
                    fi.gold = dd.gold;
                    fi.power = dd.power;
                    fi.random_id = dd.random_id;
                    fi.oil_cost = dd.oil_cost;
                    fi.time_limit_1 = dd.time_limit_1;
                    fi.time_limit_2 = dd.time_limit_2;
                    fi.time_limit_3 = dd.time_limit_3;
                    fi.wipe_cost = dd.wipe_cost;
                    fi.map_fighting = dd.map_fighting;
                    fi.map_file_name = dd.map_file_name;
                    fi.map_res_name = dd.map_res_name;
                    fi.dropItems = dd.drop_items.Object;
                    fi.resetRemainNumb = 3 - dungeon.ResetNumb;
                    fi.remainBuyTimes = 0;
                    fi.fight_times = dd.fight_times;

                    response.fbs.Add(fi);
                }
                else
                {
                    //可能是加新副本了,请在此加入添加新副本的代码

                }
            }
            CurrentSession.SendAsync(response);
        }

        /// <summary>
        /// 关卡野怪
        /// </summary>
        /// <param name="request"></param>
        public void MonsterInfo(FBMonsterInfoRequest request)
        {
            if (request.id == null)
            {
                return;
            }
            var player = this.CurrentSession.GetBindPlayer();
            Dungeon dungeon = null;
            foreach (var section in player.Sections)
            {
                foreach (var m in section.Dungeons)
                {
                    if (m.Id == request.id)
                    {
                        dungeon = m;
                        break;
                    }
                }
            }
            if (dungeon == null)
            {
                return;
            }

            List<MonsterInfo> monster = new List<MonsterInfo>();
            var dms = _dmonsterInDungeons.Where(dm => dm.dungeon_id == dungeon.Tid).ToList();

            FBMonsterInfoResponse response = new FBMonsterInfoResponse();
            response.id = dungeon.Id;
            response.success = true;
            response.monster = new List<MonsterInfo>();
            foreach (var dm in dms)
            {
                MonsterInfo mi = this.ToMonsterInfo(dm.mid, dm.level);
                response.monster.Add(mi);
            }
            CurrentSession.SendAsync(response);
        }

        public void FightBegin(FBFightRequest request)
        {
            if (request.id == null)
            {
                return;
            }
            var player = this.CurrentSession.GetBindPlayer();
            Dungeon dungeon = null;
            foreach (var section in player.Sections)
            {
                foreach (var m in section.Dungeons)
                {
                    if (m.Id == request.id)
                    {
                        dungeon = m;
                        break;
                    }
                }
            }
            if (dungeon == null)
            {
                return;
            }
            if (!dungeon.IsOpen)
            {
                return;
            }

            var battle = new Battle()
            {
                Id = Guid.NewGuid().ToString("N"),
                BeginTime = DateTime.Now,
                IsEnd = false,
                Dungeon = dungeon
            };
            this.CurrentSession.SetBind(battle);

            FBFightResponse response = new FBFightResponse();
            response.id = dungeon.Id;
            response.success = true;
            response.token = battle.Id;
            CurrentSession.SendAsync(response);
        }


        readonly static int[][] _stars = new int[][]{
        new int []{3, 3, 3, 3, 3},
        new int []{2, 3, 3, 3, 3},
        new int []{1, 2, 3, 3, 3},
        new int []{1, 2, 2, 3, 3},
        new int []{1, 1, 2, 2, 3}};
        public void FightEnd(FBFightResultRequest request)
        {
            FBFightResultResponse response = new FBFightResultResponse();
            response.success = true;

            Battle battle = this.CurrentSession.GetBind<Battle>();
            if(battle == null)
            {
                return;
            }

            var player = this.CurrentSession.GetBindPlayer();
            Dungeon dungeon = battle.Dungeon;
            DDungeon ddungeon = _ddungeons.First(dd=>dd.id == dungeon.Tid);
            if (request.win)
            {
                string reason = $"副本{ddungeon.id}:{ddungeon.name}战斗胜利";
                dungeon.FightTimes += 1;
                var playerController = this.Server.GetController<PlayerController>();
                playerController.AddCurrency(player, CurrencyType.OIL, -ddungeon.oil_cost, reason);
                playerController.AddExp(player, ddungeon.exp, reason);
                //todo: 发放兵种经验
                var campController = this.Server.GetController<CampController>();
                var team = player.Teams.FirstOrDefault(t=>t.IsSelected);
                if (team != null)
                {
                    foreach(var unit in player.Units.Where(u => team.Units.Object.Contains(u.Id)))
                    {
                        campController.AddUnitExp(player, unit, ddungeon.exp_element, false, true, reason);
                    }
                }
                //副本评星
                int uscnt = 0;
                int living = 0;

                if (request.units != null)
                {
                    foreach (FightUnitInfo u in request.units)
                    {
                        if (string.IsNullOrEmpty(u.unitId))
                        {
                            uscnt += 1;
                            if (!u.dead)
                            {
                                living += 1;
                            }
                        }
                    }
                }

                int star = 1;
                if (living == 0)
                {
                    star = _stars[uscnt - 1][living - 1];
                }
                dungeon.Star = star;
                _db.SaveChanges();
            }
            else
            {
                response.units = null;
            }
            response.id = request.id;
            response.win = request.win;
            response.star = dungeon.Star;
            RewardInfo reward = new RewardInfo();
            response.reward = reward;
            CurrentSession.SendAsync(response);
        }
        #endregion
    }
}
