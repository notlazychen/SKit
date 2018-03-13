using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 公会战登录 协议:-812
    /// </summary>
	[Proto(value=-812,description="公会战登录")]
	[ProtoContract]
	public class GVGLoginResponse
	{
        /// <summary>
        ///  pid
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string pid;
        /// <summary>
        ///  是否出征中
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public bool marching;
        /// <summary>
        ///  是否驻扎中
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public bool garrisoning;
        /// <summary>
        ///  稀有金属
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public int metal;
        /// <summary>
        ///  军功
        /// </summary>
		[ProtoMember(7, IsRequired = false)]
		public int feat;
        /// <summary>
        ///  军团荣誉
        /// </summary>
		[ProtoMember(8, IsRequired = false)]
		public int guildGlory;
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