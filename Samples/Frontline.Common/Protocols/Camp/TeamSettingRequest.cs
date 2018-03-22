using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 保存阵容配置 协议:25
    /// </summary>
	[Proto(value=25,description="保存阵容配置")]
	[ProtoContract]
	public class TeamSettingRequest
	{
        /// <summary>
        ///  阵容
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public TeamInfo team;
        /// <summary>
        ///  阵容类型1五位，2十位
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;

	}
}