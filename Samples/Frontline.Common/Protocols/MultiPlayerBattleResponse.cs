using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开始战斗（房间内所有人都会推送到） 协议:-1313
    /// </summary>
	[Proto(value=-1313,description="开始战斗（房间内所有人都会推送到）")]
	[ProtoContract]
	public class MultiPlayerBattleResponse
	{
        /// <summary>
        ///  战斗类型
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  难度
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int diff;
        /// <summary>
        ///  战斗服ip
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public string ip;
        /// <summary>
        ///  战斗服端口
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int port;
        /// <summary>
        ///  战斗令牌
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public string token;
        /// <summary>
        ///  参加者信息
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public List<MatchBattlePlayerInfo> playerInfos;
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