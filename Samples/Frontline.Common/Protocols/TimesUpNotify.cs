using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 时间完成推送 协议:-109
    /// </summary>
	[Proto(value=-109,description="时间完成推送")]
	[ProtoContract]
	public class TimesUpNotify
	{
        /// <summary>
        ///  1科研中心，2兵种解锁，3后勤基地,4兵种休整
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public int type;
        /// <summary>
        ///  新的等级
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public int lv;
        /// <summary>
        ///  id
        /// </summary>
		[ProtoMember(5, IsRequired = false)]
		public int id;
        /// <summary>
        ///  unitid
        /// </summary>
		[ProtoMember(6, IsRequired = false)]
		public string unitid;
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