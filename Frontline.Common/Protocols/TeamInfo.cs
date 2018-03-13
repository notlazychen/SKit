using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class TeamInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  各战位
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<string> bps;
        /// <summary>
        ///  是否为当前的默认阵容
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool selected;

	}
}