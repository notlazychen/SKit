using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 公告推送 协议:-75
    /// </summary>
	[Proto(value=-75,description="公告推送")]
	[ProtoContract]
	public class NoticeNotify
	{
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int id;
        /// <summary>
        ///  参数
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<NoticeArgInfo> Args;
        /// <summary>
        ///  类型0普通滚屏，1重要广播
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int type;
        /// <summary>
        ///  重要广播的滚屏内容
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string content;
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