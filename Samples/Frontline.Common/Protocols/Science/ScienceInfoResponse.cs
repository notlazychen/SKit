using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 科技详情 协议:-11
    /// </summary>
	[Proto(value=-11,description="科技详情")]
	[ProtoContract]
	public class ScienceInfoResponse
	{
        /// <summary>
        ///  科技集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<ScienceInfo> sciences;
        /// <summary>
        ///  研发中的科技Id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<int> devs;
        /// <summary>
        ///  总研发序列
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int totalDevs;
        /// <summary>
        ///  已购买研发序列
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int buyDevs;
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