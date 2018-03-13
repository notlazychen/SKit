using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 一键添加好友 协议:-312
    /// </summary>
	[Proto(value=-312,description="一键添加好友")]
	[ProtoContract]
	public class ProcessAllFriendAddResponse
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  通过的好友列表
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<string> fs;
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