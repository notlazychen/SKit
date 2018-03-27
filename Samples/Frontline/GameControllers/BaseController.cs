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

namespace Frontline.GameControllers
{
    public class BaseController : GameController
    {
        private GameDesignContext _designDb;
        private DataContext _db;
        private ILogger _logger;

        public BaseController(DataContext db, GameDesignContext design, ILogger<BaseController> logger)
        {
            _db = db;
            _designDb = design;
            _logger = logger;
        }

        protected override void OnReadGameDesignTables()
        {
        }

        protected override void OnRegisterEvents()
        {
        }
        #region 事件
        #endregion

        #region 辅助方法
        #endregion

        #region 客户端接口
      
        #endregion
    }
}

