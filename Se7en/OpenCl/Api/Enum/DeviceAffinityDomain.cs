namespace Se7en.OpenCl.Api.Enum
{
    public enum DeviceAffinityDomain
    {

        DeviceAffinityDomainNuma = (1 << 0),
        DeviceAffinityDomainL4Cache = (1 << 1),
        DeviceAffinityDomainL3Cache = (1 << 2),
        DeviceAffinityDomainL2Cache = (1 << 3),
        DeviceAffinityDomainL1Cache = (1 << 4),
        DeviceAffinityDomainNextPartitionable = (1 << 5),
    }
}