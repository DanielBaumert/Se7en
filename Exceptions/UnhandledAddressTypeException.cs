using System;
using System.Runtime.Serialization;

namespace Se7en.Exceptions
{
    [Serializable]
    internal class UnhandledAddressTypeException : Exception
    {
        public UnhandledAddressTypeException()
        {
        }

        public UnhandledAddressTypeException(string message) : base(message)
        {
        }

        public UnhandledAddressTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnhandledAddressTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}