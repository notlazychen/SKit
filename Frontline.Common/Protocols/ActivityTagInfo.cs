using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ActivityTagInfo
	{
        /// <summary>
        ///  活动类型
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  小标签
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int label;
        /// <summary>
        ///  tag
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int tag;
        /// <summary>
        ///  vip
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  diamond
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  是否弹窗
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int popup;
        /// <summary>
        ///  活动描述
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string desc;
        /// <summary>
        ///  活动开始时间
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public string start_time;
        /// <summary>
        ///  活动结束时间
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string end_time;

	}
}