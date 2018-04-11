using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
using Frontline.GameDesign;
using Newtonsoft.Json.Linq;
using protocol;
using SKit;
using SKit.Common;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class TransportBattleStartCommand : GameCommand<StartTransportRequest>
    {
        DungeonModule _dungeonModule;
        TransportModule _tansportModule;
        DataContext _db;

        protected override void OnInit()
        {
            _dungeonModule = Server.GetModule<DungeonModule>();
            _tansportModule = Server.GetModule<TransportModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;            
            Transport t = _tansportModule.QueryTransport(pid);
            DTransport fb = _tansportModule.DTransports[Request.difficultDegree];
            int reamin = GameConfig.TransportMaxTimes - t.UseNumb;
            if (reamin <= 0)
            {
                return 0;
            }

            t.MissionBeginTime = DateTime.Now;
            t.MissionDiff = fb.diff;
            t.MissionToken = Guid.NewGuid().ToString();
            StartTransportResponse response = new StartTransportResponse();
            response.monsters = new List<MonsterWaveInfo>();
            var wave1 = new MonsterWaveInfo() { wave = 1, monster = new List<MonsterInfo>() };
            response.monsters.Add(wave1);
            foreach (int mid in fb.robbers1.Object)
            {
                wave1.monster.Add(_dungeonModule.ToMonsterInfoByDungeonId(mid, fb.tid));
            }
            var wave2 = new MonsterWaveInfo() { wave = 2, monster = new List<MonsterInfo>() };
            response.monsters.Add(wave2);
            foreach (int mid in fb.robbers2.Object)
            {
                wave2.monster.Add(_dungeonModule.ToMonsterInfoByDungeonId(mid, fb.tid));
            }
            var wave3 = new MonsterWaveInfo() { wave = 3, monster = new List<MonsterInfo>() };
            response.monsters.Add(wave3);
            foreach (int mid in fb.robbers3.Object)
            {
                wave3.monster.Add(_dungeonModule.ToMonsterInfoByDungeonId(mid, fb.tid));
            }
            response.trucks = new List<MonsterInfo>();
            for(int i = 0; i< 3; i++)
            {
                response.trucks.Add(_dungeonModule.ToMonsterInfoByDungeonId(fb.truck_id, fb.tid));
            }
            response.battleToken = t.MissionToken;
            response.success = true;            
            Session.SendAsync(response);
            return 0;
        }
    }
}
