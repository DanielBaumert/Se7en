using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Se7en.Net
{
    public class TcpIpClient
    {
        private TcpClient Client;
        private NetworkStream NetworkStream;
        private BinaryReader StreamReader;
        private BinaryWriter StreamWriter;
        private Func<string> ReadStreamFun;

        public event Action<TcpIpClient, string> ResiveMessage;
        public event Action<TcpIpClient> ClientDisconnected;

        internal TcpIpClient(TcpClient client)
        {
            Client = client;
            NetworkStream = client.GetStream();
            StreamWriter = new BinaryWriter(NetworkStream);
            StreamReader = new BinaryReader(NetworkStream);

            ReadStreamFun = StreamReader.ReadString;
            ReadStreamFun.BeginInvoke(ResiveSteamMessage, null);
        }

        public TcpIpClient() { }
        public bool Connect(string host, int port)
        {

            if (IPAddress.TryParse(host, out IPAddress entry))
            {
                Client = new TcpClient();
                Client.Connect(entry, port);

                NetworkStream = Client.GetStream();
                StreamWriter = new BinaryWriter(NetworkStream);
                StreamReader = new BinaryReader(NetworkStream);

                ReadStreamFun = StreamReader.ReadString;
                ReadStreamFun.BeginInvoke(ResiveSteamMessage, null);
                return true;

            }
            return false;

        }

        private void ResiveSteamMessage(IAsyncResult result)
        {
            string message = ReadStreamFun.EndInvoke(result);
            ResiveMessage?.Invoke(this, message);

            ReadStreamFun.BeginInvoke(ResiveSteamMessage, null);
        }

        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            StreamWriter.Write(buffer, 0, buffer.Length);
            StreamWriter.Flush();
        }
    }
}
