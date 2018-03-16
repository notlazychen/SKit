using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 选择当前阵容作为默认阵容 协议:20
    /// </summary>
	[Proto(value=20,description="选择当前阵容作为默认阵容")]
	[ProtoContract]
	public class SetCurrentTeamRequest
	{
        /// <summary>
        ///  当前阵容的id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string tid;
        /// <summary>
        ///  阵容类型1五位，2十位
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;

	}
}