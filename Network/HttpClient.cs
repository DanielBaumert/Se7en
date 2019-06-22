using System;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Se7en.Network {
    public class HttpClient : INet {
        //todo useragent
        //private readonly UserAgent _userAgent;
        
        private readonly string NewLine = "\r\n";
        private readonly Regex _DomainSrc = new Regex(@"^(?:https?:\/\/)?((?!\_|\-)(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\.)+[a-z0-9][a-z0-9-]{0,61}[a-z0-9])");
        public TcpClient Client { get; private set; }
        public NetworkStream NetworkStream { get; private set; }
        public BinaryWriter StreamWriter { get; private set; }
        public BinaryReader StreamReader { get; private set; }

        //public HttpClient(UserAgent userAgent = null)
        //{
        //    _userAgent = userAgent ?? UserAgent.CreateRandom();
        //}
        

        public void Request(string methode, string webpage) {
            webpage = webpage.Trim();
            if (_DomainSrc.IsMatch(webpage)) {
                string domain = _DomainSrc.Match(webpage).Groups[1].Value;
                string path = webpage.Length != domain.Length
                    ? webpage.Substring(domain.Length + 1)
                    : string.Empty;

                if (webpage[5] != 's') {
                    domain = domain.Substring(7);
                    StreamWriter.Write($"{methode} /{path} HTTP/1.1{NewLine}");
                    StreamWriter.Write($"Host: {domain}{NewLine}");
                    StreamWriter.Write($"{NewLine}");

                    while (NetworkStream.DataAvailable) {
                        Console.WriteLine(StreamReader.ReadString());
                    }
                } else {
                }
            }
        }

        public static explicit operator HttpClient(Socks5Client client) => (HttpClient)client;
    }
}