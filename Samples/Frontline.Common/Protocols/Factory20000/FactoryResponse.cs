using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求后勤基地信息
    /// </summary>
	[Proto(value=-20001,description= "请求后勤基地信息")]
	[ProtoContract]
	public class FactoryResponse
	{
        /// <summary>
        ///  工人
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<WorkerInfo> workers;
        /// <summary>
        ///  派遣任务
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
        public List<WorkTaskInfo> taskInfos;
        /// <summary>
        ///  劳动力市场
        /// </summary>
        [ProtoMember(3, IsRequired = false)]
        public List<WorkerInfo> workerMarket;
        /// <summary>
        /// 今日已刷新工人市场次数
        /// </summary>
        [ProtoMember(4, IsRequired = false)]
        public int todayRefreshWorkerMarketNumb;
        /// <summary>
        /// 已购买工人数量
        /// </summary>
        [ProtoMember(5, IsRequired = false)]
        public int hireWorkersNumb;
    }
}