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
    public class RescueBattleStartCommand : GameCommand<StartRescueRequest>
    {
        DungeonModule _dungeonModule;
        RescueModule _rescueModule;
        DataContext _db;

        protected override void OnInit()
        {
            _dungeonModule = Server.GetModule<DungeonModule>();
            _rescueModule = Server.GetModule<RescueModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;            
            Rescue t = _rescueModule.QueryRescue(pid);
            StartRescueResponse response = new StartRescueResponse();

            int canPlayNumb = GameConfig.RescueMaxTimes - t.UseNumb;
            if (canPlayNumb <= 0)
            {
                return -2;
            }
            DRescue dres = _rescueModule.DRescues[Request.difficulty];
            t.MissionDiff = Request.difficulty;
            t.MissionToken = Guid.NewGuid().ToString();
            t.MissionBeginTime = DateTime.Now;
            response.success = true;
            response.battleId = t.MissionToken;         
            //怪物
            response.monster = _dungeonModule.ToMonsterInfosByDungeonId(dres.mid);     
            Session.SendAsync(response);
            return 0;
        }
    }
}
