using Frontline.Data;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using SKit.Common.Utils;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using Frontline.GameDesign;
using Frontline.Domain.Temporary;
using Frontline.Common;

namespace Frontline.Modules
{
    public class DungeonController : GameModule
    {
        private readonly DataContext _db;

        public Dictionary<int, Dictionary<int, SortedDictionary<int, DDungeon>>> DDungeons { get; private set; }//type:{section:{mission:x}}
        public Dictionary<int, DMonster> DMonsters { get; private set; }//tid:x
        public Dictionary<int, DMonsterAbility> DMonsterAbilities { get; private set; }//level:x
        public Dictionary<int, Dictionary<int, DMonsterInDungeon>> DMonsterInDungeons { get; private set; }//dungeonid:{monsterid:x}
        public Dictionary<int, Dictionary<int, Dictionary<int, DDungeonStar>>> DDStars { get; private set; }//type:{section : {index : x}}

        private readonly Dictionary<string, Battle> _battles = new Dictionary<string, Battle>();
        private PlayerModule _playerModule;

        public DungeonController(DataContext db)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            //事件注册
            _playerModule = this.Server.GetModule<PlayerModule>();
            _playerModule.PlayerCreating += _PlayerController_PlayerCreating;
            _playerModule.PlayerLoading += PlayerController_PlayerLoading;
            _playerModule.PlayerEverydayRefresh += PlayerController_PlayerEverydayRefresh;
            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DDungeons = designDb.DDungeons.GroupBy(x => x.type).AsNoTracking().ToDictionary(x => x.Key, x => x.GroupBy(y => y.section).ToDictionary(y => y.Key, y => new SortedDictionary<int, DDungeon>(y.ToDictionary(z => z.mission, z => z))));
                DMonsters = designDb.DMonsters.AsNoTracking().ToDictionary(x => x.id, x => x);
                DMonsterAbilities = designDb.DMonsterAbilities.AsNoTracking().ToDictionary(x => x.level, x => x);
                DMonsterInDungeons = designDb.DMonsterInDungeons.GroupBy(x => x.dungeon_id).AsNoTracking().ToDictionary(x => x.Key, x => x.ToDictionary(y => y.mid, y => y));
                DDStars = designDb.DDungeonStars.AsNoTracking().GroupBy(x => x.type).ToDictionary(x => x.Key, x => x.GroupBy(y => y.section).ToDictionary(z => z.Key, z => z.ToDictionary(a => a.index, a => a)));
            });
        }

        private void PlayerController_PlayerEverydayRefresh(object sender, Player e)
        {
            foreach (var s in e.Sections)
            {
                foreach (var d in s.Dungeons)
                {
                    if (d.IsOpen)
                    {
                        d.FightTimes = 0;
                        d.ResetNumb = 0;
                    }
                }
            }
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
            Section section = new Section()
            {
                Id = Guid.NewGuid().ToString("D"),
                PlayerId = e.Id,
                Index = 1,
                Type = 1,
                Dungeons = new List<Dungeon>()
            };
            e.Sections.Add(section);
            var dd = DDungeons[1][1][1];
            var dungeon = this.MakeDungeon(e, dd, section);
            //dungeon.IsOpen = true;
            //dungeon.SectionId = section.Id;
            section.Dungeons.Add(dungeon);
        }

        #region 辅助方法
        public bool CheckPassedSection(Player player, int type, int sectionIndex)
        {
            if (sectionIndex == 0)
            {
                return true;
            }
            var section = player.Sections.FirstOrDefault(s => s.Type == type && s.Index == sectionIndex);
            if (section == null)
            {
                return false;
            }

            var dungeon = section.Dungeons.FirstOrDefault(d => d.IsLast);
            if (dungeon == null)
            {
                return false;
            }
            if (dungeon.Star > 0)
            {
                return true;
            }
            return false;
        }

        public Dungeon MakeDungeon(Player p, DDungeon dd, Section section)
        {
            Dungeon dungeon = new Dungeon()
            {
                Id = Guid.NewGuid().ToString("D"),
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
                IsOpen = true,
                SectionId = section.Id
            };
            return dungeon;
        }

        public MonsterInfo ToMonsterInfo(int mid, int lv)
        {
            var dm = DMonsters[mid];
            var dma = DMonsterAbilities[lv];

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
        public int Call_SectionInfo(SectionInfoRequest request)
        {
            var sections = _playerModule.QueryPlayer(Session.PlayerId).Sections;
            SectionInfoResponse response = new SectionInfoResponse();
            response.success = true;
            response.id = this.Session.PlayerId;
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

            this.Session.SendAsync(response);
            return 0;
        }

        /// <summary>
        /// 节
        /// </summary>
        public int Call_FbInfo(FBInfoRequest request)
        {
            var sections = _playerModule.QueryPlayer(Session.PlayerId).Sections;
            var section = sections.FirstOrDefault(s => s.Index == request.section && s.Type == request.type);
            if (section == null)
            {
                return (int)GameErrorCode.副本章节还未开启;
            }
            FBInfoResponse response = new FBInfoResponse();
            response.success = true;
            response.section = request.section;
            response.type = request.type;
            response.fbs = new List<FBInfo>();
            response.receiveds = section.RecvdStarReward.StringToMany(int.Parse);
            response.id = section.PlayerId;
            if (!DDungeons[section.Type].ContainsKey(section.Index))
            {
                Session.SendAsync(response);
                return 0;
            }
            var dds = DDungeons[section.Type][section.Index].Values;
            foreach (var dd in dds)
            {
                FBInfo fi = new FBInfo();
                fi.id = dd.id;
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
                fi.fight_times = dd.fight_times;
                var dungeon = section.Dungeons.FirstOrDefault(d => d.Tid == dd.id);
                if (dungeon != null)
                {
                    fi.star = dungeon.Star;
                    fi.fid = dungeon.Id;
                    fi.open = dungeon.IsOpen;
                    fi.remainTimes = dd.fight_times - dungeon.FightTimes;
                    fi.resetRemainNumb = 3 - dungeon.ResetNumb;
                }
                response.fbs.Add(fi);
            }
            Session.SendAsync(response);
            return 0;
        }

        /// <summary>
        /// 关卡野怪
        /// </summary>
        /// <param name="request"></param>
        public int Call_MonsterInfo(FBMonsterInfoRequest request)
        {
            if (request.id == null)
            {
                return -1;
            }
            var player = _playerModule.QueryPlayer(Session.PlayerId);
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
                return (int)GameErrorCode.关卡并不存在;
            }

            List<MonsterInfo> monster = new List<MonsterInfo>();
            var dms = DMonsterInDungeons[dungeon.Tid];

            FBMonsterInfoResponse response = new FBMonsterInfoResponse();
            response.id = dungeon.Id;
            response.success = true;
            response.monster = new List<MonsterInfo>();
            foreach (var dm in dms)
            {
                MonsterInfo mi = this.ToMonsterInfo(dm.Key, dm.Value.level);
                response.monster.Add(mi);
            }
            Session.SendAsync(response);
            return 0;
        }

        public int Call_FightBegin(FBFightRequest request)
        {
            if (request.id == null)
            {
                return -1;
            }
            var player = _playerModule.QueryPlayer(Session.PlayerId);
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
                return (int)GameErrorCode.关卡并不存在;
            }
            if (!dungeon.IsOpen)
            {
                return (int)GameErrorCode.关卡尚未开启;
            }
            DDungeon ddungeon = DDungeons[dungeon.Type][dungeon.Section][dungeon.Mission];
            int remain = ddungeon.fight_times - dungeon.FightTimes - 1;
            if (remain < 0)
            {
                return (int)GameErrorCode.副本挑战次数不足;
            }

            var battle = new Battle()
            {
                Id = Guid.NewGuid().ToString("D"),
                BeginTime = DateTime.Now,
                IsEnd = false,
                Dungeon = dungeon,
                PlayerId = player.Id
            };
            _battles[battle.Id] = battle;

            FBFightResponse response = new FBFightResponse();
            response.id = dungeon.Id;
            response.success = true;
            response.token = battle.Id;
            Session.SendAsync(response);
            return 0;
        }


        readonly static int[][] _stars = new int[][]{
        new int []{3, 3, 3, 3, 3},
        new int []{2, 3, 3, 3, 3},
        new int []{1, 2, 3, 3, 3},
        new int []{1, 2, 2, 3, 3},
        new int []{1, 1, 2, 2, 3}};
        public int Call_FightEnd(FBFightResultRequest request)
        {
            if (request.token == null)
            {
                return (int)GameErrorCode.战斗令牌错误或战斗已经失效;
            }
            Battle battle;
            if (!this._battles.TryGetValue(request.token, out battle) || battle.PlayerId != Session.PlayerId || battle.Dungeon.Id != request.id)
            {
                return (int)GameErrorCode.战斗令牌错误或战斗已经失效;
            }
            _battles.Remove(battle.Id);

            FBFightResultResponse response = new FBFightResultResponse();
            response.win = request.win;
            response.id = request.id;
            response.success = true;
            if (request.win)
            {
                var player = _playerModule.QueryPlayer(Session.PlayerId);
                Dungeon dungeon = battle.Dungeon;
                //Dungeon dungeon = player.Sections.Select(x=>x.Dungeons.FirstOrDefault(d=>d.Id == request.id)).First(x=>x != null);
                DDungeon ddungeon = DDungeons[dungeon.Type][dungeon.Section][dungeon.Mission];

                string reason = $"副本{ddungeon.id}:{ddungeon.name}战斗胜利";
                dungeon.FightTimes += 1;
                //副本评星
                int uscnt = 0;
                int living = 0;

                if (request.units != null)
                {
                    foreach (FightUnitInfo u in request.units)
                    {
                        if (u != null && !string.IsNullOrEmpty(u.unitId))
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
                if (living != 0)
                {
                    star = _stars[uscnt - 1][living - 1];
                }

                if (dungeon.Star == 0)//第一次通关
                {

                    if (dungeon.Next != 0)//开启下一关
                    {
                        var ddnext = DDungeons[dungeon.Type][dungeon.Section][dungeon.Mission + 1];
                        var section = player.Sections.First(s => s.Id == dungeon.SectionId);
                        var dnext = this.MakeDungeon(player, ddnext, section);
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
                            var dd = DDungeons[dungeon.Type][secionNext.Index][1];
                            var dnext = this.MakeDungeon(player, dd, secionNext);
                            secionNext.Dungeons.Add(dnext);

                            //检查精英副本是否已经通关上一章
                            bool preExSectionPassed = this.CheckPassedSection(player, 2, dungeon.Section - 1);
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
                                var ddEx = DDungeons[2][secionEx.Index][1];
                                var dnextEx = this.MakeDungeon(player, ddEx, secionEx);
                                secionEx.Dungeons.Add(dnextEx);
                            }
                        }
                        else//精英副本检查普通本是否通关下一章，通关则开启下一章
                        {
                            bool nextNormalSectionPassed = this.CheckPassedSection(player, 1, dungeon.Section + 1);
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
                                var ddEx = DDungeons[2][secionEx.Index][1];
                                var dnextEx = this.MakeDungeon(player, ddEx, secionEx);
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
                playerModule.AddCurrency(player, CurrencyType.OIL, -costoil, reason);
                playerModule.AddExp(player, addexp, reason);
                //发放兵种经验
                var campController = this.Server.GetModule<CampModule>();
                response.units = campController.GrantUnitExp(player, addunitexp, reason);
                var pkgController = this.Server.GetModule<PkgModule>();

                response.reward = pkgController.RandomReward(player, ddungeon.random_id, 1, reason);
                response.reward.exp = ddungeon.exp;
                response.lv = player.Level;
                response.exp = player.Exp;
                response.star = dungeon.Star;

                _db.SaveChanges();

            }
            else
            {
                response.units = null;
            }
            response.id = request.id;
            response.win = request.win;
            Session.SendAsync(response);
            return 0;
        }

        public int Call_RecvStarReward(FBGetStarRewardRequest request)
        {
            DDungeonStar dreward = DDStars[request.type][request.section][request.reward];
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var section = player.Sections.First(s => s.Type == request.type && s.Index == request.section);
            //判断是否已领取
            var recved = section.RecvdStarReward.StringToMany(int.Parse);
            if (recved.Contains(request.reward))
            {
                return (int)GameErrorCode.已领取过此评星奖励;
            }

            int allStar = section.Dungeons.Sum(x => x.Star);
            if (allStar < dreward.star)
            {
                return (int)GameErrorCode.未满足评星需求;
            }

            string reason = $"领取副本评星奖励";
            var playercon = Server.GetModule<PlayerModule>();
            playercon.AddCurrency(player, dreward.res_type, dreward.res_count, reason);
            recved.Add(dreward.index);
            section.RecvdStarReward = recved.ManyToString(x=>x.ToString());
            _db.SaveChanges();
            FBGetStarRewardResponse response = new FBGetStarRewardResponse();
            response.success = true;
            response.diamond = dreward.res_count;
            response.section = section.Index;
            response.type = request.type;
            response.receiveds = recved;
            Session.SendAsync(response);

            return 0;
        }

        public int Call_Wipe(FBWipeRequest request)
        {
            if (request.count <= 0)
                return -1;
            FBWipeResponse response = new FBWipeResponse();
            response.rewards = new List<RewardInfo>();
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            Dungeon dungeon = null;
            foreach (var section in player.Sections)
            {
                foreach (var d in section.Dungeons)
                {
                    if (d.Id == request.id)
                    {
                        dungeon = d;
                        break;
                    }
                }
            }
            if (dungeon == null)
            {
                return (int)GameErrorCode.副本章节还未开启;
            }

            if (dungeon.Star < 3)//必须是曾经战胜过的
            {
                return (int)GameErrorCode.副本三星才能扫荡;
            }
            DDungeon df = DDungeons[dungeon.Type][dungeon.Section][dungeon.Mission];
            int remain = df.fight_times - dungeon.FightTimes - request.count;
            if (remain < 0)
            {
                return (int)GameErrorCode.副本挑战次数不足;
            }
            var playercon = Server.GetModule<PlayerModule>();
            if (!playercon.IsCurrencyEnough(player, CurrencyType.OIL, df.oil_cost))
            {
                return (int)GameErrorCode.体力不足;
            }

            string reason = $"副本{df.id}:{df.name}扫荡";

            //派发奖励
            var playerModule = this.Server.GetModule<PlayerModule>();

            int costoil = df.oil_cost * request.count;
            int addexp = df.exp * request.count;
            int addunitexp = df.exp_element * request.count;
            //扣体力
            playerModule.AddCurrency(player, CurrencyType.OIL, -costoil, reason);
            playerModule.AddExp(player, addexp, reason);
            //发放兵种经验
            var campController = this.Server.GetModule<CampModule>();
            response.units = campController.GrantUnitExp(player, addunitexp, reason);
            var pkgController = this.Server.GetModule<PkgModule>();

            for (int i = 0; i < request.count; i++)
            {
                RewardInfo reward = pkgController.RandomReward(player, df.random_id, 1, reason);
                reward.exp = df.exp;
                response.rewards.Add(reward);
            }
            dungeon.FightTimes += request.count;
            _db.SaveChanges();

            response.success = true;
            response.id = request.id;
            response.count = request.count;
            Session.SendAsync(response);

            return 0;
        }

        public int Call_Reset(FBResetRequest request)
        {
            FBResetResponse response = new FBResetResponse();
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            Dungeon dungeon = null;
            foreach (var section in player.Sections)
            {
                foreach (var d in section.Dungeons)
                {
                    if (d.Id == request.fid)
                    {
                        dungeon = d;
                        break;
                    }
                }
            }
            if (dungeon == null)
            {
                return (int)GameErrorCode.副本章节还未开启;
            }


            int remain = GameConfig.DungeonResetCount - dungeon.ResetNumb;
            if (remain <= 0)
            {
                return (int)GameErrorCode.副本重置次数不足;
            }

            var playercon = Server.GetModule<PlayerModule>();

            int[] prices = GameConfig.DungeonResetCostDiamond;

            int price = prices.Length > dungeon.ResetNumb ? prices[dungeon.ResetNumb] : prices[prices.Length - 1];
            if (!playercon.IsCurrencyEnough(player, CurrencyType.DIAMOND, price))
            {
                return (int)GameErrorCode.资源不足;
            }
            dungeon.FightTimes = 0;
            dungeon.ResetNumb++;

            _db.SaveChanges();

            response.success = true;
            response.diamond = player.Wallet.DIAMOND;
            response.fid = dungeon.Id;
            response.fight_times = DDungeons[dungeon.Type][dungeon.Section][dungeon.Mission].fight_times;
            response.remainNumb = remain - 1;

            Session.SendAsync(response);
            return 0;
        }
        #endregion
    }
}
