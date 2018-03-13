using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取宝箱 协议:77
    /// </summary>
	[Proto(value=77,description="领取宝箱")]
	[ProtoContract]
	public class RecvResistBoxRequest
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;

	}
}