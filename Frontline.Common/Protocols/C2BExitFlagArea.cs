using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）离开洗旗范围 协议:501
    /// </summary>
	[Proto(value=501,description="（战斗服）离开洗旗范围")]
	[ProtoContract]
	public class C2BExitFlagArea
	{
        /// <summary>
        ///  单兵Id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string goId;
        /// <summary>
        ///  旗帜
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int flagId;

	}
}