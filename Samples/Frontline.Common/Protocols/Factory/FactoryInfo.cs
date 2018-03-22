using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class FactoryInfo
	{
        /// <summary>
        ///  工厂type
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  工厂lv
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int lv;
        /// <summary>
        ///  生产资源类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int res_type;
        /// <summary>
        ///  下次可领取资源数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int res_cnt;
        /// <summary>
        ///  工人数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int workerCnt;
        /// <summary>
        ///  是否升级建造中
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public bool building;
        /// <summary>
        ///  升级结束时间
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public long buildEndTime;

	}
}