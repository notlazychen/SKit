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
    public class DiKangBattleSweepCommand : GameCommand<ResistSweepRequest>
    {
        PlayerModule _playerModule;
        PkgModule _pkgModule;
        DiKangModule _dikangModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _pkgModule = Server.GetModule<PkgModule>();
            _dikangModule = Server.GetModule<DiKangModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            String pid = Session.PlayerId;
            var player = _playerModule.QueryPlayer(pid);
            var dikang = _dikangModule.QueryDiKang(pid);
            ResistSweepResponse response = new ResistSweepResponse();
            int maxWave = dikang.Best - 3;

            //判断VIP是否满足
            //        D_VIP vip = DataBuilder.build(new D_VIP(player.getVip()));
            //        if (vip.getResist_sweep() != 1) {
            //            maxWave -= 3;
            //        }
            //        if (maxWave <= 0) {
            //            //不能扫荡
            //            return null;
            //        }

            int delta = maxWave - dikang.Current;
            if (delta <= 0)
            {
                return 0;
            }

            //消耗
            int price = GameConfig.DiKangSweepGoldPrice * delta;

            if (player.Wallet.GOLD < price)
            {
                return (int)GameErrorCode.资源不足;
            }
            string reason = "抵抗前线扫荡";
            _playerModule.AddCurrency(player, CurrencyType.GOLD, -price, reason);
            for (int i = dikang.Current; i < maxWave; i++)
            {
                int cur = i + 1;
                var wave = _dikangModule.DDiKangQianXians[cur];
                _playerModule.AddCurrency(player, CurrencyType.TOKEN, wave.token, reason);
            }
            dikang.Current = maxWave;
            _db.SaveChanges();
            response.token = player.Wallet.TOKEN;
            response.success = true;
            response.current = dikang.Current;
            Session.SendAsync(response);
            return 0;
        }
    }
}
