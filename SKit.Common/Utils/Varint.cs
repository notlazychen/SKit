using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKit.Common.Utils
{
    public class Varint
    {
        public static ArraySegment<byte> Int2ByteArray(int value)
        {
            byte[] data = new byte[5];
            int count = 0;
            do
            {
                data[count] = (byte)((value & 0x7F) | 0x80);
                count++;
            } while ((value >>= 7) != 0);
            data[count - 1] &= 0x7F;
            return new ArraySegment<byte>(data, 0, count);
        }

        public static int ByteArray2Int(ArraySegment<byte>  data, out int value)
        {
            int length = 1;
            value = data.Array[data.Offset+0];
            if ((value & 0x80) == 0)
            {
                return length;
            }
            value &= 0x7F;
            int chunk = data.Array[data.Offset + 1];
            value |= (chunk & 0x7F) << 7;
            length ++;
            if ((chunk & 0x80) == 0) return length;
            chunk = data.Array[data.Offset + 2];
            value |= (chunk & 0x7F) << 14;
            length++;
            if ((chunk & 0x80) == 0) return length;
            chunk = data.Array[data.Offset + 3];
            value |= (chunk & 0x7F) << 21;
            length++;
            if ((chunk & 0x80) == 0) return length;
            chunk = data.Array[data.Offset + 4]; ;
            value |= chunk << 28;
            length++;
            if ((chunk & 0xF0) == 0) return length;
            throw new OverflowException("ByteArray2Int Error!");
        }
    }
}
