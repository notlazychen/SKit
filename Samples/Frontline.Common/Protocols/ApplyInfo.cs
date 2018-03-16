using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class ApplyInfo
	{
        /// <summary>
        ///  申请id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  玩家id
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  战力
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int power;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int level;
        /// <summary>
        ///  vip等级
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  昵称
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string nickname;
        /// <summary>
        ///  在线状态
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public bool online;
        /// <summary>
        ///  阵营
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int camp;
        /// <summary>
        ///  时间
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public long time;

	}
}