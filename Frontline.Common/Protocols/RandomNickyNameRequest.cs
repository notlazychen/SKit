using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 随机名字 协议:10
    /// </summary>
	[Proto(value=10,description="随机名字")]
	[ProtoContract]
	public class RandomNickyNameRequest
	{
        /// <summary>
        ///  性别
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int sex;

	}
}