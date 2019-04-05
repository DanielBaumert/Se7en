using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.Net
{
    public class SQLClient : INet
    {
        public TcpClient Client { get; }
        public NetworkStream NetworkStream { get; }
        public BinaryWriter StreamWriter { get; }
        public BinaryReader StreamReader { get; }
    }
}
