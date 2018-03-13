using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 后勤基地信息返回 协议:-103
    /// </summary>
	[Proto(value=-103,description="后勤基地信息返回")]
	[ProtoContract]
	public class GetIndustryInfoResponse
	{
        /// <summary>
        ///  拥有工人数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int totalWorkers;
        /// <summary>
        ///  空闲工人数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int idleWorkers;
        /// <summary>
        ///  工厂信息
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<FactoryInfo> factories;
        /// <summary>
        ///  下次领取时间
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public long nextTime;
        /// <summary>
        ///  最大领取次数
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int maxNumb;
        /// <summary>
        ///  剩余领取次数
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int curNumb;
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