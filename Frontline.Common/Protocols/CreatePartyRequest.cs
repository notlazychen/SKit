using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 建党 协议:350
    /// </summary>
	[Proto(value=350,description="建党")]
	[ProtoContract]
	public class CreatePartyRequest
	{
        /// <summary>
        ///  名称
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string name;
        /// <summary>
        ///  简称
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string shortName;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  宗旨
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string note;
        /// <summary>
        ///  申请是否需要审核
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool check;

	}
}