using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GrabFlagAdversaryInfo
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  排名
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int rank;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int power;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int level;
        /// <summary>
        ///  头像
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  名字
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string name;

	}
}