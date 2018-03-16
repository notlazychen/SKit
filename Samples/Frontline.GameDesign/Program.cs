using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace Frontline.GameDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = "Server=101.132.118.172;database=frontline_design;uid=chenrong;pwd=abcd1234;SslMode=None;charset=utf8;pooling=false";
            string rootPath = @"E:\COF_WORKSPACE\指挥前线开发版\配置表\";

            var options = new DbContextOptionsBuilder().UseMySql(connection).Options;
            GameDesignContext db = new GameDesignContext();

            db.Database.ExecuteSqlCommand("truncate table DItems");
            var items = ExcelReader.ReadFromFile<DItem>(Path.Combine(rootPath, "道具表.xlsx"));
            db.DItems.AddRange(items);
            db.SaveChanges();

            db.Database.ExecuteSqlCommand("truncate table DLevels");
            var levels = ExcelReader.ReadFromFile<DLevel>(Path.Combine(rootPath, "玩家等级表.xlsx"));
            db.DLevels.AddRange(levels);
            db.SaveChanges();

            db.Database.ExecuteSqlCommand("truncate table DMonsters");
            var monsters = ExcelReader.ReadFromFile<DMonster>(Path.Combine(rootPath, "战斗系统——怪物配置表.xlsx"));
            db.DMonsters.AddRange(monsters);
            db.SaveChanges();

            db.Database.ExecuteSqlCommand("truncate table DMonsterAbilities");
            var monsterAbilities = ExcelReader.ReadFromFile<DMonsterAbility>(Path.Combine(rootPath, "战斗系统——怪物能力表.xlsx"));
            db.DMonsterAbilities.AddRange(monsterAbilities);
            db.SaveChanges();

            db.Database.ExecuteSqlCommand("truncate table DMonsterInDungeons");
            var monsterInDungeons = ExcelReader.ReadFromFile<DMonsterInDungeon>(Path.Combine(rootPath, "战斗系统——关卡对应怪物表.xlsx")).Where(m=>m.mid != 0).ToList();
            db.DMonsterInDungeons.AddRange(monsterInDungeons);
            db.SaveChanges();

            db.Database.ExecuteSqlCommand("truncate table DDungeons");
            var dungeons = ExcelReader.ReadFromFile<DDungeon>(Path.Combine(rootPath, "战斗系统——关卡配置表.xlsx"));
            foreach (var d in dungeons)
            {
                try
                {
                    db.DDungeons.Add(d);
                }
                catch (Exception)
                {
                    throw new Exception($"[战斗系统——关卡配置表]中{d.id}:{d.name}配置有误请检查");
                }
            }
            db.SaveChanges();
        }
    }
}
