using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 充值返利信息返回 协议:-901
    /// </summary>
	[Proto(value=-901,description="充值返利信息返回")]
	[ProtoContract]
	public class RebateInfoResponse
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  充值返利信息
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<RebateInfo> list;
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