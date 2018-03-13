using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 重置波数 协议:-76
    /// </summary>
	[Proto(value=-76,description="重置波数")]
	[ProtoContract]
	public class ResistResetResponse
	{
        /// <summary>
        ///  当前波
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int current;
        /// <summary>
        ///  剩余重置次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int resetNumb;
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