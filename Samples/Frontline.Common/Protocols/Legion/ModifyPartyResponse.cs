using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 修改党信息 协议:-363
    /// </summary>
	[Proto(value=-363,description="修改党信息")]
	[ProtoContract]
	public class ModifyPartyResponse
	{
        /// <summary>
        ///  党id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string party;
        /// <summary>
        ///  名称
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string name;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  宗旨
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string note;
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