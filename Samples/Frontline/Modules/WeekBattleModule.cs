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
    public class WeekBattleModule : GameModule
    {

        private DataContext _db;

        public Dictionary<int, Dictionary<int, DWeekBattle>> DWeekBattles { get; private set; }//diff>day>x
        public Dictionary<int, DWeekBox> DWeekBoxs { get; private set; }

        private DungeonModule _dungeonModule;
        public WeekBattleModule(DataContext db, GameDesignContext design)
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
                DWeekBattles = designDb.DWeekBattle.AsNoTracking().GroupBy(x=>x.lv).ToDictionary(x => x.Key, x => x.ToDictionary(y=>y.day, y=>y));
                DWeekBoxs = designDb.DWeekBox.AsNoTracking().ToDictionary(x=>x.id, x=>x);
            });
        }


        #region 事件

        #endregion

        #region 辅助方法
        private Dictionary<string, WeekBattleData> _instances = new Dictionary<string, WeekBattleData>();
        public WeekBattleData QueryWeekData(string pid)
        {
            if (!_instances.TryGetValue(pid, out var instance))
            {
                instance = _db.WeekBattleData.FirstOrDefault(d => d.PlayerId == pid);
                if (instance == null)
                {
                    instance = new WeekBattleData();
                    instance.PlayerId = pid;
                    instance.LastRefreshDay = DateTime.Now;
                    instance.LastRefreshWeek = DateTime.Now;
                    instance.UseNumb = 0;
                    instance.RecvBoxes = string.Empty;
                    _db.WeekBattleData.Add(instance);
                    _db.SaveChanges();
                }
                _instances.Add(pid, instance);
            }
            if (instance.LastRefreshDay.Date != DateTime.Today)
            {
                instance.UseNumb = 0;
                instance.LastRefreshDay = DateTime.Now;
                if (!instance.LastRefreshWeek.IsSameWeek(DateTime.Today))
                {
                    instance.LastRefreshWeek = DateTime.Today;
                    instance.DaysInWeek = 0;
                    instance.Score = 0;
                    instance.RecvBoxes = string.Empty;
                }
                _db.SaveChanges();
            }
            return instance;
        }
        #endregion
        
    }
}
