using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 神秘商店开启推送
    /// </summary>
	[Proto(value = -21001, description = "神秘商店开启推送")]
    [ProtoContract]
    public class SecretShopOpenNotify
    {
        /// <summary>
        ///  商品列表
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
        public List<SecretShopCommodityInfo> commodities;
        /// <summary>
        /// 开始时间
        /// </summary>
        [ProtoMember(2, IsRequired = false)]
        public long beginTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        [ProtoMember(3, IsRequired = false)]
        public long endTime;
    }
}