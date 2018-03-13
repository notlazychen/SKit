using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （游戏）请求公会战的举办情况 协议:802
    /// </summary>
	[Proto(value=802,description="（游戏）请求公会战的举办情况")]
	[ProtoContract]
	public class GVGInfoRequest
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}