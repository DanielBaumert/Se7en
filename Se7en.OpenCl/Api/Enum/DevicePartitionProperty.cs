namespace Se7en.OpenCl.Api.Enum
{
    public enum DevicePartitionProperty
    {
        /// <summary>
        /// Split the aggregate device into as many smaller aggregate devices as can be created, each containing n compute units.<br/>
        /// The value n is passed as the value accompanying this property.<br/>
        /// If n does not divide evenly into CL_​DEVICE_​MAX_​COMPUTE_​UNITS, then the remaining compute units are not used.<br/>
        /// </summary>
        DevicePartitionEqually = 0x1086,
        /// <summary>
        /// This property is followed by a list of compute unit counts terminated with 0 or CL_​DEVICE_​PARTITION_​BY_​COUNTS_​LIST_​END.<br/>
        /// For each non-zero count m in the list, a sub-device is created with m compute units in it.<para/> 
        /// The number of non-zero count entries in the list may not exceed CL_​DEVICE_​PARTITION_​MAX_​SUB_​DEVICES.<para/>
        /// The total number of compute units specified may not exceed CL_​DEVICE_​MAX_​COMPUTE_​UNITS.
		/// </summary>
        DevicePartitionByCounts = 0x1087,
        DevicePartitionByCountsListEnd = 0x0,
        DevicePartitionByAffinityDomain = 0x1088,
    }
}