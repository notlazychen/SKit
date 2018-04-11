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
    public class UseItemCommand : GameCommand<UseItemRequest>
    {
        PkgModule _pkgModule;
        PlayerModule _playerModule;
        CampModule _campModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _campModule = Server.GetModule<CampModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            int itemCnt = 1;
            if (Request.cnt > itemCnt)
            {
                itemCnt = Request.cnt;
            }
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            var item = player.Items.FirstOrDefault(x => x.Id == Request.id);
            if (item == null)
                return (int)GameErrorCode.道具并不存在;

            if (item.Count < itemCnt)
                return (int)GameErrorCode.道具不足;

            DItem di = _pkgModule.DItems[item.Tid];

            if (!di.useable)
            {
                return (int)GameErrorCode.道具不可使用;
            }

            UseItemResponse response = new UseItemResponse();
            response.id = Request.id;
            response.success = true;
            int unitId = di.breakUnitId;//使用后解锁的兵种id
            string reason = $"使用道具{di.tid}";
            if (unitId > 0)
            {
                UnitInfo ui = _campModule.UnlockUnit(player, unitId);
                response.unitInfo = ui;
            }
            else if (di.breakRandomId > 0)//使用后可以获得随机库
            {
                RewardInfo reward = _pkgModule.RandomReward(player, di.breakRandomId, 1, reason);
                response.rewardInfo = reward;
            }
            else if (di.breakCount > 0)//资源
            {
                _playerModule.AddCurrency(player, di.type, di.breakCount, reason);
                response.rewardInfo = new RewardInfo();
                response.rewardInfo.res = new List<ResInfo>()
                {
                    new ResInfo(){type = di.type, count = di.breakCount}
                };
            }

            item.Count -= itemCnt;//减少堆叠
            if (item.Count <= 0)
            {
                _db.Items.Remove(item);
                //player.Items.Remove(item);
            }
            _db.SaveChanges();
            response.lap = item.Count;
            Session.SendAsync(response);

            _pkgModule.RaiseItemUsed(item);
            return 0;
        }
    }
}
