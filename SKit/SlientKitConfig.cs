using System;
using System.Collections.Generic;
using System.Text;

namespace SKit
{
    public class SKitConfig
    {
        public string Id { get; set; }
        /// <summary>
        /// 客户端监听端口
        /// </summary>
        public short Port { get; set; }
        /// <summary>
        /// 接收缓冲大小
        /// </summary>
        public int RecvBufferSize { get; set; } = 1024;
        /// <summary>
        /// 发送缓冲大小
        /// </summary>
        public int SendBufferSize { get; set; } = 1024;
        /// <summary>
        /// 预设用户
        /// </summary>
        public int PresetUserCount { get; set; } = 100;
    }
}
