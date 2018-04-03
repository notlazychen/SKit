using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 人事调整 协议:356
    /// </summary>
	[Proto(value=356,description="人事调整")]
	[ProtoContract]
	public class PersonnelRequest
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  职位，0表示踢出，1表示升职，-1表示降职
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int action;

	}
}