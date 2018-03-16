using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        private ILogger<ProtoBufSerializer> _logger;
        private IOptions<GameConfig> _config;
        public ProtoBufSerializer(IOptions<GameConfig> config, ILogger<ProtoBufSerializer> logger)
        {
            _config = config;
            _xorbytes = Encoding.UTF8.GetBytes(config.Value.Secret);
            _logger = logger;
        }

        public override string DataToCmd(byte[] data, int offset, int count)
        {
            short cmd = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, offset));

            string cmdName;
            if(_cmds.TryGetValue(cmd, out cmdName))
            {
                return cmdName;
            }
            _logger.LogWarning("NO CMD: {0}", cmd);
            return null;
        }

        public override Object Deserialize(Type type, byte[] data, int offset, int count)
        {
            offset += 2;
            int bodyLength = count - 2;
            MathEx.Xor(new ArraySegment<byte>(data, offset, bodyLength), _xorbytes);
            using (MemoryStream stream = new MemoryStream(data, offset, bodyLength))
            {
                stream.SetLength(bodyLength);
                var msg =  ProtoBuf.Serializer.Deserialize(type, stream);

                if (_config.Value.LogIO)
                {
                    _logger.LogDebug("[RECV]{0}:{1}", msg.GetType().Name, JsonConvert.SerializeObject(msg));
                }
                return msg;
            }
        }

        public override byte[] Serialize(Object entity)
        {
            short cmd;
            var type = entity.GetType();
            if (!_types.TryGetValue(type, out cmd)){

                var attribute = type.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType == typeof(ProtoAttribute));
                if(attribute == null)
                {
                    return null;
                }
                cmd = Convert.ToInt16(attribute.NamedArguments[0].TypedValue.Value);
                _types.Add(type, cmd);
                _cmds.Add(cmd, type.Name);
            }
            
            MemoryStream stream = new MemoryStream();
            ProtoBuf.Serializer.Serialize(stream, entity);
            var bytes = stream.ToArray();
            MathEx.Xor(bytes, _xorbytes);

            int offset = 0;
            var buffer = new byte[bytes.Length + 2];

            buffer[offset++] = (byte)((cmd >> 8) & 0xff);
            buffer[offset++] = (byte)(cmd & 0xff);

            Buffer.BlockCopy(bytes, 0, buffer, offset, bytes.Length);
            if (_config.Value.LogIO)
            {
                _logger.LogDebug("[SEND]{0}:{1}", entity.GetType().Name, JsonConvert.SerializeObject(entity));
            }
            return buffer;
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
