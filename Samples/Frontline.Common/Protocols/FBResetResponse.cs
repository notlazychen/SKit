using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 副本重置 协议:-48
    /// </summary>
	[Proto(value=-48,description="副本重置")]
	[ProtoContract]
	public class FBResetResponse
	{
        /// <summary>
        ///  关卡ID（数据库id）
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string fid;
        /// <summary>
        ///  剩余重置次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int remainNumb;
        /// <summary>
        ///  每日挑战次数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int fight_times;
        /// <summary>
        ///  剩余钻石
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int diamond;
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