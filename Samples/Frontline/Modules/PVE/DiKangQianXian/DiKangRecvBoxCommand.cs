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
    public class DiKangRecvBoxCommand : GameCommand<RecvResistBoxRequest>
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

            var box = _dikangModule.DDiKangQianXianBoxs[Request.id];
            var recvs = dikang.RecvBox.StringToMany(int.Parse);
            if(dikang.Current >= box.wid && !recvs.Contains(box.id)){
                recvs.Add(box.id);
                dikang.RecvBox = recvs.ManyToString(x=>x.ToString());
                string reason = "抵抗前线宝箱";
                DItem di = _pkgModule.DItems[box.box];
                RewardInfo rewardInfo = _pkgModule.RandomReward(player, di.breakRandomId, 1, reason);
                _db.SaveChanges();
                RecvResistBoxResponse response = new RecvResistBoxResponse();
                response.success = true;
                response.id = box.id;
                response.rewardInfo = rewardInfo;
                Session.SendAsync(response);
            }     

            return 0;
        }
    }
}
