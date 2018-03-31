using Frontline.Data;
using Frontline.GameDesign;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using SKit.Common.Utils;
using Frontline.Common;
using Microsoft.Extensions.Logging;

namespace Frontline.Modules
{
    public class BaseModule : GameModule
    {
        
        private DataContext _db;
        private ILogger _logger;

        public BaseModule(DataContext db, GameDesignContext design, ILogger<BaseModule> logger)
        {
            _db = db;
            _logger = logger;
        }

        protected override void OnConfiguringModules()
        {
        }

        #region 事件
        #endregion

        #region 辅助方法
        #endregion
        
    }
}

