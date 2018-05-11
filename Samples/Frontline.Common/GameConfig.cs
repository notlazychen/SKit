using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Common
{
    public class GameConfig
    {
        /// <summary>
        /// 体力最大值
        /// </summary>
        public static int OilMaxValue = 400;
        /// <summary>
        /// 每x分钟回复1点体力
        /// </summary>
        public static int OilReplyMinutes = 5;
        /// <summary>
        /// 单次购买体力数量
        /// </summary>
        public static int OilNumBuyOnce = 200;
        /// <summary>
        /// 购买资源最大次数
        /// </summary>
        public static int MaxBuyResNumb = 1;
        /// <summary>
        /// 标准攻击
        /// </summary>
        public static double BASE_ATK = 276;
        /// <summary>
        /// 标准防御
        /// </summary>
        public static double BASE_DEF = 276;
        /// <summary>
        /// 标准回合数
        /// </summary>
        public static double BASE_ROUND = 5;
        /// <summary>
        /// 标准系数
        /// </summary>
        public static double BASE_DEF_K = 0.3;

        /// <summary>
        /// 重命名花费钻石
        /// </summary>
        public static int[] RenameCostDiamond = { 0, 100 };
        /// <summary>
        /// 副本重置次数
        /// </summary>
        public static int DungeonResetCount = 3;
        /// <summary>
        /// 精英副本重置次数花费钻石
        /// </summary>
        public static int[] DungeonResetCostDiamond = { 50, 50, 100 };
        ///// <summary>
        ///// 
        ///// </summary>
        //public static int lottery_base_cnt = 10;
        ///// <summary>
        ///// 国内海外307T-26
        ///// </summary>
        //public static int lottery_first_item_id = 41070307;//
        //public static int lottery_first_item_cnt = 15;

        /// <summary>
        /// 好友系统等级限制（开启等级）
        /// </summary>
        public static int FriendOpenLevel = 10;
        /// <summary>
        /// 好友上限
        /// </summary>
        public static int FriendMaxCount = 100;
        /// <summary>
        /// 黑名单最大长度
        /// </summary>
        public static int FriendBlacklistMax = 50;
        /// <summary>
        /// 最大申请长度
        /// </summary>
        public static int FriendApplicationsMax = 50;
        /// <summary>
        /// 可领取原油次数
        /// </summary>
        public static int FriendMaxOilTimes = 10;
        /// <summary>
        /// 领取单位原油
        /// </summary>
        public static int FriendOil = 6;

        /// <summary>
        /// 竞技场每日挑战次数
        /// </summary>
        public static int ArenaChallengeNumber = 5;
        /// <summary>
        /// 竞技场战斗CD时间(分钟)
        /// </summary>
        public static int ArenaBattleCDMinutes = 5;
        /// <summary>
        /// 竞技场CD扣除钻石
        /// </summary>
        public static int ArenaBattleCDCostDiamond = 10;
        /// <summary>
        /// 竞技场战斗胜利获得金币
        /// </summary>
        public static int ArenaBattleWinAddGold = 200;


        /// <summary>
        /// 建军团的等级限制
        /// </summary>
        public static int LegionCreateLevel = 5;
        /// <summary>
        /// 建军团花费钻石
        /// </summary>
        public static int LegionCreateCostDiamond = 50;
        /// <summary>
        /// 加入军团的等级限制
        /// </summary>
        public static int LegionJoinLevel = 1;
        /// <summary>
        /// 军团个人申请最大数量
        /// </summary>
        public static int LegionMemberApplicationCount = 10;
        /// <summary>
        /// 军团的最大申请数量
        /// </summary>
        public static int LegionApplicationCount = 50;
        /// <summary>
        /// 军团申请的过期时间
        /// </summary>
        public static int LegionApplicationOverdueHour = 24;
        /// <summary>
        /// 军团列表长度
        /// </summary>
        public static int LegionListCount = 25;
        /// <summary>
        /// 军团捐献日志长度
        /// </summary>
        public static int LegionContriLogLength = 20;
        /// <summary>
        /// 军团长1个
        /// </summary>
        public static int LegionCommanderCount = 1;
        /// <summary>
        /// 副手两个
        /// </summary>
        public static int LegionViceCommanderCount = 2;
        /// <summary>
        /// 管理3个
        /// </summary>
        public static int LegionCaptinCount = 3;
        /// <summary>
        /// 军团留言板大小
        /// </summary>
        public static int LegionBBSLength = 50;
        /// <summary>
        /// 后勤基地初始普通工人类型列表
        /// </summary>
        public static int[] FactoryInitWorkersType = { 1, 1, 2, 2, 3 };
        /// <summary>
        /// 工人市场大小
        /// </summary>
        public static int FactoryWorkerMarketLength = 5;
        /// <summary>
        /// 两种类型的任务各有多少个
        /// </summary>
        public static int FactoryTaskLength = 3;

        /// <summary>
        /// 抵抗前线每日最大次数
        /// </summary>
        public static int MaxDiKangNumbOneDay = 1;
        /// <summary>
        /// 抵抗前线扫荡金币单价
        /// </summary>
        public static int DiKangSweepGoldPrice = 100;
        /// <summary>
        /// 运输每日最大次数
        /// </summary>
        public static int TransportMaxTimes = 3;
        /// <summary>
        /// 雪地营救最大次数
        /// </summary>
        public static int RescueMaxTimes = 3;
        /// <summary>
        /// 邮件数量上限
        /// </summary>
        public static int mail_max = 100;
        /// <summary>
        /// 邮件过期时间（天）（针对不带附件的邮件）
        /// </summary>
        public static int mail_idle = 15;
        /// <summary>
        /// 邮件一页显示多少封
        /// </summary>
        public static int mail_pagecount = 5;
        /// <summary>
        /// 收藏的邮件数量上限
        /// </summary>
        public static int mail_collect_max = 100;
        /// <summary>
        /// 邮件标题字数上限
        /// </summary>
        public static int mail_title_length = 30;
        /// <summary>
        /// 邮件正文字数上限
        /// </summary>
        public static int mail_content_length = 200;
        /// <summary>
        /// 周常挑战次数上限
        /// </summary>
        public static int week_challenge_number = 1;
        /// <summary>
        /// 周常挑战每场胜利获得积分
        /// </summary>
        public static int week_challenge_score = 10;
        /// <summary>
        /// 兵种转碎片转化率
        /// </summary>
        public static float unit_to_item_rate = 1.0f;
    }
}
