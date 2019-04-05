using System;
namespace Se7en.Exceptions
{
    [Serializable]
    internal class SocksConnectionException : Exception
    {
        public SocksConnectionException(string message) : base(message)
        {
        }
    }
}