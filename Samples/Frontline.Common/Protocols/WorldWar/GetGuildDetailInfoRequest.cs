using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看我的公会的详细记录 协议:821
    /// </summary>
	[Proto(value=821,description="查看我的公会的详细记录")]
	[ProtoContract]
	public class GetGuildDetailInfoRequest
	{
        /// <summary>
        ///  我的公会id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;

	}
}