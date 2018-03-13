using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 设置当前默认阵容 协议:-20
    /// </summary>
	[Proto(value=-20,description="设置当前默认阵容")]
	[ProtoContract]
	public class SetCurrentTeamResponse
	{
        /// <summary>
        ///  当前阵容的id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string tid;
        /// <summary>
        ///  阵容类型1五位，2十位
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int type;
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