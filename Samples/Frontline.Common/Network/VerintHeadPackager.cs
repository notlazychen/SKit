using SKit.Common.Packagers;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frontline.Common.Network
{
    public class VerintHeadPackager : FixedHeadPackager
    {
        protected override ArraySegment<byte> ToHead(byte[] sendData, int offset, int length)
        {
            var head = Varint.Int2ByteArray(length);
            return head;
        }

        protected override bool TryGetHeadLengthAndBodyLength(byte[] buffer, int offset, int length, out int headLength, out int bodyLength)
        {
            headLength = Varint.ByteArray2Int(new ArraySegment<byte>(buffer, offset, length), out bodyLength);
            return headLength > 0 && bodyLength > 0;
        }
    }
}
