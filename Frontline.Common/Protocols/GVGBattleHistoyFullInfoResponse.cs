using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看公会战斗记录详情 协议:-823
    /// </summary>
	[Proto(value=-823,description="查看公会战斗记录详情")]
	[ProtoContract]
	public class GVGBattleHistoyFullInfoResponse
	{
        /// <summary>
        ///  战斗记录id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string battleId;
        /// <summary>
        ///  是否胜利
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  进攻方名字
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string attackerName;
        /// <summary>
        ///  进攻所属军团id
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string attackerGid;
        /// <summary>
        ///  防守方id
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string defenderId;
        /// <summary>
        ///  战斗时间
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public long time;
        /// <summary>
        ///  是否获得
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public bool gain;
        /// <summary>
        ///  金币
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int gold;
        /// <summary>
        ///  军需
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int supply;
        /// <summary>
        ///  钢铁
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int iron;
        /// <summary>
        ///  军功
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int feat;
        /// <summary>
        ///  稀有金属
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int metal;
        /// <summary>
        ///  军团荣誉
        /// </summary>
		[ProtoMember(15, IsRequired = false)]
		public int glory;
        /// <summary>
        ///  军团获得的道具
        /// </summary>
		[ProtoMember(16, IsRequired = false)]
		public List<DropItem> itemsGuild;
        /// <summary>
        ///  个人获得的道具
        /// </summary>
		[ProtoMember(17, IsRequired = false)]
		public List<DropItem> itemsPersonal;
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