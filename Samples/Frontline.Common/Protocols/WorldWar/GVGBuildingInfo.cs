using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GVGBuildingInfo
	{
        /// <summary>
        ///  建筑类型(1主城，2生命，3火力，4防御，5暴击)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int type;
        /// <summary>
        ///  当前等级
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int lv;
        /// <summary>
        ///  当前经验
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int exp;
        /// <summary>
        ///  最大经验
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int maxExp;
        /// <summary>
        ///  当前等级属性加成
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public float prop;
        /// <summary>
        ///  下一级属性加成
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public float propNext;
        /// <summary>
        ///  捐献消耗稀有金属
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int donateSubMetal;
        /// <summary>
        ///  捐献消耗钻石
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int donateSubDiamond;
        /// <summary>
        ///  修理消耗稀有金属
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int fixSubMetal;
        /// <summary>
        ///  修理消耗钻石
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int fixSubDiamond;
        /// <summary>
        ///  普通捐献/修理增加军功
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int metalModeAddFeat;
        /// <summary>
        ///  钻石捐献/修理增加军功
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int diamondModeAddFeat;

	}
}