using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 留言板 协议:-361
    /// </summary>
	[Proto(value=-361,description="留言板")]
	[ProtoContract]
	public class PartyBBSResponse
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string party;
        /// <summary>
        ///  发言列表
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<PartyWordsInfo> wordsList;
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