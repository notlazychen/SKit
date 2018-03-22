using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ItemInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  策划id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int tid;
        /// <summary>
        ///  名称
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string name;
        /// <summary>
        ///  类型
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int type;
        /// <summary>
        ///  品质
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int quality;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int icon;
        /// <summary>
        ///  能否主动使用
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public bool useable;
        /// <summary>
        ///  使用后获得的数量
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int breakCount;
        /// <summary>
        ///  使用后对应的随机库ID
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int breakRandomId;
        /// <summary>
        ///  使用后获得的兵种ID
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int breakUnitId;
        /// <summary>
        ///  描述
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public string desc;
        /// <summary>
        ///  价格
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int price;
        /// <summary>
        ///  最大堆叠数量
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int overlap;
        /// <summary>
        ///  当前堆叠
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int lap;
        /// <summary>
        ///  合成需要的数量
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public int synthCount;
        /// <summary>
        ///  合成目标道具ID
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int synthId;
        /// <summary>
        ///  合成消耗金币
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int synthCost;

	}
}