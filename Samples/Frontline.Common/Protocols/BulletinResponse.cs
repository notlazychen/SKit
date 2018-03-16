using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 公告信息返回 协议:-1101
    /// </summary>
	[Proto(value=-1101,description="公告信息返回")]
	[ProtoContract]
	public class BulletinResponse
	{
        /// <summary>
        ///  公告信息
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<BulletinInfo> bulletins;
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