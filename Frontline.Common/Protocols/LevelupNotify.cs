using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 升级通知 协议:-100
    /// </summary>
	[Proto(value=-100,description="升级通知")]
	[ProtoContract]
	public class LevelupNotify
	{
        /// <summary>
        ///  当前等级
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int level;
        /// <summary>
        ///  当前经验
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int exp;
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