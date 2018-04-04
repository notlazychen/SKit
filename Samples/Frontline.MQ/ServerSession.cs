using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using protocol;
using SKit.MQ.Utils;

namespace Frontline.MQ
{
    public class ServerSession
    {
        public string Address { get; private set; }
        public IServerSender Socket { get; private set; }
        public bool InError { get; private set; }

        private readonly byte[] _localAddressData;

        public ServerSession(string address, string localAddress, IServerSender socket)
        {
            _localAddressData = Encoding.UTF8.GetBytes(localAddress);
            Address = address.TrimEnd('\0');
            Socket = socket;
        }

        public virtual bool SendToServer<T>(T msg)
        {
            var attribute = msg.GetType().GetCustomAttributesData().First(a => a.AttributeType == typeof(ProtoAttribute));
            //Debug.Assert(attribute.NamedArguments != null, "attribute.NamedArguments != null");
            var cmd = Convert.ToInt16(attribute.NamedArguments[0].TypedValue.Value);

            MemoryStream stream = new MemoryStream();
            ProtoBuf.Serializer.Serialize<T>(stream, msg);
            var bytes = stream.ToArray();

            int offset = 0;
            var buffer = new byte[bytes.Length + 1 + 2 + 30];
            buffer[offset++] = 1;

            Buffer.BlockCopy(_localAddressData, 0, buffer, offset, _localAddressData.Length);
            offset += 30;
            buffer[offset++] = (byte)((cmd >> 8) & 0xff);
            buffer[offset++] = (byte)(cmd & 0xff);
          
            Buffer.BlockCopy(bytes, 0, buffer, offset, bytes.Length);
            Socket.Send(buffer);

            Console.WriteLine("发送长度：{0}", buffer.Length);
            return true;
        }


        public virtual void SendToClient<T>(T msg, params String[] pids)
        {
            var attribute = msg.GetType().GetCustomAttributesData().First(a => a.AttributeType == typeof(ProtoAttribute));
            Debug.Assert(attribute.NamedArguments != null, "attribute.NamedArguments != null");
            var cmd = Convert.ToInt16(attribute.NamedArguments[0].TypedValue.Value);

            MemoryStream stream = new MemoryStream();
            ProtoBuf.Serializer.Serialize<T>(stream, msg);
            var bytes = stream.ToArray();
            
            List<byte[]> pidDatas = new List<byte[]>();

            foreach (string pid in pids)
            {
                byte[] pidData = Encoding.UTF8.GetBytes(pid);
                pidDatas.Add(pidData);
            }

            int offset = 0;
            var buffer = new byte[bytes.Length + 1 + 2 + 1 + pidDatas.Sum(x => x.Length + 1)];
            buffer[offset++] = 0;
            buffer[offset++] = (byte)((cmd >> 8) & 0xff);
            buffer[offset++] = (byte)(cmd & 0xff);
            buffer[offset++] = (byte) pidDatas.Count;
            foreach (byte[] pidData in pidDatas)
            {
                buffer[offset++] = (byte)pidData.Length;
                Buffer.BlockCopy(pidData, 0, buffer, offset, pidData.Length);
                offset += pidData.Length;
            }

            Buffer.BlockCopy(bytes, 0, buffer, offset, bytes.Length);

            Socket.Send(buffer);
        }
    }
}
