﻿using System.IO;
using System.Net.Sockets;

namespace Se7en.Network {

    public interface INet {
        TcpClient Client { get; }
        NetworkStream NetworkStream { get; }
        BinaryWriter StreamWriter { get; }
        BinaryReader StreamReader { get; }
    }
}