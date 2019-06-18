using Se7en.Exceptions;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Se7en.Net {

    public class Socks5Client : INet {
        private const SocksVerion VERSION = SocksVerion.Version5;
        private const ConnectionMode CONNECTION_MODE = ConnectionMode.TcpIpStream;

        public TcpClient Client { get; private set; }
        public NetworkStream NetworkStream { get; private set; }
        public BinaryWriter StreamWriter { get; private set; }
        public BinaryReader StreamReader { get; private set; }

        public static Socks5Client Connect(string socksHost, int socksPort, string entryHost, int entryPort) {
            using (Ping ping = new Ping()) {
                PingReply replySocks = ping.Send(socksHost);

                if (replySocks.Status != IPStatus.Success) {
                    throw new HostUnreachableException();
                }

                TcpClient client = new TcpClient();
                client.Connect(socksHost, socksPort);

                return new Socks5Client(client, replySocks.Address, socksPort, entryHost, entryPort);
            }
        }

        private Socks5Client(TcpClient client, IPAddress socksAddress, int socksPort, string entryHost, int entryPort) {
            Client = client;

            NetworkStream = client.GetStream();
            StreamWriter = new BinaryWriter(NetworkStream);
            StreamReader = new BinaryReader(NetworkStream);

            byte[] ipBuffer = socksAddress.GetAddressBytes();
            byte[] portBuffer = BitConverter.GetBytes(socksPort);
            byte[] entryHostBuffer;
            TargetAddressType addressType;
            if (IPAddress.TryParse(entryHost, out IPAddress entryIp)) {
                if (entryIp.AddressFamily == AddressFamily.InterNetwork) {
                    entryHostBuffer = entryIp.GetAddressBytes();
                    addressType = TargetAddressType.IPV4;
                } else if (entryIp.AddressFamily == AddressFamily.InterNetworkV6) {
                    entryHostBuffer = entryIp.GetAddressBytes();
                    addressType = TargetAddressType.IPv6;
                } else {
                    throw new UnhandledAddressTypeException(entryIp.AddressFamily.ToString());
                }
            } else {
                entryHostBuffer = Encoding.ASCII.GetBytes(entryHost);
                addressType = TargetAddressType.Domain;
            }

            //
            //  +----+----------+----------+
            //  |VER | NMETHODS | METHODS  |
            //  +----+----------+----------+
            //  | 1  |    1     | 1 to 255 |
            //  +----+----------+----------+
            //

            StreamWriter.Write(new[]{
                (byte)VERSION, //Socket version [VER]
                (byte)0x01, //supportet methods count [NMETHODS]
                (byte)AuthenticationType.NoAuthentication //Auth. methode [METHODS]
            });

            //                   X'00' NO AUTHENTICATION REQUIRED
            //  +----+--------+  X'01' GSSAPI
            //  |VER | METHOD |  X'02' USERNAME/PASSWORD
            //  +----+--------+  X'03' to X'7F' IANA ASSIGNED
            //  | 1  |   1    |  X'80' to X'FE' RESERVED FOR PRIVATE METHODS
            //  +----+--------+  X'FF' NO ACCEPTABLE METHODS
            //
            byte[] response = {
            StreamReader.ReadByte(), //Socket Version [VER]
            StreamReader.ReadByte()  //seleced Auth. method [METHOD ]
        };

            if (response[1] == (byte)AuthenticationType.NoAcceptableMethods) {
                Client.Close();
                throw new NotAcceptableAuthenticationTypeException();
            }

            //
            // +----+-----+-------+------+----------+----------+
            // |VER | CMD |  RSV  | ATYP | DST.ADDR | DST.PORT |
            // +----+-----+-------+------+----------+----------+
            // | 1  |  1  | X'00' |  1   | Variable |    2     |
            // +----+-----+-------+------+----------+----------+
            // CMD: CONNECT X'01', BIND X'02', UDP ASSOCIATE X'03'
            // ATYP: IP V4 address: X'01', DOMAINNAME: X'03', IP V6 address: X'04'

            StreamWriter.Write(new[]{
                        (byte) VERSION, // Socks version [VER]
                        (byte) CONNECTION_MODE, // Connection mode [CMD]
                        (byte) 0x00, // reserved [RSV]
                        (byte) TargetAddressType.Domain, // address type of following address
                    });

            switch (addressType) {
                case TargetAddressType.IPv6:
                case TargetAddressType.IPV4:
                    StreamWriter.Write(entryHostBuffer);
                    break;

                case TargetAddressType.Domain:
                    StreamWriter.Write((byte)entryHost.Length); // desired destination address length
                    StreamWriter.Write(entryHostBuffer); //desired destination address
                    break;
            }

            StreamWriter.Write(new[] {
                        (byte) (entryPort >> 8), // desired destination port in network octet order - block A
                        (byte) (entryPort & 0xff)  // desired destination port in network octet order - block b
                    });

            //
            // +----+-----+-------+------+----------+----------+
            // |VER | REP |  RSV  | ATYP | BND.ADDR | BND.PORT |
            // +----+-----+-------+------+----------+----------+
            // | 1  |  1  | X'00' |  1   | Variable |    2     |
            // +----+-----+-------+------+----------+----------+
            //

            byte version = StreamReader.ReadByte();
            byte replay = StreamReader.ReadByte();
            byte reserved = StreamReader.ReadByte();
            byte addressTypeResponse = StreamReader.ReadByte();

            byte[] bindeAddressBuffer;
            int bindPort = 0;

            switch (addressType) {
                case TargetAddressType.IPV4:
                    bindeAddressBuffer = StreamReader.ReadBytes(4);
                    break;

                case TargetAddressType.Domain:
                    byte bindAddresslength = StreamReader.ReadByte();
                    bindeAddressBuffer = StreamReader.ReadBytes(bindAddresslength);
                    break;

                case TargetAddressType.IPv6:
                    bindeAddressBuffer = StreamReader.ReadBytes(16);
                    break;

                default:
                    Client.Close();
                    throw new InternelNetworkExceptiopn();
            }

            //byte a = StreamReader.ReadByte();
            //byte b = StreamReader.ReadByte();

            bindPort = StreamReader.ReadByte() << 8 | (StreamReader.ReadByte());

            if ((SocksError)replay != SocksError.RequestGranted) {
                Client.Close();
                throw new SocksConnectionException($"{replay}-v.{version}-port:{bindPort}");
            }
        }
    }
}