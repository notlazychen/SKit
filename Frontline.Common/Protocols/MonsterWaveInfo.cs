using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MonsterWaveInfo
	{
        /// <summary>
        ///  波次
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int wave;
        /// <summary>
        ///  野怪列表
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<MonsterInfo> monster;

	}
}