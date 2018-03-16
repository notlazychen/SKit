using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// VIP信息改变的推送 协议:-402
    /// </summary>
	[Proto(value=-402,description="VIP信息改变的推送")]
	[ProtoContract]
	public class VIPInfoChangedNotify
	{
        /// <summary>
        ///  新的VIP等级
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int newVipLv;
        /// <summary>
        ///  新的VIP经验
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int newVipExp;
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