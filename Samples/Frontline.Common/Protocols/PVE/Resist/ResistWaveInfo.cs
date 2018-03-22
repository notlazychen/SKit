using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ResistWaveInfo
	{
        /// <summary>
        ///  波id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int wid;
        /// <summary>
        ///  野怪集合
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<MonsterInfo> monsters;
        /// <summary>
        ///  令牌奖励
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int token;
        /// <summary>
        ///  司令部id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int command;
        /// <summary>
        ///  司令部血
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int hp;
        /// <summary>
        ///  司令部防御
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int defence;

	}
}