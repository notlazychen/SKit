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
    public class ItemRandomInfoCommand : GameCommand<ItemRandomInfoRequest>
    {
        PkgModule _pkgModule;
        //PlayerModule _playerModule;
        //DataContext _db;
        //GameServerSettings _config;

        protected override void OnInit()
        {
            _pkgModule = Server.GetModule<PkgModule>();
            //_playerModule = Server.GetModule<PlayerModule>();
            //_db = Server.GetModule<GameSettingModule>().DataContext;
            //_config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            ItemRandomInfoResponse response = new ItemRandomInfoResponse();
            DItem di = _pkgModule.DItems[Request.id];
            if (di.breakRandomId != 0)
            {
                if(_pkgModule.DRandoms.TryGetValue(di.breakRandomId, out var groups))
                {
                    response.itemIds = new List<int>();
                    response.itemCnt = new List<int>();
                    response.ress = new List<int>();
                    response.ressCnt = new List<int>();
                    foreach (var g in groups.Values)
                    {
                        foreach (var m in g)
                        {
                            if (m.tid == 0)
                                continue;
                            if (m.type == 1)
                            {
                                response.ress.Add(m.tid);
                                response.ressCnt.Add(m.min);
                            }
                            else
                            {
                                response.itemIds.Add(m.tid);
                                response.itemCnt.Add(m.min);
                            }
                        }
                    }
                    response.all = groups.All(g => g.Value.Count == 1);
                }                
            }
            response.success = true;
            Session.SendAsync(response);
            return 0;
        }
    }
}
