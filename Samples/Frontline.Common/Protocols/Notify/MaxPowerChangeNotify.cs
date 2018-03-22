using System.Collections.Generic;
using System;
using ProtoBuf;

namespace protocol
{
    /// <summary>
    /// 最高战力变更推送 协议:-717
    /// </summary>
	[Proto(value=-717,description="最高战力变更推送")]
	[ProtoContract]
	public class MaxPowerChangeNotify
	{
        /// <summary>
        ///  当前最高战力
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int Power;
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