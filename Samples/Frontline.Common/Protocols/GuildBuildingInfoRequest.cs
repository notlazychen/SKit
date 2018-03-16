using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看军团建筑 协议:826
    /// </summary>
	[Proto(value=826,description="查看军团建筑")]
	[ProtoContract]
	public class GuildBuildingInfoRequest
	{
        /// <summary>
        ///  公会Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;

	}
}