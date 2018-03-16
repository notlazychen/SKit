using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开始雪地营救返回 协议:-222
    /// </summary>
	[Proto(value=-222,description="开始雪地营救返回")]
	[ProtoContract]
	public class StartRescueResponse
	{
        /// <summary>
        ///  battleId
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string battleId;
        /// <summary>
        ///  好友上阵单位
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<TeamPlaceInfo> friendTeam;
        /// <summary>
        ///  野怪列表
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<MonsterInfo> monster;
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