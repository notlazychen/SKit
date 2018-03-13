using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取周常宝箱 协议:913
    /// </summary>
	[Proto(value=913,description="领取周常宝箱")]
	[ProtoContract]
	public class RecvWeekBoxRequest
	{
        /// <summary>
        ///  欲领取的宝箱id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;

	}
}