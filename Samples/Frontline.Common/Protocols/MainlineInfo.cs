using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MainlineInfo
	{
        /// <summary>
        ///  id，0是主任务
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  进度
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int progress;
        /// <summary>
        ///  已提交
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool finish;

	}
}