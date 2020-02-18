using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using Se7en.Utils;
using System;

namespace Se7en.OpenCl
{
    public readonly unsafe struct OpenClCompiler : IDisposable
    {
        public readonly static Platform[] Platforms;
        public readonly static uint PlatformCount;

        private readonly Context _ctx;
        private readonly Program _program;
        private readonly Device _device;
        private readonly Kernel[] _kernels;

        public readonly bool IsCoarseGrainBufferSupported;
        public readonly bool IsFineGrainBufferSupported;
        public readonly bool IsFineGrainSystemSupported;
        public readonly bool IsAtomicSupported;

        public readonly string Source;
        public readonly uint KernelCount;
        public readonly string[] Methodes;

        static OpenClCompiler()
        {
             Cl.GetPlatformIDs(0, null, out PlatformCount);
            Platforms = new Platform[PlatformCount];
             Cl.GetPlatformIDs(PlatformCount, Platforms, out _);
        }

        public OpenClCompiler(string source, DeviceType type = DeviceType.Gpu)
            : this(GetDevice(ref type), source)
        {
        }
        public OpenClCompiler(string source, string name)
            : this(GetDevice(name), source)
        {
        }

        public OpenClCompiler(Device device, string source)
        {
            _device = device;
            _ctx = device.CreateContext();

            SVMCapabilities capabilities = _device.SvmCapabilities;

            IsCoarseGrainBufferSupported = (capabilities & SVMCapabilities.SvmCoarseGrainBuffer) == SVMCapabilities.SvmCoarseGrainBuffer;
            IsFineGrainBufferSupported = (capabilities & SVMCapabilities.SvmFineGrainBuffer) == SVMCapabilities.SvmFineGrainBuffer;
            IsFineGrainSystemSupported = (capabilities & SVMCapabilities.SvmFineGrainSystem) == SVMCapabilities.SvmFineGrainSystem;
            IsAtomicSupported = (capabilities & SVMCapabilities.SvmAtomics) == SVMCapabilities.SvmAtomics;

            Source = source;
            _program = new Program(Cl.CreateProgramWithSource(_ctx, 1, new string[] { source }, null, out ErrorCode error));
            Cl.BuildProgram(_program, 1, new[] { _device }, string.Empty, null, IntPtr.Zero);

            KernelCount = _program.NumKernels;
            Methodes = _program.KernelNames;

            _kernels = new Kernel[KernelCount];

            Cl.CreateKernelsInProgram(_program, KernelCount, _kernels, out _);
        }

#if X64
        public void AllocSvmMemory(long size)
        {

        }
#elif X86
        public void AllocSvmMemory(int size)
        {

        }
#else
        public SvmPointer AllocSvmMemory(IntPtr size)
        {
            SVMMemFlags flags = SVMMemFlags.ReadWrite;
            if (IsFineGrainBufferSupported)
            {
                flags = SVMMemFlags.FineGrainBuffer;
                if (IsAtomicSupported)
                {
                    flags |= SVMMemFlags.Atomic;
                }
            }
            return new SvmPointer(_ctx, Cl.SVMAlloc(_ctx, flags, size));
        }
        public SvmPointer AllocSvmMemory(IntPtr size, SVMMemFlags flags)
            => new SvmPointer(_ctx, Cl.SVMAlloc(_ctx, flags, size));
        public SvmPointer<T> AllocSvmMemory<T>(IntPtr size)
           where T : unmanaged
        {
            SVMMemFlags flags = SVMMemFlags.ReadWrite;
            if (IsFineGrainBufferSupported)
            {
                flags = SVMMemFlags.FineGrainBuffer;
                if (IsAtomicSupported)
                {
                    flags |= SVMMemFlags.Atomic;
                }
            }
            return (SvmPointer<T>)new SvmPointer(_ctx, Cl.SVMAlloc(_ctx, flags, new IntPtr((long)size * sizeof(T))));
        }
        public SvmPointer<T> AllocSvmMemory<T>(IntPtr size, SVMMemFlags flags)
        where T : unmanaged
        => (SvmPointer<T>)new SvmPointer(_ctx, Cl.SVMAlloc(_ctx, flags, new IntPtr((long)size * sizeof(T))));
#endif

        public OpenClBridge GetMethode(string methodName)
            => new OpenClBridge(_ctx, _device, _kernels.First(kernel => kernel.FunctionName == methodName));

        private static Device GetDevice(ref DeviceType type)
        {
            foreach (Platform platform in Platforms)
            {
                Device[] devices = platform.GetDevices();
                foreach (Device device in devices)
                {
                    if ((device.Type & type) == type)
                    {
                        return device;
                    }
                }
            }
            throw new Exception("target device type not found");
        }
        private static Device GetDevice(string name)
        {
            foreach (Platform platform in Platforms)
            {
                Device[] devices = platform.GetDevices();
                foreach (Device device in devices)
                {
                    if (device.Name.Contains(name))
                    {
                        return device;
                    }
                }
            }
            throw new Exception("target device type not found");
        }
        public void Dispose()
        {
            foreach (Kernel kernel in _kernels)
            {
                kernel.Dispose();
            }

            _program.Dispose();
            _ctx.Dispose();
            _device.Dispose();

        }
    }
}
