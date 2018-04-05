using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Common
{
    public class GameConfig
    {
        public static readonly int TYPE_SCIENCE = 1;
        public static readonly int TYPE_UNIT_UNLOCK = 2;
        public static readonly int TYPE_INDUSTRY = 3;
        public static readonly int TYPE_UNITREST = 4;//兵种休整

        public static int MaxBuyResNumb = 1;//购买资源最大次数

        public static int BASE_ATK = 276;
        public static int BASE_DEF = 276;
        public static int BASE_ROUND = 5;
        public static double BASE_DEF_K = 0.3;

        public static int[] RenameCostDiamond = { 0, 100 };//精英副本重置次数花费钻石

        public static int DungeonResetCount = 3;//副本重置次数
        public static int[] DungeonResetCostDiamond = { 50, 50, 100 };//精英副本重置次数花费钻石

        public static int lottery_base_cnt = 10;
        public static int lottery_first_item_id = 41070307;//国内海外307T-26
        public static int lottery_first_item_cnt = 15;

        public static int FriendOpenLevel = 10;//等级限制（开启等级）
        public static int FriendMaxCount = 100;//好友上限
        public static int FriendBlacklistMax = 50;//黑名单最大长度
        public static int FriendApplicationsMax = 50;//最大申请长度
        public static int FriendMaxOilTimes = 10;//可领取原油次数
        public static int FriendOil = 6;//领取单位原油

        public static int ArenaChallengeNumber = 5;
        public static int ArenaBattleCDMinutes = 5;
        public static int ArenaBattleCDCostDiamond = 10;//竞技场CD扣除钻石
        public static int ArenaBattleWinAddGold = 200;

        public static int LegionCreateLevel = 5;//建党的等级限制
        public static int LegionCreateCostDiamond = 50;//花费
        public static int LegionJoinLevel = 1;//入党的等级限制
        public static int LegionMemberApplicationCount = 10;//个人申请最大数量
        public static int LegionApplicationCount = 50;//军团的最大申请数量
        public static int LegionApplicationOverdueHour = 24;//申请的过期时间
        //public static int idle_time = 24;//申请或创建军团要求的闲置时间
        public static int auto_leader = 7;//党首自动移位所需离线时间
        public static int LegionListCount = 25;//军团列表长度
        //public static int contri_time_every_day = 1;//每日可捐献次数 
        public static int LegionContriLogLength = 20;//捐献log长度
        public static int LegionCommanderCount = 1;//军团长1个
        public static int LegionViceCommanderCount = 2;//副手两个
        public static int LegionCaptinCount = 3;//总管三个
        public static int LegionBBSLength = 50;//留言板大小

        public static int[] FactoryInitWorkersType = { 1, 1, 2, 2, 3 };//后勤基地初始普通工人类型
        public static int FactoryWorkerMarketLength = 5;//工人市场大小
        public static int FactoryTaskLength = 3;//两种类型的任务各有多少个

        public static int MaxDiKangNumbOneDay = 1;//抵抗前线每日最大次数
        public static int DiKangSweepGoldPrice = 100;//抵抗前线扫荡金币单价
    }
}
