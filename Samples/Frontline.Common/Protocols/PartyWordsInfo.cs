using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PartyWordsInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int level;
        /// <summary>
        ///  vip等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  昵称
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string nickname;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public long time;
        /// <summary>
        ///  发言
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string message;

	}
}