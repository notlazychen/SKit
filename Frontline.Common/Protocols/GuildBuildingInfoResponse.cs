using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看军团建筑 协议:-826
    /// </summary>
	[Proto(value=-826,description="查看军团建筑")]
	[ProtoContract]
	public class GuildBuildingInfoResponse
	{
        /// <summary>
        ///  建筑列表
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<GVGBuildingInfo> buildings;
        /// <summary>
        ///  可驻扎总人数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int totalGarrison;
        /// <summary>
        ///  当前驻军人数
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int curGarrison;
        /// <summary>
        ///  当前耐久
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int HP;
        /// <summary>
        ///  总耐久
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int maxHP;
        /// <summary>
        ///  火力
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int atk;
        /// <summary>
        ///  防御
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public int def;
        /// <summary>
        ///  暴击率
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public float crit;
        /// <summary>
        ///  火力进驻加成
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int atkAdd;
        /// <summary>
        ///  防御进驻加成
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int defAdd;
        /// <summary>
        ///  暴击率进驻加成
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public float critAdd;
        /// <summary>
        ///  总耐久进驻加成
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int maxHPAdd;
        /// <summary>
        ///  掠夺上限
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public float robLimit;
        /// <summary>
        ///  退出进驻冷却时间
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public long cdTime;
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