namespace Se7en.OpenCl.Api.Enum
{
    public enum PlatformInfo : uint
    {
        /// <summary>
        /// The profile name supported by the implementation.
        /// </summary>
        Profile = 0x0900,
        /// <summary>
        /// The OpenCL version supported by the implementation
        /// </summary>
        Version = 0x0901,
        /// <summary>
        /// Platform name.
        /// </summary>
        Name = 0x0902,
        /// <summary>
        /// Platform vendor.
        /// </summary>
        Vendor = 0x0903,
        /// <summary>
        /// Extension names supported by the platform.
        /// </summary>
        Extensions = 0x0904,
        /// <summary>
        /// The resolution of the host timer in nanoseconds
        /// </summary>
        Hosttimerresolution = 0x0905
    }
}