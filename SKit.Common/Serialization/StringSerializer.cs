using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SKit.Common.Serialization
{
    /// <summary>
    /// 极简字符串序列化和反序列化
    /// </summary>
    public class StringSerializer : Serializer
    {
        public override string DataToCmd(byte[] data, int offset, int count)
        {
            return "String";
        }

        //public override string EntityToCmd(Object entity)
        //{
        //    Debug.Assert(entity is string, "只能序列化string类型消息");
        //    return "String";
        //}

        public override Object Deserialize(Type type, byte[] data, int offset, int count)
        {
            return Encoding.UTF8.GetString(data, offset, count);
        }

        public override byte[] Serialize(Object entity)
        {
            var data = Encoding.UTF8.GetBytes(entity as string);
            return data;
        }        
    }
}
