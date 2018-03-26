using Frontline.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class FriendController : GameController
    {
        protected override void OnRegisterEvents()
        {
            base.OnRegisterEvents();
            var playerController = this.Server.GetController<PlayerController>();
            playerController.PlayerCreating += PlayerController_PlayerCreating;
            playerController.PlayerLoading += PlayerController_PlayerLoading;
            playerController.PlayerLoaded += PlayerController_PlayerLoaded;
        }

        private void PlayerController_PlayerLoaded(object sender, Player e)
        {
            if (e.FriendList == null)
            {
                e.FriendList = new FriendList()
                {
                    PlayerId = e.Id,
                    RecvTimes = 0,
                    FriendApplications = new List<FriendApplication>(),
                    Friends = new List<Friendship>()
                };
            }
        }

        private void PlayerController_PlayerCreating(object sender, Domain.Player e)
        {
            e.FriendList = new FriendList() {
                PlayerId = e.Id,
                RecvTimes = 0,
                FriendApplications = new List<FriendApplication>(),
                Friends = new List<Friendship>()
            };            
        }

        private void PlayerController_PlayerLoading(object sender, PlayerLoader e)
        {
            e.Loader = e.Loader
                .Include(x => x.FriendList)
                .ThenInclude(fl => fl.Friends)
                .Include(x => x.FriendList)
                .ThenInclude(fl => fl.FriendApplications);
        }

        public int Call_FriendList(FriendListRequest request)
        {
            FriendListResponse response = new FriendListResponse();
            response.success = true;
            var player = CurrentSession.GetBindPlayer();
            response.pid = player.Id;
            response.oilTimes = player.FriendList.RecvTimes;
            response.maxOilTimes = 5;

            //FriendListResponse response = JsonConvert.DeserializeObject<FriendListResponse>("{\"oilTimes\":0,\"friends\":[],\"success\":true,\"maxOilTimes\":10}");
            CurrentSession.SendAsync(response);
            return 0;
        }

        public int Call_FriendAddList(FriendAddListRequest request)
        {
            FriendAddListResponse response = JsonConvert.DeserializeObject<FriendAddListResponse>("{\"pid\":\"10000f2\",\"ps\":[],\"success\":true}");
            CurrentSession.SendAsync(response);
            return 0;
        }
    }
}
