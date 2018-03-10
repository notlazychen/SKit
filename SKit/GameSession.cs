using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SKit
{
    public class GameSession
    {
        public string Id { get;  }
        public Socket Socket { get; internal set; }
        internal GameSession()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        //private int _offset;//初始偏移
        //private int _size;//初始设置长度

        /// <summary>
        /// 可读取的Buffer长度
        /// </summary>
        public int BufferReaderCursor { get; internal set; }

        //internal IEnumerable<ArraySegment<byte>> Resolve(int length)
        //{
        //    _readingCur = SocketEventArgs.BytesTransferred + _readingCur;

        //    int from = _offset;
        //    int size = _readingCur - _offset;//剩余未读取字节
        //    while (true)
        //    {
        //        var readlength = 0;
        //        ArraySegment<byte> data = packagers.UnPack(SocketEventArgs.Buffer, from, size, ref readlength);
        //        if (readlength != 0)
        //        {
        //            yield return data;
        //            _readingCur -= readlength;
        //            from += readlength;
        //            size -= readlength;
        //            continue;
        //        }
        //        break;
        //    }
        //    if (size > 0)
        //    {
        //        Buffer.BlockCopy(SocketEventArgs.Buffer, from, SocketEventArgs.Buffer, _offset, size);
        //    }
        //    SocketEventArgs.SetBuffer(_readingCur, _size - _readingCur + _offset);
        //}
    }

    internal class BufferReaderStatus
    {
        public int Current { get; set; }
    }
}
