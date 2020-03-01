using System;

namespace Se7en.Exceptions.Network
{

    [Serializable]
    public class UnhandledAddressTypeException : System.Exception
    {
        public UnhandledAddressTypeException(string message) : base(message)
        {
        }
    }
}