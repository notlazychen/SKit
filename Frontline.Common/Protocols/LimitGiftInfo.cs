using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class LimitGiftInfo
	{
        /// <summary>
        ///  礼包id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int id;
        /// <summary>
        ///  礼包等级
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int index;
        /// <summary>
        ///  礼包类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  结束时间
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public long time;
        /// <summary>
        ///  功能类型
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int func;
        /// <summary>
        ///  销售限数
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int cnt;
        /// <summary>
        ///  内置道具id
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<int> item_id;
        /// <summary>
        ///  内置道具数量
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public List<int> item_cnt;
        /// <summary>
        ///  内置资源
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public List<int> res_type;
        /// <summary>
        ///  内含资源数量
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public List<int> res_cnt;
        /// <summary>
        ///  礼包位置
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int position;
        /// <summary>
        ///  图片类型
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int pic_type;

	}
}