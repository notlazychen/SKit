using Frontline.Common;
using Frontline.GameDesign;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Frontline.Modules
{
    public class DesignDataModule : GameModule
    {
        public GameDesignContext _desiongDb;

        private Dictionary<string, Action<GameDesignContext>> _modules = new Dictionary<string, Action<GameDesignContext>>();
        private ILogger _logger;
        public DesignDataModule(GameDesignContext desiongDb, ILogger<DesignDataModule> logger)
        {
            _desiongDb = desiongDb;
            _logger = logger;
        }

        protected override void OnConfigured()
        {
            //加载固定数值表
            LoadGameConfig();
            LoadTables(null);
        }

        public void LoadGameConfig()
        {
            var type = typeof(GameConfig);
            var fields = type.GetFields().Where(f=>f.IsPublic).ToDictionary(f=>f.Name, f=>f);
            //string strName = string.Join("\n", fields.Select(f => f.Name).ToList());
            //string strValue = string.Join("\n", fields.Select(f => f.GetValue(null)).ToList());
            //XmlDocument xd = new XmlDocument();
            //xd.Load(AppDomain.CurrentDomain.BaseDirectory+"Frontline.Common.xml");
            //XmlNodeList members = xd.DocumentElement.SelectNodes("/doc/members/member");
            //Dictionary<string, string> xml = new Dictionary<string, string>();
            //foreach (XmlNode member in members)
            //{
            //    xml[member.Attributes["name"].InnerText] = member.FirstChild.InnerText.Trim(new[] { '\r', '\n', ' ', '\t' });
            //}
            //string strDesc = string.Join("\n", fields.Select(f => {
            //    string key = $"F:{type.FullName}.{f.Name}";
            //    if (xml.TryGetValue(key, out var desc))
            //    {
            //        return desc;
            //    }
            //    return "";
            //}).ToList());
            var dgameconfig = _desiongDb.DGameConfig.AsNoTracking().ToList();
            foreach (var dc in dgameconfig)
            {
                try
                {
                    if (fields.TryGetValue(dc.field_name, out var field))
                    {
                        if (field.FieldType == typeof(int))
                        {
                            field.SetValue(null, int.Parse(dc.field_value));

                        }
                        else if (field.FieldType == typeof(List<int>))
                        {
                            field.SetValue(null,
                                dc.field_value.Trim(new[] { '[', ']', '{', '}' })
                                .Split(new char[] { ',' })
                                .Select(int.Parse)
                                .ToList());
                        }
                        else if (field.FieldType == typeof(float))
                        {
                            field.SetValue(null, float.Parse(dc.field_value));
                        }
                        else if (field.FieldType == typeof(List<float>))
                        {
                            field.SetValue(null,
                                dc.field_value.Trim(new[] { '[', ']', '{', '}' })
                                .Split(new char[] { ',' })
                                .Select(float.Parse)
                                .ToList());
                        }
                    }
                }catch(Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }

        public void LoadTables(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                foreach(var m in _modules)
                {
                    _logger.LogDebug($"读取模块{m.Key}的配置表");
                    m.Value(_desiongDb);
                }
            }
            else
            {
                if(_modules.TryGetValue(moduleName, out var act))
                {
                    _logger.LogDebug($"读取模块{moduleName}的配置表");
                    act(_desiongDb);
                }
            }
        }        

        public void Register(GameModule module, Action<GameDesignContext> readTables)
        {
            _modules.Add(module.GetType().Name, readTables);
        }
    }
}
