using Frontline.Data;
using Frontline.Domain;
using Microsoft.EntityFrameworkCore;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SKit.Common.Utils;

namespace Frontline.Modules
{
    public class HallModule : GameModule
    {
        private DataContext _db;
        private PlayerModule _playerModule;

        private Dictionary<String, RoomInfo> _rooms = new Dictionary<string, RoomInfo>();
        private Dictionary<String, MemberInfo> _members = new Dictionary<string, MemberInfo>();

        public HallModule(DataContext db)
        {
            _db = db;
        }

        protected override void OnConfiguringModules()
        {
            _playerModule = Server.GetModule<PlayerModule>();
        }

        #region API
        #endregion
    }
}
