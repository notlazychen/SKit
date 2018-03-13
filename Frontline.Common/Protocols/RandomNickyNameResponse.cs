using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 随机名字 协议:-10
    /// </summary>
	[Proto(value=-10,description="随机名字")]
	[ProtoContract]
	public class RandomNickyNameResponse
	{
        /// <summary>
        ///  性别
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int sex;
        /// <summary>
        ///  昵称
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string nickyName;
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