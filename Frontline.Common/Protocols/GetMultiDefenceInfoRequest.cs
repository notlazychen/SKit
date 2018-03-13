using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 查询抢滩战信息 协议:653
    /// </summary>
	[Proto(value=653,description="查询抢滩战信息")]
	[ProtoContract]
	public class GetMultiDefenceInfoRequest
	{
        /// <summary>
        ///  没啥用
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string pid;

	}
}