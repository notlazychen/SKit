using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class MultiDefencePlayerInfo
	{
        /// <summary>
        ///  获得积分
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int recvScore;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  name
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string name;
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  lv
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int lv;
        /// <summary>
        ///  vip
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  服务器名字
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string serName;
        /// <summary>
        ///  奖励
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public RewardInfo reward;
        /// <summary>
        ///  死亡兵种
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public List<string> deadUnits;

	}
}