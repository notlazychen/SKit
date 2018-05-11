using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Frontline.GameDesign
{
    public class DVIP
    {
        /// <summary>
        /// id(即充值购买商品ID-productId)
        /// </summary>
        [Key]
        public string id { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public int lv { get; set; }
        /// <summary>
        /// 花费价格(RMB)
        /// </summary>
        public float price { get; set; }
        /// <summary>
        /// 持续时间（天）
        /// </summary>
        public int day { get; set; }
        /// <summary>
        /// 首次礼包
        /// </summary>
        public JsonObject<int[]> first_item_id { get; set; }
        public JsonObject<int[]> first_item_cnt { get; set; }
        /// <summary>
        /// 续费礼包
        /// </summary>
        public JsonObject<int[]> next_item_id { get; set; }
        public JsonObject<int[]> next_item_cnt { get; set; }
        /// <summary>
        /// 钻石商城折扣
        /// </summary>
        public float diamond_mall_rate { get; set; }
        /// <summary>
        /// 每日购买金币次数
        /// </summary>
        public int oneday_buy_gold { get; set; }
        /// <summary>
        /// 每日购买体力次数
        /// </summary>
        public int oneday_buy_oil { get; set; }
        /// <summary>
        /// 每日领取钻石
        /// </summary>
        public int oneday_recv_diamond { get; set; }
        /// <summary>
        /// 每日领取金币
        /// </summary>
        public int oneday_recv_gold { get; set; }
        /// <summary>
        /// 是否可连续扫荡
        /// </summary>
        public bool can_sweep { get; set; }
        /// <summary>
        /// 体力上限
        /// </summary>
        public int max_oil { get; set; }
        /// <summary>
        /// 补签天数
        /// </summary>
        public int sign_re_day_numb { get; set; }
        /// <summary>
        /// 精英关卡额外购买次数
        /// </summary>
        public int mission_ex_numb_buytimes { get; set; }
        /// <summary>
        /// 增加上阵单位属性万分比
        /// </summary>
        public int property_addition { get; set; }
        /// <summary>
        /// 可招募工人数量
        /// </summary>
        public int work_total_hire_n { get; set; }
        /// <summary>
        /// 每天可刷新招募次数
        /// </summary>
        public int work_day_hire_n { get; set; }
        /// <summary>
        /// 刷新出巨匠工人概率
        /// </summary>
        public float work_worker4_prob { get; set; }
        /// <summary>
        /// 运输线重置次数
        /// </summary>
        public int reset_transport { get; set; }
        /// <summary>
        /// 雪地营救重置次数
        /// </summary>
        public int reset_rescue { get; set; }
        /// <summary>
        /// 抵抗前线重置次数
        /// </summary>
        public int reset_dikang { get; set; }
        /// <summary>
        /// 火线突击重置次数
        /// </summary>
        public int reset_weekwar { get; set; }
    }
}
