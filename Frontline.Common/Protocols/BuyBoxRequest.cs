using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 购买宝箱 协议:136
    /// </summary>
	[Proto(value=136,description="购买宝箱")]
	[ProtoContract]
	public class BuyBoxRequest
	{
        /// <summary>
        ///  宝箱id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;

	}
}