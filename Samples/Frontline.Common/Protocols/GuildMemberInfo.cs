using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GuildMemberInfo
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  名字
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string name;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int lv;
        /// <summary>
        ///  官职
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int office;
        /// <summary>
        ///  军功
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int feat;
        /// <summary>
        ///  0普通，1出征，2驻扎
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int state;
        /// <summary>
        ///  稀有金属
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int metal;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int power;

	}
}