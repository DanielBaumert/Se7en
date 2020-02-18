namespace Se7en.OpenCl.Api.Enum
{
    public enum CommandQueueInfo : int // cl_int
    {
        /// <summary>
        /// the context specified when the command-queue is created
        /// </summary>
        Context = 0x1090,
        /// <summary>
        /// the device specified when the command-queue is created
        /// </summary>
        Device = 0x1091,
        /// <summary>
        /// the command-queue reference count
        /// </summary>
        ReferenceCount = 0x1092,
        /// <summary>
        /// the currently specified properties for the command-queue.<br/>
        /// These properties are specified by the value associated with the CL_​QUEUE_​PROPERTIES passed in properties argument in clCreateCommandQueueWithProperties.
        /// </summary>
        Properties = 0x1093,
        /// <summary>
        /// the currently specified size for the device command-queue.<br/>
        /// This query is only supported for device command queues
        /// </summary>
        Size = 0x1094
    }
}
