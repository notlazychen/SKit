using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）占领旗帜 协议:-501
    /// </summary>
	[Proto(value=-501,description="（战斗服）占领旗帜")]
	[ProtoContract]
	public class B2CCaptureFlag
	{
        /// <summary>
        ///  旗帜Id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int flagId;
        /// <summary>
        ///  占领方
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int group;
        /// <summary>
        ///  占领方pid
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public long time;

	}
}