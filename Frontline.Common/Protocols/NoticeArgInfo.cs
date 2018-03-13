using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class NoticeArgInfo
	{
        /// <summary>
        ///  值
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string value;
        /// <summary>
        ///  类型0普通文本，1道具ID
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;

	}
}