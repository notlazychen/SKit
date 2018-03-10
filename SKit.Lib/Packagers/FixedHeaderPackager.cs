using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Lib.Packagers
{
    /// <summary>
    /// 可用于实现具体的固定头协议
    /// </summary>
    public abstract class FixedHeaderPackager : ISPackager
    {
        readonly ArraySegment<byte> _defaultData = new ArraySegment<byte>();

        public ArraySegment<byte> UnPack(byte[] buffer, int offset, int count, ref int readlength)
        {
            int headerSize = GetHeaderLength(buffer, offset, count);
            if (headerSize != 0 && count > headerSize)
            {
                int bodyLength = GetBodyLength(buffer, offset, headerSize);
                int totalLength = headerSize + bodyLength;
                if (count >= totalLength)
                {
                    readlength = totalLength;
                    //byte[] data = new byte[bodyLength];
                    //Buffer.BlockCopy(buffer, offset + headerSize, data, 0, bodyLength);
                    return new ArraySegment<byte>(buffer, offset + headerSize, bodyLength);
                }
            }
            readlength = 0;
            return _defaultData;
        }

        public ArraySegment<byte> Pack(byte[] buffer, int offset, int count)
        {
            //组包
            var headBuf = ToHeader(buffer, offset, count);
            var sendBuf = new byte[count + headBuf.Length];
            Buffer.BlockCopy(headBuf, 0, sendBuf, 0, 4);
            Buffer.BlockCopy(buffer, offset, sendBuf, 4, count);
            return new ArraySegment<byte>(sendBuf);
        }

        /// <summary>
        /// 头部的组织方法
        /// </summary>
        /// <param name="sendData">发送buffer</param>
        /// <param name="offset">偏移</param>
        /// <param name="length">可用长度</param>
        /// <returns></returns>
        protected abstract byte[] ToHeader(byte[] sendData, int offset, int length);
        /// <summary>
        /// 获取固定头部的长度
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset">当前偏移</param>
        /// <param name="length">可读取长度</param>
        /// <returns></returns>
        protected abstract int GetHeaderLength(byte[] buffer, int offset, int length);
        /// <summary>
        /// 获取Body长度
        /// </summary>
        /// <param name="buffer">buffer</param>
        /// <param name="offset">当前偏移</param>
        /// <param name="length">可读取长度</param>
        /// <returns></returns>
        protected abstract int GetBodyLength(byte[] buffer, int offset, int length);
    }
}
