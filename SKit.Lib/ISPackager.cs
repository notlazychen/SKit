using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Lib
{
    public interface ISPackager
    {
        ArraySegment<byte> UnPack(byte[] buffer, int offset, int count, ref int readlength);
        ArraySegment<byte> Pack(byte[] body, int offset, int count);
    }
}
