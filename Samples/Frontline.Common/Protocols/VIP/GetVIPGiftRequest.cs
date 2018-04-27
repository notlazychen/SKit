using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 领取金币钻石
    /// </summary>
	[Proto(value = 401, description = "领取金币钻石")]
    [ProtoContract]
    public class GetVIPGiftRequest
    {
        /// <summary>
        ///  领取金币钻石
        /// </summary>
		[ProtoMember(1, IsRequired = false)]
        public int type;

    }
}