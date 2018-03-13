using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class QuestInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  任务进度
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int progress;
        /// <summary>
        ///  策划id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int qid;
        /// <summary>
        ///  任务类型（0主线，1每日）
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int questType;

	}
}