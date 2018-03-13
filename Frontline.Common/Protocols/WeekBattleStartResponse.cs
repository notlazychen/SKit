using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 挑战周常关卡 协议:-911
    /// </summary>
	[Proto(value=-911,description="挑战周常关卡")]
	[ProtoContract]
	public class WeekBattleStartResponse
	{
        /// <summary>
        ///  开始时间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public long startTime;
        /// <summary>
        ///  周几
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int day;
        /// <summary>
        ///  token
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string token;
        /// <summary>
        ///  野怪集合
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<MonsterInfo> monsters;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int diff;
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