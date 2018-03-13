using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProtoBuf;
using protocol;
using SKit.Common;
using SKit.Common.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Frontline.Common.Network
{
    /// <summary>
    /// 极简字符串序列化和反序列化
    /// </summary>
    public class ProtoBufSerializer : SKit.Common.Serializer
    {
        private static byte[] _xorbytes;
        private Dictionary<Type, short> _types = new Dictionary<Type, short>();
        private Dictionary<short, string> _cmds = new Dictionary<short, string>();

        public ProtoBufSerializer(IOptions<GameConfig> config)
        {
            _xorbytes = Encoding.UTF8.GetBytes(config.Value.Secret);
        }

        public override string DataToCmd(byte[] data, int offset, int count)
        {
            short cmd = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, offset));
            return _cmds[cmd];
        }

        public override Object Deserialize(Type type, byte[] data, int offset, int count)
        {
            offset += 2;
            int bodyLength = count - 2;
            MathEx.Xor(new ArraySegment<byte>(data, offset, bodyLength), _xorbytes);
            using (MemoryStream stream = new MemoryStream(data, offset, bodyLength))
            {
                stream.SetLength(bodyLength);
                return ProtoBuf.Serializer.Deserialize(type, stream);
            }
        }

        public override byte[] Serialize(Object entity)
        {
            short cmd;
            if(_types.TryGetValue(entity.GetType(), out cmd)){

                MemoryStream stream = new MemoryStream();
                ProtoBuf.Serializer.Serialize(stream, entity);
                var bytes = stream.ToArray();
                MathEx.Xor(bytes, _xorbytes);

                int offset = 0;
                var buffer = new byte[bytes.Length + 2];

                buffer[offset++] = (byte)((cmd >> 8) & 0xff);
                buffer[offset++] = (byte)(cmd & 0xff);

                Buffer.BlockCopy(bytes, 0, buffer, offset, bytes.Length);
                return buffer;
            }
            return null;
        }

        public override void Register(Type type)
        {
            var attribute = type.GetCustomAttributesData().First(a => a.AttributeType == typeof(ProtoAttribute));
            short cmd = Convert.ToInt16(attribute.NamedArguments[0].TypedValue.Value);
            _types.Add(type, cmd);
            _cmds.Add(cmd, type.Name);
        }
    }
}
