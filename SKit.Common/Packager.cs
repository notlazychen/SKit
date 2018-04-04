using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common
{
    public abstract class Packager
    {
        /// <summary>
        /// 拆包
        /// </summary>
        /// <param name="buffer">接收缓冲区</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">长度</param>
        /// <param name="readlength">返回读取的头+身体的总长度</param>
        /// <returns>提取出数据实体包</returns>
        public abstract ArraySegment<byte> UnPack(byte[] buffer, int offset, int count, ref int readlength);
        /// <summary>
        /// 打包,将实体序列化后的数据打包成网络包
        /// </summary>
        /// <returns>打包完的数据包</returns>
        public abstract ArraySegment<byte> Pack(byte[] data, byte[] buffer, int offset, int count);
    }
}
