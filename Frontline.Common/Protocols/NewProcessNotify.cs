using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 进度更新推送 协议:-709
    /// </summary>
	[Proto(value=-709,description="进度更新推送")]
	[ProtoContract]
	public class NewProcessNotify
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  newProcess
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int newProcess;
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