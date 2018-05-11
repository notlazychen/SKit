using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Text;

namespace Frontline.GameDesign.Core
{
    public static class TableChecker
    {
        public static void CheckDiKang(this GameDesignContext db)
        {
            var dds = db.DDiKangQianXian.ToList();
            var ditems = db.DMonsterInDungeon.ToList();
            foreach (var dd in dds)
            {
                if (!ditems.Any(d=>d.dungeon_id == dd.dungeon_id))
                {
                    Console.WriteLine($"检查<抵抗前线配置表>[id:{dd.wid}]关卡[{dd.dungeon_id}]在<关卡对应怪物表>中缺失");
                }
            }
        }

        public static void CheckMall(this GameDesignContext db)
        {
            var dds = db.DMallShopItem.ToList();
            var ditems = db.DItem.ToDictionary(x=>x.tid, x=>x);
            foreach (var dd in dds)
            {
                if (!ditems.ContainsKey(dd.item_id))
                {
                    Console.WriteLine($"检查<商店商品表>[id:{dd.id}]道具[{dd.item_id}]在<道具表>中缺失");
                }
            }
        }

        public static void CheckFactory(this GameDesignContext db)
        {
            var dt = db.DFacTaskGroup.ToList();
            var dds = db.DFacTask.GroupBy(y => y.group).ToDictionary(z => z.Key, z => z.ToList());
            foreach (var d in dt)
            {
                if (!dds.ContainsKey(d.gourp_supply))
                {
                    Console.WriteLine($"检查<后勤基地-派遣任务分组>[id:{d.id}]的军需工厂分组[{d.gourp_supply}]在<技能表>中缺失");
                }
                if (!dds.ContainsKey(d.group_iron))
                {
                    Console.WriteLine($"检查<后勤基地-派遣任务>[id:{d.id}]的钢铁工厂分组[{d.group_iron}]在<技能表>中缺失");
                }
            }
        }


        /// <summary>
        /// 检查兵种升阶表和兵种属性表
        /// </summary>
        /// <param name="db"></param>
        public static void CheckUnitGrade(this GameDesignContext db)
        {
            var dus = db.DUnit.ToList();
            var dskills = db.DSkill.AsNoTracking().GroupBy(g => g.id).ToDictionary(g => g.Key, g => g.ToDictionary(x => x.lv, x => x));
            foreach (var du in dus)
            {
                foreach(var s in du.skills.Object)
                {
                    if (s != 0 && !dskills.ContainsKey(s))
                    {
                        Console.WriteLine($"检查<兵种属性表>[id:{du.tid}]的技能[{s}]在<技能表>中缺失");
                    }
                }
            }

            //var dugs = db.DUnitGradeUp.ToList();
            //foreach (var du in dus)
            //{
            //    for(int grade = 1; grade <= du.grade_max; grade++)
            //    {
            //        bool ok = dugs
            //            .Any(dug => du.type == dug.type && dug.star == du.star && dug.grade == grade);
            //        if (!ok)
            //        {
            //            Console.WriteLine($"检查兵种[{du.tid}-{du.name}]在<兵种升阶表>中缺少对应 [兵种类型{du.type}_兵种星级{du.star}_兵种升阶{grade}] 的配置");
            //        }
            //    }                
            //}
        }

        /// <summary>
        /// 检查被使用的随机库表
        /// </summary>
        /// <param name="db"></param>
        public static void CheckRandom(this GameDesignContext db)
        {
            //首先检查随机库表中的道具是否都有
            var drs = db.DRandom.ToList();
            var ditems = db.DItem.ToList();
            var ddungeons = db.DDungeon.ToList();
            var dlegionDonates = db.DLegionDonate.ToList();
            var darenaChallengeReward = db.DArenaChallengeReward.ToList();
            foreach (var dr in drs)
            {
                if (dr.type == 2)
                {
                    bool ok = ditems.Any(d => d.tid == dr.tid);
                    if (!ok)
                    {
                        Console.WriteLine($"检查<随机库表>[id:{dr.id}]的道具[{dr.tid}]在<道具表中>中缺失");
                    }
                }
            }

            //接着检查关卡配置表中每一关的随机库id在随机库表中是否存在
            foreach (var dd in ddungeons)
            {
                if (dd.random_id != 0)
                {
                    bool ok = drs.Any(d => d.id == dd.random_id);
                    if (!ok)
                    {
                        Console.WriteLine($"检查<关卡配置表>[id:{dd.id}-{dd.name}]的随机库Id[{dd.random_id}]在<随机库表>中缺失");
                    }
                }
            }

            //检查道具表中的随机库ID
            foreach (var ditem in ditems)
            {
                if (ditem.breakRandomId != 0)
                {
                    bool ok = drs.Any(d => d.id == ditem.breakRandomId);
                    if (!ok)
                    {
                        Console.WriteLine($"检查<道具表>[id:{ditem.tid}-{ditem.name}]的随机库Id[{ditem.breakRandomId}]在<随机库表>中缺失");
                    }
                }
            }

            //检查军团捐献表里的
            foreach (var dd in dlegionDonates)
            {
                if (dd.contri != 0)
                {
                    bool ok = drs.Any(d => d.id == dd.contri);
                    if (!ok)
                    {
                        Console.WriteLine($"检查<军团捐献表>[id:{dd.id}-{dd.name}]的随机库Id[{dd.contri}]在<随机库表>中缺失");
                    }
                }
            }

            //检查竞技场次数奖励
            foreach (var dd in darenaChallengeReward)
            {
                if (dd.random_id != 0)
                {
                    bool ok = drs.Any(d => d.id == dd.random_id);
                    if (!ok)
                    {
                        Console.WriteLine($"检查<夺旗战-次数奖励>[id:{dd.id}]的随机库Id[{dd.random_id}]在<随机库表>中缺失");
                    }
                }
            }

            //检查抵抗前线宝箱奖励
            var dikangs = db.DDiKangQianXianBox.ToList();
            foreach(var box in dikangs)
            {
                bool ok = ditems.Any(item => item.tid == box.box);
                if (!ok)
                {
                    Console.WriteLine($"检查<抵抗前线宝箱>[id:{box.id}]的道具Id[{box.box}]在<道具表>中缺失");
                }
            }
            //抵抗前线奖励在道具表中

            //检查周常宝箱
            var boxes = db.DWeekBox.ToList();
            foreach(var box in boxes)
            {
                bool ok = ditems.Any(item => item.tid == box.item_id);
                if (!ok)
                {
                    Console.WriteLine($"检查<周常挑战-宝箱奖励>[id:{box.id}]的道具Id[{box.item_id}]在<道具表>中缺失");
                }
            }
        }                


    }
}
