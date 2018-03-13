using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）捐献 协议:806
    /// </summary>
	[Proto(value=806,description="（公会战）捐献")]
	[ProtoContract]
	public class GVGDonateRequest
	{
        /// <summary>
        ///  建筑类型(1主城，2生命，3火力，4防御，5暴击)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  是否使用钻石
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public bool useDiamond;

	}
}