using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
	[ProtoContract]
	public class PVPBattleUnitInfo
	{
        /// <summary>
        ///  tid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public int tid;
        /// <summary>
        ///  sid
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string sid;
        /// <summary>
        ///  gos
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public List<PVPBattleUnitGameObject> gos;
        /// <summary>
        ///  unitInfo
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public UnitInfo unitInfo;

	}
}