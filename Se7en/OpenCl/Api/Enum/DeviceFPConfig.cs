namespace Se7en.OpenCl.Api.Enum
{
    public enum DeviceFPConfig
    {
        FpDenorm = (1 << 0),
        FpInfNan = (1 << 1),
        FpRoundToNearest = (1 << 2),
        FpRoundToZero = (1 << 3),
        FpRoundToInf = (1 << 4),
        FpFma = (1 << 5),
        FpSoftFloat = (1 << 6),
        FpCorrectlyRoundedDivideSqrt = (1 << 7)
    }
}
