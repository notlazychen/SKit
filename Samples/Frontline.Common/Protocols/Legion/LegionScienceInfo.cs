using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class LegionScienceInfo
	{
        /// <summary>
        ///  军团科技ID
        /// </summary>
		[ProtoMember(1, IsRequired = true)]
		public int id;
        /// <summary>
        ///  军团科技等级(为0则未解锁)
        /// </summary>
		[ProtoMember(2, IsRequired = true)]
        public int level;
    }
}