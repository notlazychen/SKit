using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 设置阵容结果 协议:-25
    /// </summary>
	[Proto(value=-25,description="设置阵容结果")]
	[ProtoContract]
	public class TeamSettingResponse
	{
        /// <summary>
        ///  阵容的id
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