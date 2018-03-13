using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 攻打副本 协议:45
    /// </summary>
	[Proto(value=45,description="攻打副本")]
	[ProtoContract]
	public class FBFightRequest
	{
        /// <summary>
        ///  关卡ID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}