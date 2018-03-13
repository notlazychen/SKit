using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）请求造兵 协议:504
    /// </summary>
	[Proto(value=504,description="（战斗服）请求造兵")]
	[ProtoContract]
	public class C2BCreateArmy
	{
        /// <summary>
        ///  兵种的id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string uid;
        /// <summary>
        ///  出生点
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int bornPlace;

	}
}