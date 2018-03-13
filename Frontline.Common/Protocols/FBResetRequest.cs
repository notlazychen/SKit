using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 副本信息 协议:48
    /// </summary>
	[Proto(value=48,description="副本信息")]
	[ProtoContract]
	public class FBResetRequest
	{
        /// <summary>
        ///  关卡ID（数据库id）
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string fid;

	}
}