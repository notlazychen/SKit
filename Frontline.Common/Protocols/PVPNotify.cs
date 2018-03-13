using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// PVP匹配开始的推送 协议:-603
    /// </summary>
	[Proto(value=-603,description="PVP匹配开始的推送")]
	[ProtoContract]
	public class PVPNotify
	{
        /// <summary>
        ///  玩家名
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string name;
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  pvp玩法类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  发起匹配的时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public long time;

	}
}