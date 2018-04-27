using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Frontline.GameDesign
{
    public class TableTool
    {
        public Dictionary<string, string> Tables = new Dictionary<string, string>();

        public TableTool()
        {
            Tables.Add("服务器端-游戏数值配置.xlsx", "DGameConfig");
            Tables.Add("军团捐献表.xlsx", "DLegionDonate");
            Tables.Add("道具表.xlsx", "DItem");
            Tables.Add("玩家等级表.xlsx", "DLevel");
            Tables.Add("战斗系统——怪物配置表.xlsx", "DMonster");
            Tables.Add("战斗系统——怪物能力表.xlsx", "DMonsterAbility");
            Tables.Add("战斗系统——关卡对应怪物表.xlsx", "DMonsterInDungeon");
            Tables.Add("战斗系统——关卡配置表.xlsx", "DDungeon");
            Tables.Add("兵种属性表.xlsx", "DUnit");
            Tables.Add("兵种进阶表.xlsx", "DUnitGradeUp");
            Tables.Add("兵种升级消耗.xlsx", "DUnitLevelUp");
            Tables.Add("兵种购买表.xlsx", "DUnitUnlock");
            Tables.Add("兵种装备表.xlsx", "DEquip");
            Tables.Add("兵种装备升级消耗.xlsx", "DEquipLevelCost");
            Tables.Add("装备升阶表.xlsx", "DEquipGrade");
            Tables.Add("随机库表.xlsx", "DRandom");

            Tables.Add("十连抽-抽奖配置.xlsx", "DLottery");
            Tables.Add("十连抽-抽奖ID.xlsx", "DLotteryGroup");
            Tables.Add("十连抽-奖励库.xlsx", "DLotteryRand");
            Tables.Add("活动-在线有礼.xlsx", "DOlReward");
            Tables.Add("夺旗战-次数奖励.xlsx", "DArenaChallengeReward");
            Tables.Add("夺旗战-排行榜奖励.xlsx", "DArenaRankReward");
            Tables.Add("副本评星奖励.xlsx", "DDungeonStar");
            Tables.Add("军团配置表.xlsx", "DLegion");
            Tables.Add("后勤基地-工人表.xlsx", "DFacWorker");
            Tables.Add("后勤基地-派遣任务.xlsx", "DFacTask");
            Tables.Add("后勤基地-派遣任务分组.xlsx", "DFacTaskGroup");
            Tables.Add("VIP特权.xlsx", "VIPPrivilege");
            Tables.Add("任务系统-每日任务表.xlsx", "DQuestDaily");
            Tables.Add("任务系统-主线任务表.xlsx", "DQuest");
            Tables.Add("每日任务活跃度奖励.xlsx", "DQuestDailyReward");
            Tables.Add("资源购买表.xlsx", "DResPrice");
            Tables.Add("抵抗前线宝箱.xlsx", "DDiKangQianXianBox");
            Tables.Add("抵抗前线配置表.xlsx", "DDiKangQianXian");
            Tables.Add("战斗系统——特殊建筑表.xlsx", "DDiKangQianXianBuilding");
            Tables.Add("护送运输车关卡配置表.xlsx", "DTransport");
            Tables.Add("雪地营救战关卡配置表.xlsx", "DRescue");
            Tables.Add("军团科技表.xlsx", "DLegionScience");
            Tables.Add("周常挑战-配置表.xlsx", "DWeekBattle");
            Tables.Add("周常挑战-宝箱奖励.xlsx", "DWeekBox");

            Tables.Add("商店总表.xlsx", "DMallShop");
            Tables.Add("商店商品表.xlsx", "DMallShopItem");
            Tables.Add("神秘商店-商店分组.xlsx", "DSecretShop");
            Tables.Add("神秘商店-商品表.xlsx", "DSecretShopItem");
            Tables.Add("神秘商店-触发.xlsx", "DSecretShopProb");
            Tables.Add("技能表.xlsx", "DSkill");

            Tables.Add("摇奖-掉落库.xlsx", "DRaffle");
            Tables.Add("摇奖-分组.xlsx", "DRaffleGroup");
        }
    }
}
