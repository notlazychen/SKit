using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取工厂资源 协议:-116
    /// </summary>
	[Proto(value=-116,description="领取工厂资源")]
	[ProtoContract]
	public class RecvFactoryResResponse
	{
        /// <summary>
        ///  工厂type
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  资源数量
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int cnt;
        /// <summary>
        ///  下次可领取资源数量
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int facResCnt;
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