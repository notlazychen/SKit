using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 公会战的举办情况 协议:-802
    /// </summary>
	[Proto(value=-802,description="公会战的举办情况")]
	[ProtoContract]
	public class GVGInfoResponse
	{
        /// <summary>
        ///  公会战开始时间
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public long startTime;
        /// <summary>
        ///  公会战结束时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public long endTime;
        /// <summary>
        ///  报名开始时间
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public long enrollStartTime;
        /// <summary>
        ///  报名截止时间
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public long enrollEndTime;
        /// <summary>
        ///  （如果战争中）公会战地址
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string ip;
        /// <summary>
        ///  （如果战争中）公会战端口
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int port;
        /// <summary>
        ///  （如果战争中）公会战登录口令
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string token;
        /// <summary>
        ///  状态，1已报名，2已开始，0什么都没做
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int state;
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