using System;
using System.Collections.Generic;
using System.Text;

namespace SKit
{
    public enum ClientCloseReason
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// 客户端关闭
        /// </summary>
        ClientClose,
        /// <summary>
        /// 服务器关闭
        /// </summary>
        ServerClose,
        /// <summary>
        /// 被玩家顶替
        /// </summary>
        KickOut,
        /// <summary>
        /// 协议解析出错（可能因为协议版本更新）
        /// </summary>
        ProtocolError,
        /// <summary>
        /// 接收数据拆包出错
        /// </summary>
        ReceiveDataError,
        /// <summary>
        /// 任务执行出错
        /// </summary>
        GameTaskError,
    }
}
