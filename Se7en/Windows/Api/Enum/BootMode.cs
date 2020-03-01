namespace Se7en.Windows.Api.Enum
{
    /// <summary>
    /// Specifies the mode to start the computer
    /// in.
    /// </summary>
    public enum BootMode
    {
        /// <summary>
        /// Starts the computer in standard mode.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Starts the computer by using only the basic
        /// files and
        /// drivers.
        /// </summary>
        FailSafe = 1,
        /// <summary>
        /// Starts the computer by using the basic files, drivers and the services and drivers necessary to start networking.
        /// </summary>
        FailSafeWithNetwork = 2,
    }
}
