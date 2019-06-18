using System.IO;
using System.Net.Sockets;

namespace Se7en.Net {

    public class SQLClient : INet {
        public TcpClient Client { get; }
        public NetworkStream NetworkStream { get; }
        public BinaryWriter StreamWriter { get; }
        public BinaryReader StreamReader { get; }
    }
}