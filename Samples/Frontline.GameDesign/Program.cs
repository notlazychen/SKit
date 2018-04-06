using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameDesign
{
    class Program
    {
        //const string rootPath = @"E:\COF_WORKSPACE\指挥前线开发版\配置表\";
        const string rootPath = @"F:\SwordsMan\指挥前线开发版\配置表";
        const string connection = "Server=101.132.118.172;database=frontline_design;uid=chenrong;pwd=abcd1234;SslMode=None;charset=utf8;pooling=false";
        private static GameDesignContext db;
        static void Main(string[] args)
        {
            db = new GameDesignContext();

            //ImportRandomNames(db);

            //ReadConfigAndWriteToDB("道具表.xlsx", db.DItems);
            //ReadConfigAndWriteToDB("玩家等级表.xlsx", db.DLevels);
            //ReadConfigAndWriteToDB("战斗系统——怪物配置表.xlsx", db.DMonsters);
            //ReadConfigAndWriteToDB("战斗系统——怪物能力表.xlsx", db.DMonsterAbilities);
            //ReadConfigAndWriteToDB("战斗系统——关卡对应怪物表.xlsx", db.DMonsterInDungeons, d => d.mid != 0);
            //ReadConfigAndWriteToDB("战斗系统——关卡配置表.xlsx", db.DDungeons);
            //ReadConfigAndWriteToDB("兵种属性表.xlsx", db.DUnits);
            //ReadConfigAndWriteToDB("兵种进阶表.xlsx", db.DUnitGradeUps);
            //ReadConfigAndWriteToDB("兵种升级消耗.xlsx", db.DUnitLevelUps);
            //ReadConfigAndWriteToDB("兵种购买表.xlsx", db.DUnitUnlocks);
            //ReadConfigAndWriteToDB("兵种装备表.xlsx", db.DEquips);
            //ReadConfigAndWriteToDB("兵种装备升级消耗.xlsx", db.DEquipLevelCosts);
            //ReadConfigAndWriteToDB("兵种装备升阶表.xlsx", db.DEquipGrades);
            //ReadConfigAndWriteToDB("随机库表.xlsx", db.DRandoms);
            //db.SaveChanges();

            //ReadConfigAndWriteToDB("十连抽-抽奖配置.xlsx", db.DLotteries);
            //ReadConfigAndWriteToDB("十连抽-抽奖ID.xlsx", db.DLotteryGroups);
            //ReadConfigAndWriteToDB("十连抽-奖励库.xlsx", db.DLotteryRands);
            //db.SaveChanges();


            //ReadConfigAndWriteToDB("活动-在线有礼.xlsx", db.DOlRewards);
            //ReadConfigAndWriteToDB("夺旗战-次数奖励.xlsx", db.DArenaChallengeRewards);
            //ReadConfigAndWriteToDB("夺旗战-排行榜奖励.xlsx", db.DArenaRankRewards);

            //ReadConfigAndWriteToDB("副本评星奖励.xlsx", db.DDungeonStars);
            //ReadConfigAndWriteToDB("军团配置表.xlsx", db.DLegions);

            //ReadConfigAndWriteToDB("后勤基地-工人表.xlsx", db.DFacWorkers);
            //ReadConfigAndWriteToDB("后勤基地-派遣任务.xlsx", db.DFacTasks);
            //ReadConfigAndWriteToDB("后勤基地-派遣任务分组.xlsx", db.DFacTaskGroup);
            //ReadConfigAndWriteToDB("VIP特权.xlsx", db.VIPPrivileges);

            //ReadConfigAndWriteToDB("任务系统-每日任务表.xlsx", db.DQuestDailys);
            //ReadConfigAndWriteToDB("任务系统-主线任务表.xlsx", db.DQuests);
            //ReadConfigAndWriteToDB("每日任务活跃度奖励.xlsx", db.DQuestDailyRewards);

            //ReadConfigAndWriteToDB("资源购买表.xlsx", db.DResPrices);

            //ReadConfigAndWriteToDB("抵抗前线宝箱.xlsx", db.DDiKangQianXianBoxs);
            //db.SaveChanges();
            //ReadConfigAndWriteToDB("抵抗前线配置表.xlsx", db.DDiKangQianXians);
            //ReadConfigAndWriteToDB("战斗系统——特殊建筑表.xlsx", db.DDiKangQianXianBuildings);

            //ReadConfigAndWriteToDB("护送运输车关卡配置表.xlsx", db.DTransports);
            db.SaveChanges();

        }

        public static void ReadConfigAndWriteToDB<T>(string path, DbSet<T> set, Func<T, bool> check = null) 
            where T : class, new ()
        {
            var property = db.GetType().GetProperties().FirstOrDefault(x=>x.PropertyType == typeof(DbSet<T>));
            string tableName = property.Name.ToString();
            string sql = $"truncate table {tableName}";
            db.Database.ExecuteSqlCommand(sql);
            var dungeons = ExcelReader.ReadFromFile<T>(Path.Combine(rootPath, path));
            foreach (var d in dungeons)
            {
                if (check != null)
                {
                    if (!check(d))
                    {
                        continue;
                    }
                }
                try
                {
                    set.Add(d);
                }
                catch (Exception ex)
                {
                    throw new Exception($"[{path}]中{JsonConvert.SerializeObject(d)}配置有误请检查", ex);
                }
            }
        }


        private static void ImportRandomNames(GameDesignContext db)
        {
            var nametable = ExcelReader.ReadFromFile<NameTable>(Path.Combine(rootPath, "随机名字配置表.xlsx"));
            var firstNames = nametable.Select(x => x.first_name).Where(n => !string.IsNullOrEmpty(n)).Distinct().ToList();
            var lastNames = nametable.Select(x => x.last_name).Where(n => !string.IsNullOrEmpty(n)).Distinct().ToList();

            var oldnames = db.DNames.AsNoTracking().ToDictionary(x=>x.Name.ToLower(), x=>x.UsedNumber);
            foreach (string f in firstNames)
            {
                foreach (string l in lastNames)
                {
                    string name = $"{f}{l}";
                    string key = name.ToLower();
                    if (!oldnames.ContainsKey(key))
                    {
                        oldnames.Add(key, 0);
                        db.DNames.Add(new DName { Name = name, UsedNumber = 0 });
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
