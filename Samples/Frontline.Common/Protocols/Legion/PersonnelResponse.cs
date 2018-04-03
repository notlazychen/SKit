using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 人事调整 协议:-356
    /// </summary>
	[Proto(value=-356,description="人事调整")]
	[ProtoContract]
	public class PersonnelResponse
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  职位，0表示踢出，1党员，2表示总理，3表示副手，4表示党魁
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int career;
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