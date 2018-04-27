using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Frontline.GameDesign.Core
{
    class Program
    {
        //const string rootPath = @"E:\COF_WORKSPACE\指挥前线开发版\配置表\";
#if DEBUG
        static string rootPath = @"F:\SwordsMan\指挥前线开发版\配置表";
#else
        static string rootPath = null;
#endif

        static GameDesignContext db { get; set; }

        static void Main(string[] args)
        {
#if DEBUG
            bool import = true;
#else
            bool import = false;
#endif
            if (args.Length != 0)
            {
                rootPath = args[0];
            }
            if (args.Any(a => a == "-a")
                || args.Any(a => a == "-p"))
            {
                import = true;
            }
            db = new GameDesignContext();
            var tool = new TableTool();

            if (import)
            {
                var ms = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.Public);
                MethodInfo mi = ms[0];
                int tables = 0;
                try
                {
                    foreach (var en in tool.Tables)
                    {
                        tables++;
                        string propertyname = en.Value;
                        var property = db.GetType().GetProperties().FirstOrDefault(x => x.Name == propertyname);
                        var method = mi.MakeGenericMethod(new Type[] { property.PropertyType.GetGenericArguments()[0] });
                        var set = property.GetValue(db);
                        method.Invoke(null, new object[] { en.Key, set, null });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("数据表导入全部结束按回车继续");
                Console.ReadLine();
            }
            Console.WriteLine("开始进行数据表关联检查");
            db.CheckFactory();
            db.CheckUnitGrade();
            db.CheckRandom();
            Console.WriteLine("数值表检查结束");
            Console.ReadLine();
        }

        public static void ReadConfigAndWriteToDBAsync<T>(string path, DbSet<T> set, Func<T, bool> check = null)
            where T : class, new()
        {
            //try
            //{
            var property = db.GetType().GetProperties().FirstOrDefault(x => x.PropertyType == typeof(DbSet<T>));
            string tableName = property.Name.ToString();
            string sql = $"truncate table {tableName}";

            Console.WriteLine("[{0}]清空对应数据库表{1}", path, tableName);
            db.Database.ExecuteSqlCommand(sql);

            Console.WriteLine("[{0}]读取表格: {0}", path, tableName);
            var dds = ExcelReader.ReadFromFile<T>(Path.Combine(rootPath, path));
            Console.WriteLine("[{0}]导入数据库表中: {1}", path, tableName);

            //set.AddRange(dds);
            foreach (var dd in dds)
            {
                try
                {
                    //检查ID是否有重复
                    set.Add(dd);
                }catch(Exception)
                {
                    Console.WriteLine("[主键重复]{0}", JsonConvert.SerializeObject(dd));
                }
            }
            db.SaveChanges();
            //}catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private static void ImportRandomNames(GameDesignContext db)
        {
            var nametable = ExcelReader.ReadFromFile<NameTable>(Path.Combine(rootPath, "随机名字配置表.xlsx"));
            var firstNames = nametable.Select(x => x.first_name).Where(n => !string.IsNullOrEmpty(n)).Distinct().ToList();
            var lastNames = nametable.Select(x => x.last_name).Where(n => !string.IsNullOrEmpty(n)).Distinct().ToList();

            var oldnames = db.DName.AsNoTracking().ToDictionary(x => x.Name.ToLower(), x => x.UsedNumber);
            foreach (string f in firstNames)
            {
                foreach (string l in lastNames)
                {
                    string name = $"{f}{l}";
                    string key = name.ToLower();
                    if (!oldnames.ContainsKey(key))
                    {
                        oldnames.Add(key, 0);
                        db.DName.Add(new DName { Name = name, UsedNumber = 0 });
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
