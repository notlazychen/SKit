using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ContriLogInfo
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  昵称
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string nickname;
        /// <summary>
        ///  捐献ID
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int contri;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public long time;

	}
}