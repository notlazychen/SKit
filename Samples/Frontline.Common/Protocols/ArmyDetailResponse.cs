using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看地图上部队的详细信息 协议:-815
    /// </summary>
	[Proto(value=-815,description="查看地图上部队的详细信息")]
	[ProtoContract]
	public class ArmyDetailResponse
	{
        /// <summary>
        ///  部队id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  玩家
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string name;
        /// <summary>
        ///  玩家icon
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  所属公会缩写
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string guildShortName;
        /// <summary>
        ///  总战力
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int totalPowerPoint;
        /// <summary>
        ///  兵种
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public List<GVGUnitInfo> unitIds;
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