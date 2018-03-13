using SKit.Client;
using SKit.Common.Packagers;
using SKit.Common.Serialization;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace ChatRoomClientSample
{
    class Program
    {
        static GameClient client;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //1 创建客户端
            client = new GameClient(new StringMessagePackager(), new StringSerializer());
            string ip = "127.0.0.1";
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), 2018);
            
            //注册接收
            client.Register<String>();
            client.MessageReceived += Client_MessageReceived;

            //启动
            client.Start(ip, 2018);

            //Task t = new Task(()=>
            //{
            //    while (true)
            //    {
            //        long ts = DateTime.Now.ToFileTimeUtc();
            //        client.Send(ts.ToString());
            //        Thread.Sleep(1000);
            //    }
            //});
            //t.Start();
            while (true)
            {
                string q = Console.ReadLine();
                if (q == "q")
                {
                    client.Stop();
                    break;
                }
                long ts = DateTime.Now.ToFileTimeUtc();
                client.Send(ts.ToString());
            }
        }

        private static void Client_MessageReceived(object sender, object e)
        {
            string msg = e as string;
            DateTime dt = DateTime.FromFileTimeUtc(long.Parse(msg));

            TimeSpan delta = DateTime.Now - dt;
            Console.WriteLine("耗时：{0}", delta.Milliseconds);
        }
    }
}
