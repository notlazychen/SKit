using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 重命名 协议:15
    /// </summary>
	[Proto(value=15,description="重命名")]
	[ProtoContract]
	public class RenameAndIconRequest
	{
        /// <summary>
        ///  昵称(null表示不做修改)
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
		public string nickyName;
        /// <summary>
        ///  icon(null表示不做修改)
        /// </summary>
		[ProtoMember(2, IsRequired = false)]
		public string icon;

	}
}