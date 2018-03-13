using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class RechargeInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  充值次数
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int recharge_times;

	}
}