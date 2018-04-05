using Frontline.Common;
using Frontline.Data;
using Frontline.Domain;
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
    public class DiKangBattleStopCommand : GameCommand<ResistFightResultRequest>
    {
        PlayerModule _playerModule;
        DiKangModule _dikangModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _dikangModule = Server.GetModule<DiKangModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            var player = _playerModule.QueryPlayer(pid);
            var dikang = _dikangModule.QueryDiKang(pid);
            var wave = _dikangModule.DDiKangQianXians[dikang.Current + 1];

            ResistFightResultResponse response = new ResistFightResultResponse();
            response.success = true;
            response.wid = Request.wid;
            response.win = Request.win;
            if (Request.win)
            {
                if (wave.wid < _dikangModule.DDiKangQianXians.Count)
                {
                    var next = _dikangModule.DDiKangQianXians[wave.wid + 1];
                    ResistWaveInfo info = _dikangModule.ToInfo(next);
                    response.wave = info;
                }
                //单波结算
                int pastWid = dikang.Current + 1;

                if (dikang.Best < wave.wid)
                {
                    dikang.Best = wave.wid;
                }
                dikang.Current = wave.wid;
                string reason = "抵抗前线战斗胜利";
                int token = _playerModule.AddCurrency(player, CurrencyType.TOKEN, wave.token, reason);

                _db.SaveChanges();
                response.token = token;
            }

            Session.SendAsync(response);
            return 0;
        }
    }
}
