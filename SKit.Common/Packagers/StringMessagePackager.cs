using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKit.Common.Packagers
{
    public class StringMessagePackager: FixedHeaderPackager
    {
        protected override byte[] ToHeader(byte[] sendData, int offset, int length)
        {
            var headBuf = BitConverter.GetBytes(length);
            if (BitConverter.IsLittleEndian)
            {
                headBuf = headBuf.Reverse().ToArray();
            }
            return headBuf;
        }

        protected override int GetHeaderLength(byte[] buffer, int offset, int length)
        {
            return 4;
        }

        protected override int GetBodyLength(byte[] buffer, int offset, int headerSize)
        {
            if (BitConverter.IsLittleEndian)
            {
                var head = new byte[headerSize];
                for (int i = 0; i < headerSize; i++)
                {
                    head[headerSize - i - 1] = buffer[offset + i];
                }
                return BitConverter.ToInt32(head, 0);
            }
            else
            {
                //for (int i = 0; i < headerSize; i++)
                //{
                //    head[i] = buffer[offset + i];
                //}
                return BitConverter.ToInt32(buffer, offset);
            }
        }
    }
}
