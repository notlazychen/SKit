using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）洗旗状态需要改变 协议:-500
    /// </summary>
	[Proto(value=-500,description="（战斗服）洗旗状态需要改变")]
	[ProtoContract]
	public class B2CUpdateFlagStatus
	{
        /// <summary>
        ///  旗帜Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int flagId;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}