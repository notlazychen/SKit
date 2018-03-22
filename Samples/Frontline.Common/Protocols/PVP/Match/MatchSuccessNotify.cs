using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 匹配成功推送 协议:-122
    /// </summary>
	[Proto(value=-122,description="匹配成功推送")]
	[ProtoContract]
	public class MatchSuccessNotify
	{
        /// <summary>
        ///  参加者信息
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<MatchBattlePlayerInfo> playerInfos;
        /// <summary>
        ///  战斗连接
        /// </summary>
		[ProtoMember(4, IsRequired = true)]
		public int conv;
        /// <summary>
        ///  战斗类型
        /// </summary>
		[ProtoMember(5, IsRequired = true)]
		public int type;
        /// <summary>
        ///  战斗服ip
        /// </summary>
		[ProtoMember(6, IsRequired = true)]
		public string ip;
        /// <summary>
        ///  战斗服端口
        /// </summary>
		[ProtoMember(7, IsRequired = true)]
		public int port;
        /// <summary>
        ///  战斗密钥
        /// </summary>
		[ProtoMember(8, IsRequired = true)]
		public string token;
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