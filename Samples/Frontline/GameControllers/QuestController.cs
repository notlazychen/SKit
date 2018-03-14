using Newtonsoft.Json;
using protocol;
using SKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontline.GameControllers
{
    public class QuestController : GameController
    {
        public void questInfo(GameSession session, QuestInfoRequest request)
        {
            QuestInfoResponse response = JsonConvert.DeserializeObject<QuestInfoResponse>("{\"questPointRewards\":[{\"itemId\":41190001,\"id\":1,\"recved\":false,\"point\":40},{\"itemId\":41190002,\"id\":2,\"recved\":false,\"point\":80},{\"itemId\":41190003,\"id\":3,\"recved\":false,\"point\":120},{\"itemId\":41190004,\"id\":4,\"recved\":false,\"point\":160},{\"itemId\":41190005,\"id\":5,\"recved\":false,\"point\":200}],\"questPoint\":0,\"quests\":[{\"progress\":1,\"id\":\"10000f2q11010005\",\"qid\":11010005,\"questType\":0},{\"progress\":0,\"id\":\"10000f2q11020001\",\"qid\":11020001,\"questType\":0},{\"progress\":1,\"id\":\"10000f2q11040005\",\"qid\":11040005,\"questType\":0},{\"progress\":1,\"id\":\"10000f2q11050005\",\"qid\":11050005,\"questType\":0},{\"progress\":0,\"id\":\"10000f2q11060001\",\"qid\":11060001,\"questType\":0},{\"progress\":0,\"id\":\"10000f2q11080001\",\"qid\":11080001,\"questType\":0},{\"progress\":0,\"id\":\"10000f2q11090001\",\"qid\":11090001,\"questType\":0},{\"progress\":0,\"id\":\"10000f2q11100001\",\"qid\":11100001,\"questType\":0},{\"progress\":0,\"id\":\"10000f2q11110001\",\"qid\":11110001,\"questType\":0},{\"progress\":1,\"id\":\"10000f2q11120001\",\"qid\":11120001,\"questType\":0},{\"progress\":0,\"id\":\"10000f2q12010001\",\"qid\":12010001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12020001\",\"qid\":12020001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12030001\",\"qid\":12030001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12040001\",\"qid\":12040001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12050001\",\"qid\":12050001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12060001\",\"qid\":12060001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12070010\",\"qid\":12070010,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12080010\",\"qid\":12080010,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12090010\",\"qid\":12090010,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12100010\",\"qid\":12100010,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12120001\",\"qid\":12120001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12130001\",\"qid\":12130001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12140001\",\"qid\":12140001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12150001\",\"qid\":12150001,\"questType\":1},{\"progress\":0,\"id\":\"10000f2q12160001\",\"qid\":12160001,\"questType\":1}],\"success\":true}");
            
            session.SendAsync(response);
        }
    }
}
