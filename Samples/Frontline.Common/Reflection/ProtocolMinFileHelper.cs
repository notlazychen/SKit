using ProtoBuf;
using protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Frontline.Common.Reflection
{
    public static class ProtocolMinFileHelper
    {
        public static string ToFileContent()
        {

            var types = Assembly.Load("Frontline.Common")
                .GetTypes();
            var protocols = types
                .Where(type => type.Namespace == "protocol")
                .Where(type => type.GetCustomAttribute<ProtoContractAttribute>() != null)
                .ToList();

            var infos = protocols.Where(type => type.GetCustomAttribute<ProtoAttribute>() == null);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using ProtoBuf;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System;");
            sb.AppendLine("namespace protocol");
            sb.AppendLine("{");
            foreach (var info in infos)
            {
                sb.AppendLine($"    [ProtoContract]");
                sb.AppendLine($"    public class {info.Name}");
                sb.AppendLine("    {");

                var props = info.GetFields().Select(p => new PropField(p)).Where(p => p.ProtoMember != null).ToList();
                foreach (var prop in props)
                {
                    sb.AppendLine($"        [ProtoMember({prop.ProtoMember.Tag})]");
                    sb.AppendLine($"        public {prop.FieldTypeName} {prop.FieldInfo.Name};");
                }
                sb.AppendLine("    }");
            }

            var msgs = protocols.Select(type => new PropClass()
            {
                Type = type,
                Proto = type.GetCustomAttribute<ProtoAttribute>()
            }).Where(t => t.Proto != null).OrderBy(t => t.Proto.value).ToList();

            foreach (var info in msgs)
            {
                sb.AppendLine($"    [Proto(value = {info.Proto.value}, description = \"{info.Proto.description}\")]");
                sb.AppendLine($"    [ProtoContract]");
                sb.AppendLine($"    public class {info.Type.Name}");
                sb.AppendLine("    {");

                var props = info.Type.GetFields().Select(p => new PropField(p)).Where(p => p.ProtoMember != null).ToList();
                foreach (var prop in props)
                {
                    sb.AppendLine($"        [ProtoMember({prop.ProtoMember.Tag})]");
                    sb.AppendLine($"        public {prop.FieldTypeName} {prop.FieldInfo.Name};");
                }
                sb.AppendLine("    }");
            }
            sb.AppendLine("}");

            string text = sb.ToString();
            return text;
        }
    }
}
