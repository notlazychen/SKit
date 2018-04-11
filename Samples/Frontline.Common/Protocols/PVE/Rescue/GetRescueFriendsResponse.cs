using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 雪地营救信息 协议:-221
    /// </summary>
	[Proto(value = -221, description = "雪地营救信息(废弃)")]
    [ProtoContract]
    public class GetRescueFriendsResponse
    {
        /// <summary>
        ///  已拯救过的好友pid集合
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
        public List<string> friends;
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