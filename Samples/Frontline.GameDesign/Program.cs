using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Frontline.GameDesign
{
    class Program
    {
        const string rootPath = @"E:\COF_WORKSPACE\指挥前线开发版\配置表\";
        //const string rootPath = @"F:\SwordsMan\指挥前线开发版\配置表";
        const string connection = "Server=101.132.118.172;database=frontline_design;uid=chenrong;pwd=abcd1234;SslMode=None;charset=utf8;pooling=false";
        private static GameDesignContext db;
        static void Main(string[] args)
        {
            //var options = new DbContextOptionsBuilder().UseMySql(connection).Options;
            db = new GameDesignContext();

            ReadConfigAndWriteToDB("道具表.xlsx", db.DItems);
            ReadConfigAndWriteToDB("玩家等级表.xlsx", db.DLevels);
            ReadConfigAndWriteToDB("战斗系统——怪物配置表.xlsx", db.DMonsters);
            ReadConfigAndWriteToDB("战斗系统——怪物能力表.xlsx", db.DMonsterAbilities);
            ReadConfigAndWriteToDB("战斗系统——关卡对应怪物表.xlsx", db.DMonsterInDungeons, d => d.mid != 0);
            ReadConfigAndWriteToDB("战斗系统——关卡配置表.xlsx", db.DDungeons);
            ReadConfigAndWriteToDB("兵种属性表.xlsx", db.DUnits);
            ReadConfigAndWriteToDB("兵种进阶表.xlsx", db.DUnitGradeUps);
            ReadConfigAndWriteToDB("兵种升级消耗.xlsx", db.DUnitLevelUps);
            ReadConfigAndWriteToDB("兵种购买表.xlsx", db.DUnitUnlocks);
            ReadConfigAndWriteToDB("兵种装备表.xlsx", db.DEquips);
            ReadConfigAndWriteToDB("兵种装备升级消耗.xlsx", db.DEquipLevelCosts);
            ReadConfigAndWriteToDB("兵种装备升阶表.xlsx", db.DEquipGrades);
            ReadConfigAndWriteToDB("随机库表.xlsx", db.DRandoms);
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
    }
}
