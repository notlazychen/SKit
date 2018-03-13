using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class RebateInfo
	{
        /// <summary>
        ///  绑定充值id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  内置道具id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<int> item_id;
        /// <summary>
        ///  内置道具数量
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<int> item_cnt;
        /// <summary>
        ///  内含资源类型
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<int> res_type;
        /// <summary>
        ///  内含资源数量
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<int> res_cnt;
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
        /// <summary>
        ///  返利次数
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int re;
        /// <summary>
        ///  返利百分比
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public float p;
        /// <summary>
        ///  剩余购买次数
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int times;

	}
}