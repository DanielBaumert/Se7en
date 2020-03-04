using System;

namespace Se7en
{
    /// <summary>
    /// The alphanumeric style likes upper and lower case
    /// </summary>
    [Flags]
    public enum AlphanumericStyle
    {
        /// <summary>
        /// Allow the lower case letter a-z
        /// </summary>
        LowerCase = 1,
        /// <summary>
        /// Allow the upper case letter A-Z
        /// </summary>
        UpperCase = 2,
        /// <summary>
        /// Allow the lower case and upper case letter a-zA-Z
        /// </summary>
        Both = LowerCase | UpperCase
    }
}