using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）地图中野怪信息改变的通知 协议:-810
    /// </summary>
	[Proto(value=-810,description="（公会战）地图中野怪信息改变的通知")]
	[ProtoContract]
	public class GVGResPointNotify
	{
        /// <summary>
        ///  改变操作：1开打了，2打完了，3打掉刷新
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int state;
        /// <summary>
        ///  野怪点信息
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public ResPointInfo mpInfo;
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