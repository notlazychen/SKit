using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 收取好友赠送的原油 协议:-301
    /// </summary>
	[Proto(value=-301,description="收取好友赠送的原油")]
	[ProtoContract]
	public class GetOilFromFriendResponse
	{
        /// <summary>
        ///  好友id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  是否一键收取
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool all;
        /// <summary>
        ///  当前的原油点数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int oilRemain;
        /// <summary>
        ///  已领取原油次数
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int oilTimes;
        /// <summary>
        ///  最大可领取原油次数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int maxOilTimes;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}