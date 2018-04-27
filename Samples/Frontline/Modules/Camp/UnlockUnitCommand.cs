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
    /// <summary>
    /// 兵种解锁
    /// </summary>
    public class UnlockUnitCommand : GameCommand<UnlockUnitRequest>
    {
        PlayerModule _playerModule;
        CampModule _campModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _campModule = Server.GetModule<CampModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            int uid = Request.unitId;
            DUnitUnlock duc = _campModule.DUnitUnlock[uid];
            string reason = $"解锁兵种{uid}";
            var pkgController = Server.GetModule<PkgModule>();
            if (pkgController.TrySubItem(player, duc.item_id, duc.item_cnt, reason, out var item))
            {
                var unitInfo = _campModule.UnlockUnit(player, uid);
                _db.SaveChanges();
                UnlockUnitResponse response = new UnlockUnitResponse
                {
                    success = true,
                    unitId = uid,
                    unitInfo = unitInfo
                };
                Server.SendByUserNameAsync(player.Id, response);
                return 0;
            }
            else
            {
                return (int)GameErrorCode.道具不足;
            }
        }
    }
}
