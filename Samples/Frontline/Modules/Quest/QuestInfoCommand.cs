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
    public class QuestInfoCommand : GameCommand<QuestInfoRequest>
    {
        QuestModule _questModule;
        DataContext _db;

        protected override void OnInit()
        {
            _questModule = Server.GetModule<QuestModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        //客户端请求任务信息
        public override int ExecuteCommand()
        {
            QuestInfoResponse response = new QuestInfoResponse();
            response.success = true;
            response.questPoint = 0;
            response.questPointRewards = new List<QuestPointRewardInfo>();
            response.quests = new List<QuestInfo>();

            var data = _questModule.QueryPlayerQuestData(Session.PlayerId);
            foreach (Quest q in data.Quests)
            {
                if (q.Status == QuestState.Completed || q.Status == QuestState.Waiting)
                {
                    continue;
                }
                QuestInfo qi = new QuestInfo();
                qi.id = q.Id;
                qi.qid = q.Tid;
                qi.progress = q.Progress;
                qi.questType = 0;
                response.quests.Add(qi);
            }
            foreach (QuestDaily q in data.QuestDailys)
            {
                if (q.Status == QuestState.Completed || q.Status == QuestState.Waiting)
                {
                    continue;
                }
                QuestInfo qi = new QuestInfo();
                qi.id = q.Id;
                qi.qid = q.Tid;
                qi.progress = q.Progress;
                qi.questType = 1;
                response.quests.Add(qi);
            }


            response.questPoint = data.DailyPoint;
            response.questPointRewards = new List<QuestPointRewardInfo>();
            if (!string.IsNullOrEmpty(data.DailyPointReward))
            {
                var drs = data.DailyPointReward.StringToMany(int.Parse);
                var recvd = data.RecvedDailyPointReward.StringToMany(int.Parse);
                foreach (int id in drs)
                {
                    QuestPointRewardInfo info = new QuestPointRewardInfo();
                    info.id = id;
                    DQuestDailyReward dqr = _questModule.DQuestDailyRewards[id];
                    info.point = dqr.point;
                    info.itemId = dqr.item_id;
                    info.recved = recvd.Contains(id);
                    response.questPointRewards.Add(info);
                }
            }

            Session.SendAsync(response);
            return 0;
        }
    }
}
