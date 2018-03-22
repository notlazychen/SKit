using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 开战的回复 协议:-71
    /// </summary>
	[Proto(value=-71,description="开战的回复")]
	[ProtoContract]
	public class StartResistResponse
	{
        /// <summary>
        ///  波
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public ResistWaveInfo wave;
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