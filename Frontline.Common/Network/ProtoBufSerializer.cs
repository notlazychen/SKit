using ProtoBuf;
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

namespace CommandOfFrontline.Common.Network
{
    /// <summary>
    /// 极简字符串序列化和反序列化
    /// </summary>
    public class ProtoBufSerializer : SKit.Common.Serializer
    {
        private MethodInfo _deserializeMethod;
        private Dictionary<Type, Delegate> _deserializeHandlers = new Dictionary<Type, Delegate>();

        public ProtoBufSerializer()
        {
            _deserializeMethod = typeof(ProtoBuf.Serializer).GetMethods()
                .FirstOrDefault(ms => ms.Name == "Deserialize" && ms.IsGenericMethod && ms.IsStatic);
        }

        private static byte[] Xorbytes = Encoding.UTF8.GetBytes("whoareyou?");
        public override string DataToCmd(byte[] data, int offset, int count)
        {
            short cmd = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, offset));
            return cmd.ToString();
        }

        public override Object Deserialize(Type type, byte[] data, int offset, int count)
        {
            Delegate action;
            if (_deserializeHandlers.TryGetValue(type, out action))
            {
                offset += 2;
                int bodyLength = count - 2;
                MathEx.Xor(new ArraySegment<byte>(data, offset, bodyLength), Xorbytes);
                using (MemoryStream stream = new MemoryStream(data, offset, bodyLength))
                {
                    stream.SetLength(bodyLength);
                    action.DynamicInvoke(stream);
                    var desMethod = _deserializeMethod.MakeGenericMethod(type);
                    object msg = desMethod.Invoke(null, new object[] { stream });
                    return msg;
                }
            }
            return null;//未注册的类型
        }

        public override byte[] Serialize<T>(T entity)
        {
            var data = Encoding.UTF8.GetBytes(entity as string);
            return data;
        }

        public override void Register(Type type)
        {
            Type[] templateTypeSet = new[] { type };
            Type methodGenericType = typeof(Action<>);
            Type methodType = methodGenericType.MakeGenericType(templateTypeSet);
            Delegate actionMethod = Delegate.CreateDelegate(methodType, _deserializeMethod);
            _deserializeHandlers.Add(type, actionMethod);
        }
    }
}
