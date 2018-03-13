using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 玩法信息 协议:-220
    /// </summary>
	[Proto(value=-220,description="玩法信息")]
	[ProtoContract]
	public class GetPatternInfoResponse
	{
        /// <summary>
        ///  玩法集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<PVEPatternInfo> infos;
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