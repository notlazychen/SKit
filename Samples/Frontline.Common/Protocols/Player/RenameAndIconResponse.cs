using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 重命名返回 协议:-15
    /// </summary>
	[Proto(value=-15,description="重命名返回")]
	[ProtoContract]
	public class RenameAndIconResponse
	{
        /// <summary>
        ///  修改后的昵称(null表示未做修改)
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string nickyName;
        /// <summary>
        ///  修改后的icon(null表示未做修改)
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public string icon;
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