using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 休整结果 协议:-17
    /// </summary>
	[Proto(value=-17,description="休整结果")]
	[ProtoContract]
	public class BuildUnitResponse
	{
        /// <summary>
        ///  休整的单位id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  休整后体力
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int number;
        /// <summary>
        ///  休整完成的时间
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public long endTime;
        /// <summary>
        ///  剩余的钻石
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  剩余的金币
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  剩余的军需
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int supply;
        /// <summary>
        ///  剩余的钢铁
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int iron;
        /// <summary>
        ///  是否是取消休整
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public bool cancel;
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