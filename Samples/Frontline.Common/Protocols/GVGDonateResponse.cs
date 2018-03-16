using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （公会战）捐献结果返回 协议:-806
    /// </summary>
	[Proto(value=-806,description="（公会战）捐献结果返回")]
	[ProtoContract]
	public class GVGDonateResponse
	{
        /// <summary>
        ///  建筑类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  建筑物等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int lv;
        /// <summary>
        ///  当前经验
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int curExp;
        /// <summary>
        ///  最大经验
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int totalExp;
        /// <summary>
        ///  增加的经验
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int addExp;
        /// <summary>
        ///  当前等级属性加成
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public float prop;
        /// <summary>
        ///  下一级属性加成
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public float propNext;
        /// <summary>
        ///  总属性
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public float propTotal;
        /// <summary>
        ///  进驻属性加成
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public float propAdd;
        /// <summary>
        ///  主城当前经验
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int cityCurExp;
        /// <summary>
        ///  主城最大经验
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int cityTotalExp;
        /// <summary>
        ///  主城等级
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int cityLv;
        /// <summary>
        ///  钻石
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public int diamond;
        /// <summary>
        ///  稀有金属
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public int metal;
        /// <summary>
        ///  军功
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public int feat;
        /// <summary>
        ///  是否是使用钻石
        /// </summary>
		[ProtoMember(18, IsRequired = false)]
		public bool isUseDiamond;
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