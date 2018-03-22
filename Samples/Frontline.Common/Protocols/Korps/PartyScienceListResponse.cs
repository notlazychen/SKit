using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 科技列表 协议:-365
    /// </summary>
	[Proto(value=-365,description="科技列表")]
	[ProtoContract]
	public class PartyScienceListResponse
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string party;
        /// <summary>
        ///  科技列表
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<PartyScienceInfo> sciences;
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