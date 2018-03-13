using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开始加载战斗 协议:-124
    /// </summary>
	[Proto(value=-124,description="开始加载战斗")]
	[ProtoContract]
	public class MatchStartLoadingNotify
	{
        /// <summary>
        ///  随机种子
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int randomSeed;
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