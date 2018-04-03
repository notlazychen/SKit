using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace protocol
{
    /// <summary>
    /// 当客户端请求处理失败时返回原因
    /// </summary>
    [Proto(value = -1, description = "请求失败返回")]
    [ProtoContract]
    public class RequestErrorResponse
    {
        /// <summary>
        /// 失败原因
        /// </summary>
        [ProtoMember(1, IsRequired = false)]
        public string info;
    }
}
