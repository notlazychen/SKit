using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Common
{
    public enum GameErrorCode :int
    {
        严重错误 = -1,

        OK,
        重复登录,
        道具不足,
        资源不足,

        道具并不存在,
        道具不可使用,

        阵容设置必须是自己的兵种,
        阵容不能超过五个兵种,
        阵容不能超过十个兵种,

        兵种已经最高阶,
        兵种不满足升阶等级,
        装备已经最高阶,

        副本章节还未开启,
        关卡并不存在,
        关卡尚未开启,
        战斗令牌错误或战斗已经失效,

        不能添加自己为好友,
        已经是好友,
        好友列表已满,
        查无此人,
        已提交过好友申请,
        对方好友申请已达上限,
        对方好友列表已满,
        收取好友原油次数不足,

        竞技场挑战次数不足,
        已领取此竞技场挑战奖励,
    }

    //public enum GG : GameErrorCode
    //{

    //}
}
