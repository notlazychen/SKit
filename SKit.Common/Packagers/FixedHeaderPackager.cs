using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common.Packagers
{
    /// <summary>
    /// 可用于实现具体的固定头协议
    /// </summary>
    public abstract class FixedHeadPackager : Packager
    {
        readonly ArraySegment<byte> _defaultData = new ArraySegment<byte>();

        public override ArraySegment<byte> UnPack(byte[] buffer, int offset, int count, ref int readlength)
        {
            int bodySize = 0;
            int headSize = 0;
            if(TryGetHeadLengthAndBodyLength(buffer, offset, count, out headSize, out bodySize))
            {
                int total = headSize + bodySize;
                if(total <= count)
                {
                    readlength = total;
                    return new ArraySegment<byte>(buffer, offset + headSize, bodySize);
                }
                
            }
            readlength = 0;
            return _defaultData;
        }

        public override ArraySegment<byte> Pack(byte[] data, byte[] buffer, int offset, int count)
        {
            //组包
            var headBuf = ToHead(data, 0, data.Length);
            int totalLength = headBuf.Count + data.Length;
            if(count < totalLength)
            {
                throw new StackOverflowException("数据包大小超过设置的发送缓冲区");
            }
            Buffer.BlockCopy(headBuf.Array, headBuf.Offset, buffer, offset, headBuf.Count);//拷贝头
            Buffer.BlockCopy(data, 0, buffer, offset + headBuf.Count, data.Length);//拷贝数据
            return new ArraySegment<byte>(buffer, offset, totalLength);
        }


        /// <summary>
        /// 头部的组织方法
        /// </summary>
        /// <param name="sendData">发送buffer</param>
        /// <param name="offset">偏移</param>
        /// <param name="length">可用长度</param>
        /// <returns></returns>
        protected abstract ArraySegment<byte> ToHead(byte[] sendData, int offset, int length);
        /// <summary>
        /// 获取固定头部的长度
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset">当前偏移</param>
        /// <param name="length">可读取长度</param>
        /// <returns></returns>
        protected abstract bool TryGetHeadLengthAndBodyLength(byte[] buffer, int offset, int length, out int headLength, out int bodyLength);

        ///// <summary>
        ///// 获取Body长度
        ///// </summary>
        ///// <param name="buffer">buffer</param>
        ///// <param name="offset">当前偏移</param>
        ///// <param name="length">可读取长度</param>
        ///// <returns></returns>
        //protected abstract int GetBodyLength(byte[] buffer, int offset, int length);        
    }
}
