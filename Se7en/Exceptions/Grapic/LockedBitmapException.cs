using System;

namespace Se7en.Exceptions.Grapic
{
    public class LockedBitmapException : Exception
    {
        public LockedBitmapException(string message) : base(message)
        {
        }
    }
}
