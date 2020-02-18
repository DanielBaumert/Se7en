using System;

namespace Se7en.Exception.Network
{

    [Serializable]
    public class SocksConnectionException : System.Exception
    {
        public SocksConnectionException(string message) : base(message)
        {
        }
    }
}