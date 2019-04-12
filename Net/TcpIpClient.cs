using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Se7en.Net
{
    public class TcpIpClient
    {
        private TcpClient _Client;
        private NetworkStream _NetworkStream;
        private BinaryReader _StreamReader;
        private BinaryWriter _StreamWriter;
        private Func<string> _ReadStreamFun;

        public event Action<TcpIpClient, string> ResiveMessage;
        public event Action<TcpIpClient> ClientDisconnected;

        internal TcpIpClient(TcpClient client) {
            _Client = client;
            _NetworkStream = client.GetStream();
            _StreamWriter = new BinaryWriter(_NetworkStream);
            _StreamReader = new BinaryReader(_NetworkStream);

            _ReadStreamFun = _StreamReader.ReadString;
            _ReadStreamFun.BeginInvoke(ResiveSteamMessage, null);
        }

        public TcpIpClient() { }
        public bool Connect(string host, int port) {

            if (GetIP(host, out IPAddress entry)) {
                _Client = new TcpClient();
                _Client.Connect(entry, port);

                _NetworkStream = _Client.GetStream();
                _StreamWriter = new BinaryWriter(_NetworkStream);
                _StreamReader = new BinaryReader(_NetworkStream);

                _ReadStreamFun = _StreamReader.ReadString;
                _ReadStreamFun.BeginInvoke(ResiveSteamMessage, null);
                return true;

            }
            return false;
        }
        private bool GetIP(string host, out IPAddress address) {
            address = null;
            if (!IPAddress.TryParse(host, out address)) {
                try {
                    IPAddress[] ips = Dns.GetHostAddresses(host);
                    if (ips.Length > 0) {
                        foreach (var ip in ips) {
                            if(ip.AddressFamily == AddressFamily.InterNetwork) {
                                address = ip;
                                return true;
                            }
                        }
                    } else {
                        return false;
                    }
                } catch {
                    return false;
                }
            }
            return true;
        }

        public void Disconnect() {
            if (_Client != null) {
                _Client.Close();
            }
        }

        private void ResiveSteamMessage(IAsyncResult result) {
            try {
                string message = _ReadStreamFun.EndInvoke(result);
                ResiveMessage?.Invoke(this, message);

                _ReadStreamFun.BeginInvoke(ResiveSteamMessage, null);
            } catch {
                ClientDisconnected?.Invoke(this);
            }
        }

        public void SendMessage(string message) {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            _StreamWriter.Write(buffer, 0, buffer.Length);
            _StreamWriter.Flush();
        }
    }
}
