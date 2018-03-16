using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 科技详情 协议:11
    /// </summary>
	[Proto(value=11,description="科技详情")]
	[ProtoContract]
	public class ScienceInfoRequest
	{
        /// <summary>
        ///  请求的科技id，为0则返回全部已拥有科技
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;

	}
}