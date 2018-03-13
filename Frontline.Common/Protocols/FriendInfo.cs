using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class FriendInfo
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;
        /// <summary>
        ///  昵称
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string nickyName;
        /// <summary>
        ///  icon
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string icon;
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
        ///  战力
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int power;
        /// <summary>
        ///  是否可以收取原油
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public bool canGetOil;
        /// <summary>
        ///  是否可以赠送原油
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public bool canGiveOil;

	}
}