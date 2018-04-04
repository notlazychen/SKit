using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using protocol;
using ProtoBuf;

namespace Frontline.MQ
{
    public class ServerAction
    {
        public Type Type { get; set; }

        public Action<ServerSession, object> Action { get; set; }
    }

    public class ModuleManager
    {
        private readonly Dictionary<short, ServerAction> _commandsDic = new Dictionary<short, ServerAction>();
        
        public readonly List<ModuleBase> Modules = new List<ModuleBase>();

        public ModuleManager()
        {
        }

        public void AddModule(ModuleBase module)
        {
            Prepare(module.GetType(), module);
        }

        public void ReflectInitialize()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(ModuleBase)))
                    {
                        var handlerInstance = Activator.CreateInstance(type);
                        Modules.Add(handlerInstance as ModuleBase);
                        Prepare(type, handlerInstance);
                    }
                }
            }
        }

        private void Prepare(Type type, Object handlerInstance)
        {
            var methods = type.GetMethods();
            foreach (MethodInfo methodInfo in methods)
            {
                var arguments = methodInfo.GetParameters();
                if (arguments.Length != 2)
                    continue;
                Type requestType = arguments[1].ParameterType;
                var protocolAttribute = requestType.GetCustomAttributesData().FirstOrDefault(a => a.AttributeType == typeof(ProtoAttribute));
                if (protocolAttribute == null)
                    continue;
                short cmd = Convert.ToInt16(protocolAttribute.NamedArguments[0].TypedValue.Value);
                var info = methodInfo;
                Action<ServerSession, object> action = (session, o) => info.Invoke(handlerInstance, new[] { session, o });
                ServerAction serverAction = new ServerAction()
                {
                    Action = action,
                    Type = requestType,
                };
                _commandsDic.Add(cmd, serverAction);
            }
        }

        public Type QueryType(short cmd)
        {
            ServerAction gc;
            if (_commandsDic.TryGetValue(cmd, out gc))
            {
                return gc.Type;
            }
            return null;
        }

        public ServerMessageInfo Parse(ArraySegment<byte> data)
        {
            int offset = data.Offset;
            short cmd = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data.Array, data.Offset));
            offset += 2;
            Type type = this.QueryType(cmd);
            //MathUtils.Xor(new ArraySegment<byte>(data.Array, offset, data.Count - 2 - headerSize), Encoding.UTF8.GetBytes("whoareyou?"));
            using (MemoryStream stream = new MemoryStream(data.Array, offset, data.Count - 2))
            {
                var entity = Serializer.Deserialize(type, stream);
                //var r = ProtoBuf.Serializer.Deserialize<MatchRequest>(stream);
                //var desMethod = _deserializeMethod.MakeGenericMethod(type);
                //object entity = desMethod.Invoke(null, new object[] { stream });
                return new ServerMessageInfo()
                {
                    Cmd = cmd,
                    Type = type,
                    Entity = entity
                };
            }
        }

        public void ProcessAction(ServerSession session, ServerMessageInfo requestInfo)
        {
            ServerAction cmd;
            if (_commandsDic.TryGetValue(requestInfo.Cmd, out cmd))
            {
                cmd.Action(session, requestInfo.Entity);
            }
        }
    }
}
