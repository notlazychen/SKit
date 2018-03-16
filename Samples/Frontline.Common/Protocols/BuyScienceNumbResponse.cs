using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买科研序列 协议:-624
    /// </summary>
	[Proto(value=-624,description="购买科研序列")]
	[ProtoContract]
	public class BuyScienceNumbResponse
	{
        /// <summary>
        ///  总研发序列
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int totalDevs;
        /// <summary>
        ///  已购买研发序列
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int buyNumb;
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