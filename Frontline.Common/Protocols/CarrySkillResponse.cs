using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 携带技能 协议:-28
    /// </summary>
	[Proto(value=-28,description="携带技能")]
	[ProtoContract]
	public class CarrySkillResponse
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int sid;
        /// <summary>
        ///  是否携带
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool carry;
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