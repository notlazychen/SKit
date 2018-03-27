using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 刷新工人商店
    /// </summary>
	[Proto(value=20004,description= "刷新工人商店")]
	[ProtoContract]
	public class RefreshWorkerMarketRequest
    {
        /// <summary>
        /// pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public String pid;

	}
}