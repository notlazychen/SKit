using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 扫荡副本 协议:-46
    /// </summary>
	[Proto(value=-46,description="扫荡副本")]
	[ProtoContract]
	public class FBWipeResponse
	{
        /// <summary>
        ///  关卡ID（数据库id）
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  扫荡次数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int count;
        /// <summary>
        ///  扫荡获取的奖励
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public List<RewardInfo> rewards;
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
        /// <summary>
        /// 兵种获得经验之后
        /// </summary>
        [ProtoMember(6, IsRequired = false)]
        public List<UnitInfo> units;
    }
}