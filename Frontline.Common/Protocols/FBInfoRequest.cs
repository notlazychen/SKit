using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 副本信息 协议:43
    /// </summary>
	[Proto(value=43,description="副本信息")]
	[ProtoContract]
	public class FBInfoRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  章id（策划id）
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int section;
        /// <summary>
        ///  章类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;

	}
}