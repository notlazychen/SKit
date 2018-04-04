﻿using Frontline.Common;
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
    public class RandomNameCommand : GameCommand<RandomNickyNameRequest>
    {
        PlayerModule _playerModule;
        DataContext _db;
        GameServerSettings _config;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
            _config = Server.GetModule<GameSettingModule>().Settings;
        }

        public override int ExecuteCommand()
        {
            RandomNickyNameResponse r = new RandomNickyNameResponse();
            r.success = true;
            r.sex = Request.sex;

            int max = _playerModule.DNames.Count;
            int ran = MathUtils.RandomNumber(0, max);

            var dname = _playerModule.DNames[ran];
            string name = dname.Name;
            if (dname.UsedNumber > 0)
            {
                name += dname.UsedNumber;
            }

            r.nickyName = name;
            Session.SendAsync(r);
            return 0;
        }
    }
}
