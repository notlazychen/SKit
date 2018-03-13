using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class BulletinInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  类型
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int type;
        /// <summary>
        ///  页签文字
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string tag;
        /// <summary>
        ///  标题
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string title;
        /// <summary>
        ///  内容
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string context;
        /// <summary>
        ///  开始时间
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string start_time;
        /// <summary>
        ///  结束时间
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string end_time;

	}
}