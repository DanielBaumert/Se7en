using System;

namespace Se7en {
    [Flags]
    public enum AlphanumericStyle {
       LowerCase = 1,
       UpperCase = 2,
       Both = LowerCase | UpperCase
    }
}