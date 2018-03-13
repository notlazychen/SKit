using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PVPBuff
	{
        /// <summary>
        ///  bufferID
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int bufferID;
        /// <summary>
        ///  bufferPid
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string bufferPid;
        /// <summary>
        ///  bufferSkillID
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int bufferSkillID;
        /// <summary>
        ///  bufferRestTime
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public float bufferRestTime;
        /// <summary>
        ///  needBind
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool needBind;

	}
}