using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求公告信息 协议:1101
    /// </summary>
	[Proto(value=1101,description="请求公告信息")]
	[ProtoContract]
	public class BulletinRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}