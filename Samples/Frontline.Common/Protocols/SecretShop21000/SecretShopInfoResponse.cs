using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 登录时拉取神秘商店信息
    /// </summary>
	[Proto(value = -21002, description = "登录时拉取神秘商店信息")]
    [ProtoContract]
    public class SecretShopInfoResponse
    {
        /// <summary>
        /// 是否开启(如果false未开启则商品列表null结束时间无意义)
        /// </summary>
        [ProtoMember(1, IsRequired = false)]
        public bool open;
        /// <summary>
        ///  商品列表
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
        public List<SecretShopCommodityInfo> commodities;
        /// <summary>
        /// 开始时间
        /// </summary>
        [ProtoMember(3, IsRequired = false)]
        public long beginTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        [ProtoMember(4, IsRequired = false)]
        public long endTime;
    }
}