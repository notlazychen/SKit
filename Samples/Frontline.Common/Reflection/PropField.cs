using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Frontline.Common.Reflection
{
    public class PropField
    {
        public PropField(FieldInfo fieldInfo)
        {
            FieldInfo = fieldInfo;
            ProtoMember = fieldInfo.GetCustomAttribute<ProtoMemberAttribute>();
            //如果是泛型的话, 类型就没这么简单啦
            if (fieldInfo.FieldType.IsGenericType)
            {
                var t1 = fieldInfo.FieldType;
                var name = t1.Name.Substring(0, t1.Name.IndexOf('`'));
                FieldTypeName = $"{name}<{string.Join(",", t1.GenericTypeArguments.Select(t => t.Name))}>";
            }
            else
            {
                FieldTypeName = fieldInfo.FieldType.Name;
            }

        }
        public FieldInfo FieldInfo { get; }
        public string FieldTypeName { get; }
        public ProtoMemberAttribute ProtoMember { get; }
    }
}
