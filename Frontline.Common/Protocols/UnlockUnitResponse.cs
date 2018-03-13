using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 兵种解锁返回 协议:-132
    /// </summary>
	[Proto(value=-132,description="兵种解锁返回")]
	[ProtoContract]
	public class UnlockUnitResponse
	{
        /// <summary>
        ///  解锁的兵种ID
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int unitId;
        /// <summary>
        ///  获得的兵种信息
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public UnitInfo unitInfo;
        /// <summary>
        ///  itemId
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int itemId;
        /// <summary>
        ///  itemCnt
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int itemCnt;
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