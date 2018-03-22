using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求更新 协议:109
    /// </summary>
	[Proto(value=109,description="请求更新")]
	[ProtoContract]
	public class RefreshTimerRequest
	{
        /// <summary>
        ///  1科研中心，2兵种解锁，3后勤基地,4兵种休整
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;

	}
}