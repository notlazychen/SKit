using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 处理好友申请 协议:306
    /// </summary>
	[Proto(value=306,description="处理好友申请")]
	[ProtoContract]
	public class ProcessFriendAddRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  是否通过申请
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool pass;

	}
}