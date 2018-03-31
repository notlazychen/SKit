using Frontline.GameDesign;
using Microsoft.Extensions.Logging;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class DesignDataModule : GameModule
    {
        private GameDesignContext _desiongDb;
        private Dictionary<string, Action<GameDesignContext>> _modules = new Dictionary<string, Action<GameDesignContext>>();
        private ILogger _logger;
        public DesignDataModule(GameDesignContext desiongDb, ILogger<DesignDataModule> logger)
        {
            _desiongDb = desiongDb;
            _logger = logger;
        }

        protected override void OnConfigured()
        {
            ReadTables(null);
        }

        public void ReadTables(string moduleName)
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
