using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 资源详情 协议:-9
    /// </summary>
	[Proto(value=-9,description="资源详情")]
	[ProtoContract]
	public class ResResponse
	{
        /// <summary>
        ///  player id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  vip等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int vip;
        /// <summary>
        ///  等级
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int level;
        /// <summary>
        ///  昵称
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string nickyName;
        /// <summary>
        ///  头像
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string icon;
        /// <summary>
        ///  改名次数
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int renameCnt;
        /// <summary>
        ///  资源
        /// </summary>
		[ProtoMember(9, IsRequired = false)]
		public List<ResInfo> resInfos;
        /// <summary>
        ///  经验
        /// </summary>
		[ProtoMember(10, IsRequired = false)]
		public int exp;
        /// <summary>
        ///  达到下一级所需经验
        /// </summary>
		[ProtoMember(11, IsRequired = false)]
		public int nextExp;
        /// <summary>
        ///  本级所需经验
        /// </summary>
		[ProtoMember(12, IsRequired = false)]
		public int preExp;
        /// <summary>
        ///  铁壁战最高波数
        /// </summary>
		[ProtoMember(13, IsRequired = false)]
		public int resistMaxWave;
        /// <summary>
        ///  sid
        /// </summary>
		[ProtoMember(14, IsRequired = false)]
		public int sid;
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