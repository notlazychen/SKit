using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 引导情况返回 协议:-101
    /// </summary>
	[Proto(value=-101,description="引导情况返回")]
	[ProtoContract]
	public class GuideInfoResponse
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  引导完成情况
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public float guide;
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