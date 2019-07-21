using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Se7en.Network {

    public class TcpIpClient {

        public readonly TcpClient Client;
        public readonly NetworkStream Stream;
        public readonly BinaryReader Reader;
        public readonly BinaryWriter Writer;

        public event Action<TcpIpClient, string> ServerMessaged;
        public event Action<TcpIpClient> ClientDisconnected;

        public TcpIpClient(TcpClient client) {
            Client = client;
            Stream = Client.GetStream();
            Reader = new BinaryReader(Stream);
            Writer = new BinaryWriter(Stream);
            ServerMessaged = null;

            GetMessage();
        }

        public static bool Connect(string host, int port, out TcpIpClient ipcClient) {
            if (GetIP(host, out IPAddress entry)) {
                TcpClient client = new TcpClient();
                client.Connect(entry, port);
                ipcClient = new TcpIpClient(client);
                return true;
            }
            ipcClient = null;
            return false;
        }
        public void SendMessage(string msg) {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            Writer.Write(buffer);
        }

        private async void GetMessage() {
            const int BUFFER_LENGTH = 1024;
            byte[] buffer = new byte[BUFFER_LENGTH];
            while (Client.Connected) {
                using (MemoryStream memoryStream = new MemoryStream(buffer)) {
                    int count = -1;
                    while ((count = Reader.Read(buffer, 0, BUFFER_LENGTH)) != -1) {
                        await memoryStream.WriteAsync(buffer, 0, count);
                    }
                    ServerMessaged?.Invoke(this, Encoding.UTF8.GetString(memoryStream.ToArray()));
                }
            }
        }

        private static bool GetIP(string host, out IPAddress address) {
            address = null;
            if (!IPAddress.TryParse(host, out address)) {
                try {
                    IPAddress[] ips = Dns.GetHostAddresses(host);
                    if (ips.Length > 0) {
                        foreach (var ip in ips) {
                            if (ip.AddressFamily == AddressFamily.InterNetwork) {
                                address = ip;
                                return true;
                            }
                        }
                    }
                } catch {

                }
            }
            return false;
        }

        public void Disconnect() {
            if (Client != null) {
                Client.Close();
            }
        }
    }
}