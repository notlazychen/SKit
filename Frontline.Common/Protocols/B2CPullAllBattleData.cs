using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 拉取全战场数据 协议:-509
    /// </summary>
	[Proto(value=-509,description="拉取全战场数据")]
	[ProtoContract]
	public class B2CPullAllBattleData
	{
        /// <summary>
        ///  同步用秘钥
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string battleKey;

	}
}