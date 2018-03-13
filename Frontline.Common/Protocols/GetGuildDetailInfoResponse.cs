using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看公会的详细记录 协议:-821
    /// </summary>
	[Proto(value=-821,description="查看公会的详细记录")]
	[ProtoContract]
	public class GetGuildDetailInfoResponse
	{
        /// <summary>
        ///  公会id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string gid;
        /// <summary>
        ///  军团等级
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int guildLv;
        /// <summary>
        ///  主堡等级
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int cityLv;
        /// <summary>
        ///  军团人数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int playerCnt;
        /// <summary>
        ///  军团荣誉
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int glory;
        /// <summary>
        ///  攻打军团数
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int attackGuildCnt;
        /// <summary>
        ///  攻打据点数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int attackResPointCnt;
        /// <summary>
        ///  摧毁领地数
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int destoryGuildCnt;
        /// <summary>
        ///  当前排名
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int curRank;
        /// <summary>
        ///  历史最高排名
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int maxRank;
        /// <summary>
        ///  防御胜场
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int defendWin;
        /// <summary>
        ///  防御败场
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int defendLose;

	}
}