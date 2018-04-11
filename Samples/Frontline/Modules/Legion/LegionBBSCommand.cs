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
    public class LegionBBSCommand : GameCommand<PartyBBSRequest>
    {
        PlayerModule _playerModule;
        LegionModule _legionModule;
        DataContext _db;

        protected override void OnInit()
        {
            _legionModule = Server.GetModule<LegionModule>();
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        public override int ExecuteCommand()
        {
            var legion = _legionModule.QueryLegion(Request.party);
            if (legion != null)
            {
                var set = legion.LegionBBS;
                List<PartyWordsInfo> list = new List<PartyWordsInfo>();
                foreach (LegionBBS m in set)
                {
                    var dayDelta = (DateTime.Now - m.Time).TotalDays;
                    if (dayDelta >= 2)
                    {
                        _db.LegionBBS.Remove(m);
                        continue;
                    }
                    PartyWordsInfo pi = new PartyWordsInfo();
                    pi.id = m.Id;
                    pi.message = m.Content;
                    pi.pid = m.PlayerId;
                    pi.time = m.Time.ToUnixTime();
                    var p = _playerModule.QueryPlayerBaseInfo(m.PlayerId);
                    pi.level = p.Level;
                    pi.nickname = p.NickName;
                    pi.icon = p.Icon;
                    pi.vip = p.VIP;
                    list.Add(pi);
                }
                PartyBBSResponse response = new PartyBBSResponse();
                response.party = legion.Id;
                response.wordsList = list;
                response.success = true;
                Session.SendAsync(response);
            }
            return 0;
        }
    }
}
