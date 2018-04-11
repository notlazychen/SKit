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
    public class DiKangModule : GameModule
    {

        private DataContext _db;

        public Dictionary<int, DDiKangQianXian> DDiKangQianXians { get; private set; }
        public Dictionary<int, DDiKangQianXianBuilding> DDiKangQianXianBuildings { get; private set; }
        public Dictionary<int, DDiKangQianXianBox> DDiKangQianXianBoxs { get; private set; }

        private DungeonModule _dungeonModule;
        public DiKangModule(DataContext db, GameDesignContext design)
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
                DDiKangQianXians = designDb.DDiKangQianXian.AsNoTracking().ToDictionary(x => x.wid, x => x);
                DDiKangQianXianBuildings = designDb.DDiKangQianXianBuilding.AsNoTracking().ToDictionary(x => x.id, x => x);
                DDiKangQianXianBoxs = designDb.DDiKangQianXianBox.AsNoTracking().ToDictionary(x=>x.id, x=>x);
            });
        }


        #region 事件

        #endregion

        #region 辅助方法
        private Dictionary<string, DiKang> _dikangs = new Dictionary<string, DiKang>();
        public DiKang QueryDiKang(string pid)
        {
            if (!_dikangs.TryGetValue(pid, out var dikang))
            {
                dikang = _db.DiKangs.FirstOrDefault(d => d.PlayerId == pid);
                if (dikang == null)
                {
                    dikang = new DiKang();
                    dikang.PlayerId = pid;
                    dikang.LastRefreshTime = DateTime.Now;
                    dikang.RecvBox = string.Empty;
                    dikang.ResetNumb = GameConfig.MaxDiKangNumbOneDay;
                    dikang.Current = 0;
                    dikang.Best = 0;
                    _db.DiKangs.Add(dikang);
                    _db.SaveChanges();
                }
                _dikangs.Add(pid, dikang);
            }

            if (dikang.LastRefreshTime.Date != DateTime.Today)
            {
                dikang.RecvBox = string.Empty;
                dikang.ResetNumb = GameConfig.MaxDiKangNumbOneDay;
                dikang.LastRefreshTime = DateTime.Now;
                _db.SaveChanges();
            }
            return dikang;
        }

        public ResistWaveInfo ToInfo(DDiKangQianXian w)
        {
            ResistWaveInfo info = new ResistWaveInfo();
            info.command = w.command;
            DDiKangQianXianBuilding du = DDiKangQianXianBuildings[w.command];
            info.defence = du.defence;
            info.hp = du.hp;
            info.token = w.token;
            info.wid = w.wid;
            List<MonsterInfo> ms = new List<MonsterInfo>();
            info.monsters = new List<MonsterInfo>();

            foreach (int mid in w.monsters.Object)
            {
                var dm = _dungeonModule.DMonsters[mid];
                MonsterInfo mi = _dungeonModule.ToMonsterInfo(mid, 1);
                info.monsters.Add(mi);
            }
            return info;
        }
        #endregion

        public event GamePlayerEventHandler<DiKang, DDiKangQianXian> DikangBegin;
        public void OnPlayerDiKangBegin(DiKang player, DDiKangQianXian dungeon)
        {
            DikangBegin?.Invoke(player, dungeon);
        }

        public event GamePlayerEventHandler<DiKang, DDiKangQianXian> DikangPass;
        public void OnPlayerPassDiKang(DiKang player, DDiKangQianXian dungeon)
        {
            DikangPass?.Invoke(player, dungeon);
        }
    }
}
