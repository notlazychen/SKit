using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKit.Common.Packagers
{
    public class StringMessagePackager: FixedHeadPackager
    {
        protected override ArraySegment<byte> ToHead(byte[] sendData, int offset, int length)
        {
            var headBuf = BitConverter.GetBytes(length);
            if (BitConverter.IsLittleEndian)
            {
                headBuf = headBuf.Reverse().ToArray();
            }
            return new ArraySegment<byte>(headBuf);
        }

        protected override bool TryGetHeadLengthAndBodyLength(byte[] buffer, int offset, int length, out int headLength, out int bodyLength)
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
    }
}
