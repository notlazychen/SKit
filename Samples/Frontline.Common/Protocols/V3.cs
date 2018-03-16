using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class V3
	{
        /// <summary>
        ///  x
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public float x;
        /// <summary>
        ///  y
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
		public float y;
        /// <summary>
        ///  z
        /// </summary>
		[ProtoMember(3, IsRequired = true)]
		public float z;

	}
}