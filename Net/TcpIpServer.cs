using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Se7en.Net {

    public abstract class TcpIpServer {

        public event Action<TcpIpClient> ClientConnected;

        public int Port { get; private set; }
        public ref readonly List<TcpIpClient> Clients => ref _Clients;
        private List<TcpIpClient> _Clients;
        private TcpListener _TcpListener;

        public void Start(IPAddress address, int port) {
            Port = port;
            _Clients = new List<TcpIpClient>();
            _TcpListener = new TcpListener(address, port);
            _TcpListener.Start();
            _TcpListener.BeginAcceptTcpClient(AcceptClient, null);
        }

        public void Stop() {
            if (_TcpListener != null) {
                _TcpListener.Stop();
            }
        }

        private void AcceptClient(IAsyncResult result) {
            TcpClient client = _TcpListener.EndAcceptTcpClient(result);
            TcpIpClient ipClient = new TcpIpClient(client);
            if (AccessRequest(ipClient)) {
                _Clients.Add(ipClient);
                ipClient.ResiveMessage += ClienMessageResieve;
                ipClient.ClientDisconnected += IpClient_ClientDisconnected;
                ;
                ipClient.ClientDisconnected += ClientDisconnected;
                ClientConnected?.Invoke(ipClient);
            } else {
                client.Close();
            }
            _TcpListener.BeginAcceptTcpClient(AcceptClient, null);
        }

        private void IpClient_ClientDisconnected(TcpIpClient arg1) {
            Clients.Remove(arg1);
        }

        public abstract bool AccessRequest(TcpIpClient client);

        public abstract void ClienMessageResieve(TcpIpClient client, string message);

        public abstract void ClientDisconnected(TcpIpClient client);

        public void SendMessageAll(string message) => Parallel.ForEach(_Clients, client => client.SendMessage(message));

        public void SendMessageClient(TcpIpClient client, string message) => client.SendMessage(message);
    }
}