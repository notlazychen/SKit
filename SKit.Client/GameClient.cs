using SKit.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace SKit.Client
{
    public class GameClient
    {
        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private byte[] _recvbuffer = new byte[10240];
        private byte[] _sendbuffer = new byte[10240];
        private int _cursor;
        private ISPackager _packager;
        private ISerializable _serializable;
        private Dictionary<string, Type> _actions = new Dictionary<string, Type>();

        public event EventHandler<Object> MessageReceived;

        public GameClient(ISPackager packager, ISerializable serializable)
        {
            _packager = packager;
            _serializable = serializable;
        }

        public void Start(string ip, int port)
        {
            _tcpClient = new TcpClient();
            _tcpClient.Connect(ip, port);
            
            _stream = _tcpClient.GetStream();            
            var result = _stream.BeginRead(_recvbuffer, 0, _recvbuffer.Length, OnRead, _stream);
        }

        public void Stop()
        {
            CloseSocket();
        }

        public void Send(Object msg)
        {
            var body = _serializable.Serialize(msg);
            var data = _packager.Pack(body, _sendbuffer, 0, _sendbuffer.Length);           
            _stream.Write(data.Array, data.Offset, data.Count);
        }

        /// <summary>
        /// 拆包
        /// </summary>
        private IEnumerable<ArraySegment<byte>> Resolve(int size)
        {
            int from = 0;
            _cursor += size;//剩余可读取字节

            while (true)
            {
                var readlength = 0;
                ArraySegment<byte> data = _packager.UnPack(_recvbuffer, from, _cursor, ref readlength);
                if (readlength != 0)
                {
                    yield return data;
                    _cursor -= readlength;
                    from += readlength;
                    continue;
                }
                break;
            }
            if (_cursor > 0)
            {
                Buffer.BlockCopy(_recvbuffer, from, _recvbuffer, 0, _cursor);
            }
            //e.SetBuffer(_cursor, _buffer.Length - _cursor);
        }

        private void OnRead(IAsyncResult ar)
        {
            NetworkStream stream = (NetworkStream)ar.AsyncState;
            var size = stream.EndRead(ar);

            // check if the remote host closed the connection
            if (size > 0)
            {
                var datas = Resolve(size);
                foreach (ArraySegment<byte> data in datas)
                {
                    OnMessageReceiving(data);
                }
                
                stream.BeginRead(_recvbuffer, _cursor, _recvbuffer.Length - _cursor, OnRead, stream);
                //PostReceive(receiveEventArgs);
            }
            else
            {
                CloseSocket();
            }
        }

        private void OnMessageReceiving(ArraySegment<byte> data)
        {
            string cmd = _serializable.DataToCmd(data.Array, data.Offset, data.Count);
            Type t = null;
            if(_actions.TryGetValue(cmd, out t))
            {
                var msg = _serializable.Deserialize(t, data.Array, data.Offset, data.Count);
                MessageReceived?.Invoke(this, msg);
            }
            else
            {
                throw new Exception("unregist message!");
            }
        }

        private void CloseSocket()
        {
            Console.WriteLine("连接关闭");
            _stream.Close();
            _tcpClient.Close();
        }

        public void Register<T>()
        {
            var type = typeof(T);
            _actions.Add(type.Name, type);
        }
    }
}
