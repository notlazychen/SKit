using System;
using System.Diagnostics;
using Frontline.Common;
using Frontline.Common.Network;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using protocol;
using SKit.Client;
using SKit.Common;

namespace Frontline.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stopwatch sw = new Stopwatch();
            while (true)
            {
                sw.Restart();
                //var ok = Parallel.For(0, 500, (i) =>
                //{
                //    var client = CreateClient();
                //}).IsCompleted;
                for (int i = 0; i < 500; i++)
                {
                    CreateClient();
                    //Thread.Sleep(100);
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                Console.ReadLine();
            }


            //while (true)
            //{
            //    string q = Console.ReadLine();
            //    if (q == "q")
            //    {
            //        client.Stop();
            //        break;
            //    }
            //    long ts = DateTime.UtcNow.ToFileTimeUtc();
            //    client.Send(ts.ToString());
            //}


        }

        private static GameClient CreateClient()
        {
            //1 创建客户端
            GameClient client = new GameClient(new ProtoBufSerializer(new GameServerSettings()
            {
                DESKey = "421w6tW1ivg=",
                Secret = "whoareyou?"
            }, new ConsoleLogger("A", (s, level) => true, true)));
            //string ip = "192.168.1.5";
            string ip = "139.196.21.206";
            //string ip = "101.132.118.172";

            //注册接收
            client.Register<String>();
            client.MessageReceived += Client_MessageReceived;
            //启动
            client.Start(ip, 6003);

            client.Send(new AuthRequest() {
                
            });
            return client;
        }

        private static void Client_MessageReceived(object sender, object e)
        {
            string msg = e as string;
            DateTime dt = DateTime.FromFileTimeUtc(long.Parse(msg));

            TimeSpan delta = DateTime.UtcNow - dt;

            Console.WriteLine("耗时：{0}", delta.TotalMilliseconds);
        }
    }
}
