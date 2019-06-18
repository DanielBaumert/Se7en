using System;
using System.Runtime.Serialization;

namespace Se7en.Exceptions {

    [Serializable]
    internal class InternelNetworkExceptiopn : Exception {

        public InternelNetworkExceptiopn() {
        }

        public InternelNetworkExceptiopn(string message) : base(message) {
        }

        public InternelNetworkExceptiopn(string message, Exception innerException) : base(message, innerException) {
        }

        protected InternelNetworkExceptiopn(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}