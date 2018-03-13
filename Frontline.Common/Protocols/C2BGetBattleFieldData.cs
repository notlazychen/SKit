using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// （战斗服）请求全部数据 协议:506
    /// </summary>
	[Proto(value=506,description="（战斗服）请求全部数据")]
	[ProtoContract]
	public class C2BGetBattleFieldData
	{
        /// <summary>
        ///  已有的单位
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public List<string> hadUnitinfos;

	}
}