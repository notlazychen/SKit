using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取工厂资源 协议:116
    /// </summary>
	[Proto(value=116,description="领取工厂资源")]
	[ProtoContract]
	public class RecvFactoryResRequest
	{
        /// <summary>
        ///  工厂type
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;

	}
}