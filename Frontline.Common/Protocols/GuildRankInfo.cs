using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GuildRankInfo
	{
        /// <summary>
        ///  gid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;
        /// <summary>
        ///  name
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string name;
        /// <summary>
        ///  ShortName
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string shortName;
        /// <summary>
        ///  排名
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int rank;
        /// <summary>
        ///  服务器名
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string serverName;
        /// <summary>
        ///  荣誉
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int glory;

	}
}