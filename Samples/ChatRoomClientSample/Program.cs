using SKit.Client;
using SKit.Base.Packagers;
using System;
using System.Net;
using System.Net.Sockets;

namespace ChatRoomClientSample
{
    class Program
    {
        static GameClient client;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            client = new GameClient(new StringMessagePackager());
            string ip = "127.0.0.1";
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), 2018);
            client.Start(ip, 2018);
            while (true)
            {
                string q = Console.ReadLine();
                if(q == "q")
                {
                    client.Stop();
                    break;
                }
                client.Send(q);
            }

        }

    }
}
