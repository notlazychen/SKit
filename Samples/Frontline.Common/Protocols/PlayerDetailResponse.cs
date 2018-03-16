using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看自己的详细信息 协议:-816
    /// </summary>
	[Proto(value=-816,description="查看自己的详细信息")]
	[ProtoContract]
	public class PlayerDetailResponse
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  name
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string name;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  公会缩写
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string guildShortName;
        /// <summary>
        ///  兵种
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<GVGUnitInfo> units;
        /// <summary>
        ///  是否出征中
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public bool marching;
        /// <summary>
        ///  是否驻扎中
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public bool garrisoning;
        /// <summary>
        ///  稀有金属
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int metal;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}