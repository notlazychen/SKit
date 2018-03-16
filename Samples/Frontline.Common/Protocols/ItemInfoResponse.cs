using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 物品详情 协议:-53
    /// </summary>
	[Proto(value=-53,description="物品详情")]
	[ProtoContract]
	public class ItemInfoResponse
	{
        /// <summary>
        ///  策划id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  名称
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string name;
        /// <summary>
        ///  类型
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int type;
        /// <summary>
        ///  品质
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int quality;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int icon;
        /// <summary>
        ///  能否主动使用
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public bool useable;
        /// <summary>
        ///  描述
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public string desc;
        /// <summary>
        ///  价格
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int price;
        /// <summary>
        ///  最大堆叠数量
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int overlap;
        /// <summary>
        ///  是否成功
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public bool success;
        /// <summary>
        ///  错误码
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string info;

	}
}