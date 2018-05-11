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
        private ILogger _logger;
        private GameServerSettings _config;

        public ProtoBufSerializer(GameServerSettings config, ILogger logger)
        {
            _config = config;
            _xorbytes = Encoding.UTF8.GetBytes(_config.Secret);
            _logger = logger;
        }

        public ProtoBufSerializer(IOptions<GameServerSettings> config, ILogger<ProtoBufSerializer> logger)
        {
            _config = config.Value;
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
            MathUtils.Xor(new ArraySegment<byte>(data, offset, bodyLength), _xorbytes);
            using (MemoryStream stream = new MemoryStream(data, offset, bodyLength))
            {
                stream.SetLength(bodyLength);
                var msg =  ProtoBuf.Serializer.Deserialize(type, stream);

                if (_config.LogIO)
                {
                    _logger.LogDebug("[RECV]{0}:{1}", msg.GetType().Name, JsonConvert.SerializeObject(msg));
                }
                return msg;
            }
        }

        //public override byte[] Serialize(Object entity)
        //{
        //    short cmd;
        //    var type = entity.GetType();
        //    if (!_types.TryGetValue(type, out cmd)){

        //        var attribute = type.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType == typeof(ProtoAttribute));
        //        if(attribute == null)
        //        {
        //            return null;
        //        }
        //        cmd = Convert.ToInt16(attribute.NamedArguments[0].TypedValue.Value);
        //        _types.Add(type, cmd);
        //        _cmds.Add(cmd, type.Name);
        //    }
            
        //    MemoryStream stream = new MemoryStream();
        //    ProtoBuf.Serializer.Serialize(stream, entity);
        //    var bytes = stream.ToArray();
        //    MathUtils.Xor(bytes, _xorbytes);

        //    //2字节 short cmd
        //    //其他entity data
        //    int offset = 0;
        //    var data = new byte[bytes.Length + 2];

        //    data[offset++] = (byte)((cmd >> 8) & 0xff);
        //    data[offset++] = (byte)(cmd & 0xff);

        //    Buffer.BlockCopy(bytes, 0, data, offset, bytes.Length);
        //    if (_config.LogIO)
        //    {
        //        _logger.LogDebug("[SEND]{0}:{1}", entity.GetType().Name, JsonConvert.SerializeObject(entity));
        //    }
        //    return data;
        //}

        public override void Register(Type type)
        {
            var attribute = type.GetCustomAttributesData().First(a => a.AttributeType == typeof(ProtoAttribute));
            short cmd = Convert.ToInt16(attribute.NamedArguments[0].TypedValue.Value);
            _types.Add(type, cmd);
            _cmds.Add(cmd, type.Name);
        }

        private bool TryGetHeadLengthAndBodyLength(byte[] buffer, int offset, int length, out int headLength, out int bodyLength)
        {
            headLength = Varint.ByteArray2Int(new ArraySegment<byte>(buffer, offset, length), out bodyLength);
            return headLength > 0 && bodyLength > 0;
        }

        public override ArraySegment<byte> UnPack(byte[] buffer, int offset, int count, ref int readlength)
        {
            if (TryGetHeadLengthAndBodyLength(buffer, offset, count, out var headSize, out var bodySize))
            {
                int total = headSize + bodySize;
                if (total <= count)
                {
                    readlength = total;
                    return new ArraySegment<byte>(buffer, offset + headSize, bodySize);
                }
            }
            readlength = 0;
            return default(ArraySegment<byte>);
        }

        public override int Serialize(object entity, byte[] buffer, int length)
        {
            //组包
            short cmd;
            var type = entity.GetType();
            if (!_types.TryGetValue(type, out cmd))
            {

                var attribute = type.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType == typeof(ProtoAttribute));
                if (attribute == null)
                {
                    throw new Exception("not protobuf entity message!");
                }
                cmd = Convert.ToInt16(attribute.NamedArguments[0].TypedValue.Value);
                _types.Add(type, cmd);
                _cmds.Add(cmd, type.Name);
            }

            MemoryStream stream = new MemoryStream();
            ProtoBuf.Serializer.Serialize(stream, entity);
            var bytes = stream.ToArray();
            MathUtils.Xor(bytes, _xorbytes);

            //2字节 short cmd
            //其他entity data
            int offset = 0;
            var data = new byte[bytes.Length + 2];

            data[offset++] = (byte)((cmd >> 8) & 0xff);
            data[offset++] = (byte)(cmd & 0xff);

            Buffer.BlockCopy(bytes, 0, data, offset, bytes.Length);
            if (_config.LogIO)
            {
                _logger.LogDebug("[SEND]{0}:{1}", entity.GetType().Name, JsonConvert.SerializeObject(entity));
            }
            var head = Varint.Int2ByteArray(data.Length);
            int totalLength = head.Count + data.Length;
            if (length < totalLength)
            {
                throw new StackOverflowException("数据包大小超过设置的发送缓冲区");
            }
            Buffer.BlockCopy(head.Array, 0, buffer, 0, head.Count);//拷贝头
            Buffer.BlockCopy(data, 0, buffer, head.Count, data.Length);//拷贝数据
            return totalLength;
        }
    }
}
