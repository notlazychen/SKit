using ProtoBuf;
using System.Collections.Generic;
using System;

namespace protocol
{
    /// <summary>
    /// 登录时拉取神秘商店信息
    /// </summary>
	[Proto(value = 21002, description = "登录时拉取神秘商店信息")]
    [ProtoContract]
    public class SecretShopInfoRequest
    {
        [ProtoMember(1, IsRequired = false)]
        public String pid;
    }
}