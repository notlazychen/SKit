using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战内）请求公会详情 协议:814
    /// </summary>
	[Proto(value=814,description="（公会战内）请求公会详情")]
	[ProtoContract]
	public class GuildDetailRequest
	{
        /// <summary>
        ///  公会Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;

	}
}