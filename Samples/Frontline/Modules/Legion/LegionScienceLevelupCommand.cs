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
    public class LegionScienceLevelupCommand : GameCommand<LegionScienceLevelUpRequest>
    {
        PlayerModule _playerModule;
        PkgModule _pkgModule;
        LegionModule _legionModule;
        DataContext _db;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            _legionModule = Server.GetModule<LegionModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        //查询个人的军团科技
        public override int ExecuteCommand()
        {
            var pm = _legionModule.QueryLegionMember(Session.PlayerId);
            if (string.IsNullOrEmpty(pm.LegionId))
            {
                return (int)GameErrorCode.军团不存在;
            }
            var legion = _legionModule.QueryLegion(pm.LegionId);
            var player = _playerModule.QueryPlayer(pm.PlayerId);

            int sid = Request.scienceId;
            var dss = _legionModule.DLegionSciences[sid];
            int nextLv = 1;
            var science = pm.LegionSciences.FirstOrDefault(s => s.Tid == sid);
            if (science != null)
            {
                nextLv = science.Level + 1;
            }
            if (!dss.TryGetValue(nextLv, out var ds))
            {
                return (int)GameErrorCode.军团科技已升至顶级;
            }
            //判断军团等级是否足够
            if(legion.Level < ds.legion_lv)
            {
                return (int)GameErrorCode.军团等级不足;
            }
            //判断资源是否足够
            for(int i = 0; i< ds.res_type.Object.Length; i++)
            {
                if (!_playerModule.IsCurrencyEnough(player, ds.res_type.Object[i], ds.res_cnt.Object[i]))
                {
                    return (int)GameErrorCode.资源不足;
                }
            }
            //判断道具是否足够
            if(!_pkgModule.IsItemEnough(player, ds.item_id.Object, ds.item_cnt.Object))
            {
                return (int)GameErrorCode.道具不足;
            }

            string reason = "军团科技升级";
            //扣除
            _pkgModule.SubItems(player, ds.item_id.Object, ds.item_cnt.Object, reason);
            _playerModule.SubCurrencies(player, ds.res_type.Object, ds.res_cnt.Object, reason);
            if (science == null)
            {
                science = new LegionScience();
                science.PlayerId = player.Id;
                science.Level = ds.lv;
                science.Tid = ds.id;
                science.Id = Guid.NewGuid().ToString();
                pm.LegionSciences.Add(science);
            }
            else
            {
                science.Level = ds.lv;
            }
            _db.SaveChanges();
            LegionScienceLevelUpResponse response = new LegionScienceLevelUpResponse();
            response.science = new LegionScienceInfo
            {
                id = science.Tid,
                level = science.Level
            };
            Session.SendAsync(response);

            return 0;
        }
    }
}
