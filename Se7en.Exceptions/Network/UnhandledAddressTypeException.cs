using System;

namespace Se7en.Exception.Network
{

    [Serializable]
    public class UnhandledAddressTypeException : System.Exception
    {
        public UnhandledAddressTypeException(string message) : base(message)
        {
        }
    }
}