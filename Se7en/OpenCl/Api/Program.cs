using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using Se7en.Utils;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Program : IRefCountedHandle
    {
        public readonly IntPtr Handle;

        internal Program(IntPtr handle) 
            => Handle = handle;

        public readonly bool ReferenceCount => Utils.GetTInfo<ProgramInfo, bool>(Handle, ProgramInfo.ReferenceCount, Cl.GetProgramInfo);
        public readonly Context Context => Utils.GetTInfo<ProgramInfo, Context>(Handle, ProgramInfo.Context, Cl.GetProgramInfo);
        public readonly uint NumDevices => Utils.GetTInfo<ProgramInfo, uint>(Handle, ProgramInfo.NumDevices, Cl.GetProgramInfo);
        public readonly Device[] Devices => Utils.GetTInfo<ProgramInfo, Device>(Handle, ProgramInfo.Devices, Cl.GetProgramInfo, out _);
        public readonly string Source => Utils.GetTInfo<ProgramInfo, byte>(Handle, ProgramInfo.Source, Cl.GetProgramInfo, out _).ToStrg();
        public readonly uint[] BinarySizes => Utils.GetTInfo<ProgramInfo, uint>(Handle, ProgramInfo.BinarySizes, Cl.GetProgramInfo, out _);
        public readonly byte[] Binaries => Utils.GetTInfo<ProgramInfo, byte>(Handle, ProgramInfo.Binaries, Cl.GetProgramInfo, out _);
        public readonly uint NumKernels => Utils.GetTInfo<ProgramInfo, uint>(Handle, ProgramInfo.NumKernels, Cl.GetProgramInfo);
        public readonly string[] KernelNames => Utils.GetTInfo<ProgramInfo, byte>(Handle, ProgramInfo.KernelNames, Cl.GetProgramInfo, out _ ).ToStrg().Split(';');
        public readonly string IL => Utils.GetTInfo<ProgramInfo, byte>(Handle, ProgramInfo.IL, Cl.GetProgramInfo, out _).ToStrg();
        public readonly bool ScopeGlobalCtorsPresent => Utils.GetTInfo<ProgramInfo, bool>(Handle, ProgramInfo.ScopeGlobalCtorsPresent, Cl.GetProgramInfo);
        public readonly bool ScopeGlobalDtorsPresent => Utils.GetTInfo<ProgramInfo, bool>(Handle, ProgramInfo.ScopeGlobalDtorsPresent, Cl.GetProgramInfo);

        #region IRefCountedHandle Members

        public ErrorCode Retain() 
            => Cl.RetainProgram(Handle);

        public ErrorCode Release() 
            => Cl.ReleaseProgram(Handle);

        #endregion

        #region IDisposable Members

        public void Dispose() 
            => Release();

        #endregion

        public static implicit operator IntPtr(Program program) 
            => program.Handle;
    }
}