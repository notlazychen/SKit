using Frontline.Data;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using Frontline.GameDesign;
using System.Linq;
using SKit.Common.Utils;
using Frontline.Common;

namespace Frontline.Modules
{
    public class RescueModule : GameModule
    {

        private DataContext _db;

        public Dictionary<int, DRescue> DRescues { get; private set; }//diff:x

        private DungeonModule _dungeonModule;
        public RescueModule(DataContext db, GameDesignContext design)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            //事件注册
            var playerModule = this.Server.GetModule<PlayerModule>();
            _dungeonModule = this.Server.GetModule<DungeonModule>();

            var design = Server.GetModule<DesignDataModule>();
            design.Register(this, designDb =>
            {
                DRescues = designDb.DRescue.AsNoTracking().ToDictionary(x => x.diffic, x => x);                
            });
        }


        #region 事件

        #endregion

        #region 辅助方法
        private Dictionary<string, Rescue> _instances = new Dictionary<string, Rescue>();
        public Rescue QueryRescue(string pid)
        {
            if (!_instances.TryGetValue(pid, out var obj))
            {
                obj = _db.Rescues.FirstOrDefault(d => d.PlayerId == pid);
                if (obj == null)
                {
                    obj = new Rescue();
                    obj.PlayerId = pid;
                    obj.LastRefreshTime = DateTime.Now;
                    obj.UseNumb = 0;
                    obj.LastTodayDiff = 0;
                    _db.Rescues.Add(obj);
                    _db.SaveChanges();
                }
                _instances.Add(pid, obj);
            }

            if (obj.LastRefreshTime.Date != DateTime.Today)
            {
                obj.UseNumb = 0;
                obj.LastTodayDiff = 0;
                obj.LastRefreshTime = DateTime.Now;
                _db.SaveChanges();
            }
            return obj;
        }
        #endregion
    }
}
