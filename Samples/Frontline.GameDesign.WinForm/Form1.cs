using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Frontline.GameDesign;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Frontline.GameDesign.WinForm
{
    public partial class Form1 : Form
    {
        TableTool tool = new TableTool();

        public Form1()
        {
            InitializeComponent();

            if (File.Exists("db.ini"))
            {
                string path = File.ReadAllText("db.ini", Encoding.UTF8);
                textBoxRootPath.Text = path;
            }

            var items = tool.Tables.Keys;
            foreach (var item in items)
            {
                checkedListBox1.Items.Add(item);
            }
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void buttonImprotDb_Click(object sender, EventArgs e)
        {
            int selectedcount = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))//先判断是否被选中
                {
                    selectedcount++;
                }
            }
            if (selectedcount == 0)
                return;
            log($"{DateTime.Now.ToShortTimeString() }开始-----------------------------");
            MethodInfo miReader = typeof(ExcelReader).GetMethods(BindingFlags.Static | BindingFlags.Public)[0];
            string connStr = "Server=140.143.28.95;database=frontline_design;uid=chenrong;pwd=abcd1234;SslMode=None;charset=utf8;pooling=false";

            //MethodInfo miWriter = typeof(DapperExtensions.DapperExtensions).GetMethods(BindingFlags.Static | BindingFlags.Public)
            //    .FirstOrDefault(m=>m.Name == "Insert" && m.GetParameters().Any(p=>p.ParameterType.GetInterface("IEnumerable") != null));
            using (IDbConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))//先判断是否被选中
                    {
                        string text = checkedListBox1.Items[i] as string;
                        string path = Path.Combine(textBoxRootPath.Text, text);
                        log("<<{0}", text);
                        ;
                        var className = tool.Tables[text];                        
                        conn.Execute($"truncate table {className}");
                        Type classType = Assembly.Load("Frontline.GameDesign").GetType("Frontline.GameDesign." + className);

                        var method = miReader.MakeGenericMethod(new Type[] { classType });
                        var list = method.Invoke(null, new object[] { path });

                        //var methodWriter = miWriter.MakeGenericMethod(new Type[] { classType});
                        //methodWriter.Invoke(null, new object[] { conn, list, null, null });
                        string sql = this.ToInsertSQL(classType);
                        conn.Execute(sql, list);

                        conn.Query(,)
                    }
                }
            }
            log($"{DateTime.Now.ToShortTimeString() }导入结束-----------------------------");
        }

        private string ToInsertSQL(Type type)
        {
            string tablename = type.Name;
            var properties = type.GetProperties().Select(p=>p.Name);
            string valueNames = string.Join(",", properties.Select(p=> $"`{p}`"));
            string values = string.Join(",", properties.Select(p=> $"@{p}"));
            string sql = $"insert into {tablename} ({valueNames}) values({values})";
            return sql;
        }

        private void log(string format, params object[] args)
        {
            string str = string.Format(format, args);
            listBoxLog.Items.Add(str);
        }

        public void ReadConfigAndWriteToDB<T>(IDbConnection db, string path, string tableName, List<T> set, Func<T, bool> check = null)
           where T : class, new()
        {
            string sql = $"truncate table {tableName}";
            db.Execute(sql);

            var dungeons = ExcelReader.ReadFromFile<T>(Path.Combine(textBoxRootPath.Text, path));
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

        private void buttonCheckShips_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpenDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择根文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                textBoxRootPath.Text = foldPath;
                File.WriteAllText("db.ini", foldPath, Encoding.UTF8);
            }
        }
    }
}
