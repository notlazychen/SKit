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
        /// <summary>
        /// 检查兵种升阶表和兵种属性表
        /// </summary>
        /// <param name="db"></param>
        public static void CheckUnitGrade(this GameDesignContext db)
        {
            var dus = db.DUnit.ToList();
            var dugs = db.DUnitGradeUp.ToList();
            foreach (var du in dus)
            {
                for(int grade = 1; grade <= du.grade_max; grade++)
                {
                    bool ok = dugs
                        .Any(dug => du.type == dug.type && dug.star == du.star && dug.grade == grade);
                    if (!ok)
                    {
                        Console.WriteLine($"检查兵种[{du.name}]在<兵种升阶表>中缺少对应 [兵种类型{du.type}_兵种星级{du.star}_兵种升阶{grade}] 的配置");
                    }
                }                
            }
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
                if (dr.type == 1)
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
                        Console.WriteLine($"检查<关卡配置表>[id:{dd.id}]的随机库Id[{dd.random_id}]在<随机库表>中缺失");
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
                        Console.WriteLine($"检查<道具表>[id:{ditem.tid}]的随机库Id[{ditem.breakRandomId}]在<随机库表>中缺失");
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
                        Console.WriteLine($"检查<军团捐献表>[id:{dd.id}]的随机库Id[{dd.contri}]在<随机库表>中缺失");
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

            //检查抵抗前线奖励
            //抵抗前线奖励在道具表中
        }                


    }
}
