using System;

namespace Se7en.OpenCl.Api.Enum
{
    [Flags]
    public enum SVMCapabilities
    {

        SvmCoarseGrainBuffer = (1 << 0),
        SvmFineGrainBuffer = (1 << 1),
        SvmFineGrainSystem = (1 << 2),
        SvmAtomics = (1 << 3),
    }
}