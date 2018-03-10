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
        public int BufferSize { get; set; }
    }
}
