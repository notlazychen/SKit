using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SKit.Common
{
    /// <summary>
    /// 极简字符串序列化和反序列化
    /// </summary>
    public class StringSerializer : Serializer
    {
        private bool TryGetHeadLengthAndBodyLength(byte[] buffer, int offset, int length, out int headLength, out int bodyLength)
        {
            headLength = 4;
            bodyLength = 0;
            if (length <= headLength)
            {
                return false;
            }

            if (BitConverter.IsLittleEndian)
            {
                var head = new byte[headLength];
                for (int i = 0; i < headLength; i++)
                {
                    head[headLength - i - 1] = buffer[offset + i];
                }
                bodyLength = BitConverter.ToInt32(head, 0);
            }
            else
            {
                bodyLength = BitConverter.ToInt32(buffer, offset);
            }
            return bodyLength > 0;
        }

        //public override bool TryDeserialize(byte[] buffer, int offset, int count, ref int readlength, out Object entity)
        //{
        //    if (TryGetHeadLengthAndBodyLength(buffer, offset, count, out var headSize, out var bodySize))
        //    {
        //        int total = headSize + bodySize;
        //        if (total <= count)
        //        {
        //            readlength = total;
        //            entity = Encoding.UTF8.GetString(buffer, offset + headSize, bodySize);
        //            return true;
        //        }
        //    }
        //    readlength = 0;
        //    entity = null;
        //    return false;            
        //}

        public override int Serialize(Object entity, byte[] buffer, int length)
        {
            //组包
            var data = Encoding.UTF8.GetBytes(entity as string);
            var headBuf = BitConverter.GetBytes(data.Length);
            if (BitConverter.IsLittleEndian)
            {
                headBuf = headBuf.Reverse().ToArray();
            }
            int totalLength = headBuf.Length + data.Length;
            if (length < totalLength)
            {
                throw new StackOverflowException("数据包大小超过设置的发送缓冲区");
            }
            Buffer.BlockCopy(headBuf, 0, buffer, 0, headBuf.Length);//拷贝头
            Buffer.BlockCopy(data, 0, buffer, headBuf.Length, data.Length);//拷贝数据
            return totalLength;
        }

        public override string DataToCmd(byte[] data, int offset, int count)
        {
            return "String";
        }

        public override ArraySegment<byte> UnPack(byte[] buffer, int offset, int count, ref int readlength)
        {
            if (TryGetHeadLengthAndBodyLength(buffer, offset, count, out var headSize, out var bodySize))
            {
                int total = headSize + bodySize;
                if (total <= count)
                {
                    readlength = total;
                    return new ArraySegment<byte>(buffer, offset + headSize, bodySize);
                }
            }
            readlength = 0;
            return default(ArraySegment<byte>);
        }

        public override object Deserialize(Type type, byte[] data, int offset, int count)
        {
            return Encoding.UTF8.GetString(data, offset, count);
        }        
    }
}
