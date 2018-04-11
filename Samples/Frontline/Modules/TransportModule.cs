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
    public class TransportModule : GameModule
    {

        private DataContext _db;

        public Dictionary<int, DTransport> DTransports { get; private set; }//diff:x

        private DungeonModule _dungeonModule;
        public TransportModule(DataContext db, GameDesignContext design)
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
                DTransports = designDb.DTransport.AsNoTracking().ToDictionary(x => x.diff, x => x);                
            });
        }


        #region 事件

        #endregion

        #region 辅助方法
        private Dictionary<string, Transport> _transports = new Dictionary<string, Transport>();
        public Transport QueryTransport(string pid)
        {
            if (!_transports.TryGetValue(pid, out var transport))
            {
                transport = _db.Transports.FirstOrDefault(d => d.PlayerId == pid);
                if (transport == null)
                {
                    transport = new Transport();
                    transport.PlayerId = pid;
                    transport.LastRefreshTime = DateTime.Now;
                    transport.UseNumb = 0;
                    transport.LastTodayDiff = 0;
                    _db.Transports.Add(transport);
                    _db.SaveChanges();
                }
                _transports.Add(pid, transport);
            }

            if (transport.LastRefreshTime.Date != DateTime.Today)
            {
                transport.UseNumb = 0;
                transport.LastTodayDiff = 0;
                transport.LastRefreshTime = DateTime.Now;
                _db.SaveChanges();
            }
            return transport;
        }
        #endregion

        public event GamePlayerEventHandler<string, bool> TransportBattleOver;
        public void OnTransportBattleOver(string player, bool win)
        {
            TransportBattleOver?.Invoke(player, win);
        }
        public event GamePlayerEventHandler<string, bool> TransportBattleAllLive;
        public void OnTransportBattleAllLive(string player)
        {
            TransportBattleAllLive?.Invoke(player, true);
        }
        
    }
}
