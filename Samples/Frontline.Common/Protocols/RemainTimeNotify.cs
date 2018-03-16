using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 剩余购买次数推送 协议:-716
    /// </summary>
	[Proto(value=-716,description="剩余购买次数推送")]
	[ProtoContract]
	public class RemainTimeNotify
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  剩余购买次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int times;
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