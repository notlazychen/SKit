using Frontline.Common.Reflection;
using ProtoBuf;
using protocol;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Frontline.ProtocolExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = ProtocolMinFileHelper.ToFileContent();

            File.WriteAllText("Protocols.cs", text);

            Console.WriteLine("转换结束, 按任意键退出");
            Console.ReadLine();
        }
    }
}
