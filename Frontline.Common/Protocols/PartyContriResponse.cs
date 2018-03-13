using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 党费 协议:-357
    /// </summary>
	[Proto(value=-357,description="党费")]
	[ProtoContract]
	public class PartyContriResponse
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  当日贡献次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int cur;
        /// <summary>
        ///  每日最大贡献次数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int max;
        /// <summary>
        ///  党费列表
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<ContriInfo> contries;
        /// <summary>
        ///  党费log
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<ContriLogInfo> logs;
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