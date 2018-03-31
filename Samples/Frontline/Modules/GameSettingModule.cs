using Frontline.Common;
using Frontline.Data;
using Microsoft.Extensions.Options;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.Modules
{
    public class GameSettingModule:GameModule
    {
        public DataContext DataContext { get; private set; }
        public GameServerSettings Settings { get; private set; }

        public GameSettingModule(DataContext db, IOptions<GameServerSettings> settings)
        {
            DataContext = db;
            Settings = settings.Value;
        }
    }
}
