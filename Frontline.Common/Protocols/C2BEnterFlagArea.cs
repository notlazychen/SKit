using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）进入洗旗范围 协议:500
    /// </summary>
	[Proto(value=500,description="（战斗服）进入洗旗范围")]
	[ProtoContract]
	public class C2BEnterFlagArea
	{
        /// <summary>
        ///  兵种id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string uid;
        /// <summary>
        ///  单兵Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string goId;
        /// <summary>
        ///  旗帜
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int flagId;

	}
}