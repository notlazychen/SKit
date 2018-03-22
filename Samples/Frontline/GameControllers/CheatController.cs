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

namespace Frontline.GameControllers
{
    public class CheatController : GameController
    {
        private GameDesignContext _designDb;
        private DataContext _db;

        public CheatController(DataContext db, GameDesignContext design)
        {
            _db = db;
            _designDb = design;
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
        public void Call_Cheat(CheatRequest request)
        {

        }
        #endregion
    }
}

