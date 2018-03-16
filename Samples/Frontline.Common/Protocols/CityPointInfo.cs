using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class CityPointInfo
	{
        /// <summary>
        ///  位置id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string positionId;
        /// <summary>
        ///  公会id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string gid;
        /// <summary>
        ///  公会名字
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string name;
        /// <summary>
        ///  公会等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int lv;
        /// <summary>
        ///  缩略名
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string shortName;
        /// <summary>
        ///  状态，1正常，2交战中，3保护中
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int state;
        /// <summary>
        ///  到期时间
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public long endTime;
        /// <summary>
        ///  军团荣誉
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int glory;

	}
}