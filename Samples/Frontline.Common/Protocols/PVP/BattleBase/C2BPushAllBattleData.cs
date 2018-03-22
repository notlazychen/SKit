using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 上传全战场信息 协议:509
    /// </summary>
	[Proto(value=509,description="上传全战场信息")]
	[ProtoContract]
	public class C2BPushAllBattleData
	{
        /// <summary>
        ///  同步用秘钥
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string key;
        /// <summary>
        ///  战斗成员信息，不需要赋值unitInfo
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public List<PVPPlayerInfo> playerInfos;
        /// <summary>
        ///  旗帜信息
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<PVPFlag> flags;
        /// <summary>
        ///  怪物
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<BattleMonsterInfo> monsters;

	}
}