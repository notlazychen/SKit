using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 获得新单位的通知 协议:-19
    /// </summary>
	[Proto(value=-19,description="获得新单位的通知")]
	[ProtoContract]
	public class NewUnitNotify
	{
        /// <summary>
        ///  获得的新单位的id（刷新兵营这个单位会出现）
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
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