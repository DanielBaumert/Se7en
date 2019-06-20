using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.Exceptions {
    public class LockedBitmapException : Exception {
        public LockedBitmapException(string message) : base(message) {
        }
    }
}
