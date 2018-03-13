using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class GVGUnitInfo
	{
        /// <summary>
        ///  兵种唯一id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  兵种配置id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public int unitId;
        /// <summary>
        ///  是否死亡
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public bool dead;
        /// <summary>
        ///  是否上阵
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool selected;
        /// <summary>
        ///  是否休整
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool resting;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int power;
        /// <summary>
        ///  休整开始时间
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public long restStartTime;
        /// <summary>
        ///  休整结束时间
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public long restEndTime;

	}
}