using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using Se7en.Utils;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Kernel : IRefCountedHandle
    {
        public readonly IntPtr Handle;

        internal Kernel(IntPtr handle)
            => Handle = handle;

        public readonly string FunctionName => Utils.GetTInfo<KernelInfo, byte>(Handle, KernelInfo.FunctionName, Cl.GetKernelInfo, out _).ToStrg();
        public readonly int NumArgs => Utils.GetTInfo<KernelInfo, int>(Handle, KernelInfo.NumArgs, Cl.GetKernelInfo);
        public readonly uint ReferenceCount => Utils.GetTInfo<KernelInfo, uint>(Handle, KernelInfo.ReferenceCount, Cl.GetKernelInfo);
        public readonly Context Context => Utils.GetTInfo<KernelInfo, Context>(Handle, KernelInfo.Context, Cl.GetKernelInfo);
        public readonly Program Program => Utils.GetTInfo<KernelInfo, Program>(Handle, KernelInfo.Program, Cl.GetKernelInfo);
        public readonly byte[] Attributes => Utils.GetTInfo<KernelInfo, byte>(Handle, KernelInfo.Attributes, Cl.GetKernelInfo, out _);
        public readonly uint MaxNumSubGroups => Utils.GetTInfo<KernelInfo, uint>(Handle, KernelInfo.MaxNumSubGroups, Cl.GetKernelInfo);
        public readonly uint CompileNumSubGroups => Utils.GetTInfo<KernelInfo, uint>(Handle, KernelInfo.CompileNumSubGroups, Cl.GetKernelInfo);


        #region IRefCountedHandle Members

        public ErrorCode Retain() 
            => Cl.RetainKernel(this);

        public ErrorCode Release() 
            => Cl.ReleaseKernel(this);

        #endregion

        #region IDisposable Members

        public void Dispose() 
            => Release();

        #endregion


        public static implicit operator IntPtr(Kernel kernel) => kernel.Handle;
    }
}
