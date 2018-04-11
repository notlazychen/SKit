using Frontline.Data;
using Frontline.GameDesign;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frontline.Domain;
using SKit.Common.Utils;
using Frontline.Common;
using Microsoft.Extensions.Logging;
using SKit.Common;

namespace Frontline.Modules
{
    public class ChatModule : GameModule
    {
        public const int CHANNEL_WORLD = 0;
        public const int CHANNEL_CAMP = 1;
        public const int CHANNEL_PARTY = 2;
        public const int CHANNEL_PRIVATE = 3;

        
        private DataContext _db;
        private ILogger _logger;

        public ChatModule(DataContext db, ILogger<ChatModule> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        #region 事件
        #endregion

        #region 辅助方法
        #endregion

        #region 客户端接口
        private List<ChatInfo> _worldChats = new List<ChatInfo>();//世界频道聊天纪录

        public int Call_Chat(GameSession session, ChatRequest request)
        {
            long now = DateTime.Now.ToUnixTime();
            ChatResponse response = new ChatResponse();
            String text = request.text;

            //todo:过滤脏词

            response.text = request.text;
            response.voice = request.voice;
            response.type = request.type;
            response.from = session.PlayerId;
            response.time = now;
            Player p = Server.GetModule<PlayerModule>().QueryPlayer(session.PlayerId);
            if (p.State == Player.STATE_SILENT && p.StateTime > now)
            {
                response.info = GameErrorCode.禁言中.ToString();
                session.SendAsync(response);
                return 0;
            }
            response.camp = p.Camp;
            response.icon = p.Icon;
            response.level = p.Level;
            response.vip = p.VIP;
            response.nickyName = p.NickName;
            var legionController = Server.GetModule<LegionModule>();
            var legion = legionController.QueryLegion(p.LegionId);
            response.partyName = legion?.Name;
            response.success = true;

            ChatInfo info = new ChatInfo();
            info.text = text;//过滤脏词
            info.type = request.type;
            info.from = session.PlayerId;
            info.time = now;
            info.camp = p.Camp;
            info.icon = p.Icon;
            info.level = p.Level;
            info.vip = p.VIP;
            info.nickyName = p.NickName;
            switch (request.type)//根据类型发送到不同的channel
            {
                case CHANNEL_PRIVATE:
                    if (Server.IsOnline(request.to))
                    {
                        Server.SendByUserNameAsync(request.to, response);
                        response.targetOnline = true;
                    }
                    else
                    {
                        response.targetOnline = false;
                    }
                    session.SendAsync(response);
                    break;
                case CHANNEL_WORLD:
                    Server.BroadcastAllUserAsync(response);

                    this._worldChats.Add(info);
                    if (this._worldChats.Count > 100)
                    {
                        this._worldChats.RemoveAt(0);
                    }
                    break;

                case CHANNEL_PARTY:
                    if (legion == null)
                    {
                        session.SendAsync(response);
                        return 0;
                    }
                    var members = legion.Members;
                    Server.MultiSendByUserNameAsync(members.Select(m => m.PlayerId), response);
                    break;
                default:
                    break;
            }
            return 0;
        }
        #endregion
    }
}

