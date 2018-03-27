using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 解雇工人返回
    /// </summary>
	[Proto(value=-20003, description="解雇工人返回")]
	[ProtoContract]
	public class FireWorkerResponse
	{
        /// <summary>
        /// 解雇成功
        /// </summary>
        [ProtoMember(1, IsRequired = false)]
        public bool success;
        [ProtoMember(2, IsRequired = false)]
        public string info;
        /// <summary>
        ///  解雇的工人Id
        /// </summary>
		[ProtoMember(3, IsRequired = false)]
        public string workerid;
    }
}