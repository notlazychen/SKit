using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ContriInfo
	{
        /// <summary>
        ///  捐献ID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  消耗类型
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;
        /// <summary>
        ///  消耗数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int cost;
        /// <summary>
        ///  宝箱名字
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string name;
        /// <summary>
        ///  党获得经验
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int exp_party;
        /// <summary>
        ///  个人获得贡献
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int contri;

	}
}