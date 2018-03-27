using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 刷新工人商店
    /// </summary>
	[Proto(value=-20004, description= "刷新工人商店")]
	[ProtoContract]
	public class RefreshWorkerMarketResponse
    {
        [ProtoMember(1, IsRequired = false)]
        public bool success;
        [ProtoMember(2, IsRequired = false)]
        public string info;
        /// <summary>
        ///  可雇佣的工人
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
        public List<WorkerInfo> workerMarket;
    }
}