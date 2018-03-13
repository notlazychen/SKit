using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 波战斗结果 协议:-72
    /// </summary>
	[Proto(value=-72,description="波战斗结果")]
	[ProtoContract]
	public class ResistFightResultResponse
	{
        /// <summary>
        ///  波id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int wid;
        /// <summary>
        ///  是否胜利了
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool win;
        /// <summary>
        ///  下一个波(如果为null，则开始结算下面的奖励)
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public ResistWaveInfo wave;
        /// <summary>
        ///  令牌奖励
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int token;
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