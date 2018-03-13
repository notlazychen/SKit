using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKit.Common.Utils
{
    public class MathEx
    {
        public static void Xor(byte[] bs, byte[] ks)
        {
            if (ks != null && ks.Length > 0)
            {
                for (int i = 0; i < bs.Length; i++)
                {
                    bs[i] = (byte)(bs[i] ^ ks[i % ks.Length]);
                }
            }
        }
        public static void Xor(ArraySegment<byte> bs, byte[] ks)
        {
            if (ks != null && ks.Length > 0)
            {
                for (int i = 0; i < bs.Count; i++)
                {
                    bs.Array[i + bs.Offset] = (byte)(bs.Array[i + bs.Offset] ^ ks[i % ks.Length]);
                }
            }
        }
    }
}
