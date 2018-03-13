using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 副本 协议:-43
    /// </summary>
	[Proto(value=-43,description="副本")]
	[ProtoContract]
	public class FBInfoResponse
	{
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  章id
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int section;
        /// <summary>
        ///  章类型
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int type;
        /// <summary>
        ///  副本集合
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public List<FBInfo> fbs;
        /// <summary>
        ///  已领取的星星奖励
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public List<int> receiveds;
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