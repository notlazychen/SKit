using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Common
{
    public class GameConfig
    {
        public string Secret { get; set; } = String.Empty;
        public string DESKey { get; set; } = String.Empty;
        public bool LogIO { get; set; } = true;


        public static readonly int TYPE_SCIENCE = 1;
        public static readonly int TYPE_UNIT_UNLOCK = 2;
        public static readonly int TYPE_INDUSTRY = 3;
        public static readonly int TYPE_UNITREST = 4;//兵种休整


        public const int lottery_base_cnt = 10;
        public const int lottery_first_item_id = 41070307;//国内海外307T-26
        public const int lottery_first_item_cnt = 15;

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
    }
}
