using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查看地图上部队的详细信息 协议:815
    /// </summary>
	[Proto(value=815,description="查看地图上部队的详细信息")]
	[ProtoContract]
	public class ArmyDetailRequest
	{
        /// <summary>
        ///  部队id
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string id;

	}
}