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
    public class SubmitQuestCommand : GameCommand<QuestSubmitRequest>
    {
        PlayerModule _playerModule;
        QuestModule _questModule;
        PkgModule _pkgModule;
        DataContext _db;

        protected override void OnInit()
        {
            _playerModule = Server.GetModule<PlayerModule>();
            _questModule = Server.GetModule<QuestModule>();
            _pkgModule = Server.GetModule<PkgModule>();
            _db = Server.GetModule<GameSettingModule>().DataContext;
        }

        //客户端请求任务信息
        public override int ExecuteCommand()
        {
            var player = _playerModule.QueryPlayer(Session.PlayerId);
            QuestSubmitResponse response = new QuestSubmitResponse();
            response.id = Request.id;
            response.type = Request.questType;
            var questdata = _questModule.QueryPlayerQuestData(player.Id);
            if (Request.questType == 0)
            {
                Quest quest = questdata.Quests.FirstOrDefault(q => q.Id == Request.id);
                if (quest == null || quest.Status == QuestStatus.Waiting)
                {
                    return (int)GameErrorCode.任务不存在;
                }
                if (quest.Status == QuestStatus.Completed)
                {
                    return (int)GameErrorCode.任务已经提交;
                }
                DQuest questPrototype = _questModule.DQuests[quest.Tid];
                if (quest.Progress < questPrototype.max_progress)
                {
                    return (int)GameErrorCode.任务还未完成;
                }
                response.success = true;
                Session.SendAsync(response);

                quest.Status = QuestStatus.Completed;
                Server.SendByUserNameAsync(quest.PlayerId, response);
                string reason = $"提交任务{questPrototype.id}";
                //派发奖励
                _playerModule.AddCurrency(player, CurrencyType.DIAMOND, questPrototype.res_diamond, reason);

                //尝试开启下一级任务        
                if (questPrototype.next_quest_id != 0)
                {
                    DQuest nextq = _questModule.DQuests[questPrototype.next_quest_id];
                    Quest questNew = _questModule.AcceptQuest(player, questdata, nextq);
                    if (questNew.Status == QuestStatus.Doing)
                    {
                        QuestAccepted qAccept = new QuestAccepted();
                        qAccept.questInfo = _questModule.ToInfo(questNew);
                        qAccept.success = true;
                        Session.SendAsync(qAccept);
                    }
                    _db.Quests.Remove(quest);
                }
                _db.SaveChanges();
            }
            else
            {
                QuestDaily quest = questdata.QuestDailys.FirstOrDefault(q => q.Id == Request.id);
                if (quest == null || quest.Status == QuestStatus.Waiting)
                {
                    return (int)GameErrorCode.任务不存在;
                }
                if (quest.Status == QuestStatus.Completed)
                {
                    return (int)GameErrorCode.任务已经提交;
                }
                DQuestDaily questPrototype = _questModule.DQuestDailys[quest.Tid];
                if (quest.Progress < questPrototype.max_progress)
                {
                    return (int)GameErrorCode.任务还未完成;
                }

                quest.Status = QuestStatus.Completed;
                questdata.DailyPoint += questPrototype.quest_point;
                response.questPoint = questdata.DailyPoint;
                response.success = true;
                Session.SendAsync(response);

                string reason = $"提交每日任务{questPrototype.id}";
                //派发奖励
                _playerModule.AddCurrency(player, CurrencyType.OIL, questPrototype.res_oil, reason);
                _playerModule.AddExp(player, questPrototype.res_exp, reason);
                //每日任务无需尝试开启下一级任务  
                _db.SaveChanges();
            }
            return 0;
        }
    }
}
