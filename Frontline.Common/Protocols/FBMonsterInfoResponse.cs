using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 关卡的野怪列表 协议:-44
    /// </summary>
	[Proto(value=-44,description="关卡的野怪列表")]
	[ProtoContract]
	public class FBMonsterInfoResponse
	{
        /// <summary>
        ///  关卡id（数据库id）
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
		public string id;
        /// <summary>
        ///  野怪列表
        /// </summary>
		[ProtoMember(4, IsRequired = false)]
		public List<MonsterInfo> monster;
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