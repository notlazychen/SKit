using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 请求后勤基地信息
    /// </summary>
	[Proto(value=20001,description= "请求后勤基地信息")]
    [ProtoContract]
    public class FactoryRequest
    {
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
        public string pid;

    }
}