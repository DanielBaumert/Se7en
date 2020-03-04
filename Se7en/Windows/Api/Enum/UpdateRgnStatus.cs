#if Windows
namespace Se7en.Windows.Api.Enum
{
    public enum RgnStatus : int
    {
        /// <summary>
        /// An error occurred.
        /// </summary>
        Error = 0,
        /// <summary>
        /// Region is empty.
        /// </summary>
        NullRegion = 1,
        /// <summary>
        /// Region is a single rectangle.
        /// </summary>
        SimpleRegion = 2,
        /// <summary>
        /// Region consists of more than one rectangle.
        /// </summary>
        ComplexRegion = 3
    }
}
#endif