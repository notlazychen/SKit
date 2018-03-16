using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 关卡的野怪表 协议:44
    /// </summary>
	[Proto(value=44,description="关卡的野怪表")]
	[ProtoContract]
	public class FBMonsterInfoRequest
	{
        /// <summary>
        ///  关卡id(数据库id)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}