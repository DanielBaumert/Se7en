#if Windows
using Se7en.Mathematic;
using Se7en.Windows.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    public delegate bool EnumDisplayMonitorsCallback(IntPtr hMonitor, IntPtr hdc, ref Rect lpRect, IntPtr lpParam);

    public delegate IntPtr LowLevelBasicHookCallback(int nCode, IntPtr wParam, IntPtr lParam);

    public unsafe delegate IntPtr LowLevelKeyboardHookCallback(int nCode, KeyboardButtonsState wParam, KeyBoardLowlevelHookStruct* lParam);
    public delegate void KeyboardHookCallback(string keyChar, KeyboardButtonsState wParam, KeyBoardLowlevelHookStruct lParam);
    /// <summary>
    /// The HOOKPROC type defines a pointer to this callback function. LowLevelMouseProc is a placeholder for the application-defined or library-defined function name.
    /// </summary>
    /// <param name="nCode">
    /// A code the hook procedure uses to determine how to process the message. If nCode is less than zero, the hook procedure must pass the message to the CallNextHookEx function without further processing and should return the value returned by CallNextHookEx. This parameter can be one of the following values.
    /// </param>
    /// <param name="wParam">
    /// The identifier of the mouse message.
    /// </param>
    /// <param name="lParam">
    /// A pointer to an MSLLHOOKSTRUCT structure.
    /// </param>
    /// <returns>
    /// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
    /// </returns>
    public unsafe delegate IntPtr LowLevelMouseHookCallback(int nCode, MouseButtonsState wParam, MouseLowlevelHookStruct* lParam);
    /// <summary>
    /// The HOOKPROC type defines a pointer to this callback function. LowLevelMouseProc is a placeholder for the application-defined or library-defined function name.
    /// </summary>
    /// <param name="nCode">
    /// A code the hook procedure uses to determine how to process the message. If nCode is less than zero, the hook procedure must pass the message to the CallNextHookEx function without further processing and should return the value returned by CallNextHookEx. This parameter can be one of the following values.
    /// </param>
    /// <param name="wParam">
    /// The identifier of the mouse message.
    /// </param>
    /// <param name="lParam">
    /// A MSLLHOOKSTRUCT structure.
    /// </param>
    /// <returns>
    /// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
    /// </returns>
    public delegate IntPtr MouseHookCallback(int nCode, MouseButtonsState wParam, MouseLowlevelHookStruct lParam);

    /// <summary>
    /// Device context handle
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct HDc {
        [FieldOffset(0)] 
        internal IntPtr Handle;  
        public static implicit operator IntPtr(HDc hdc) => hdc.Handle; 
        public unsafe static explicit operator HDc(IntPtr ptr) => *((HDc*)&ptr);
    }
    /// <summary>
    /// Window handle
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct HWnd {
        [FieldOffset(0)]
        internal IntPtr Handle;
        
        public static implicit operator IntPtr(HWnd hwnd) => hwnd.Handle;
        public unsafe static explicit operator HWnd(IntPtr ptr) => *((HWnd*)&ptr);
    }
    /// <summary>
    /// Region handle
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct HRng {
        [FieldOffset(0)]
        internal IntPtr Handle;
        public static implicit operator IntPtr(HRng hrng) => hrng.Handle;
        public unsafe static explicit operator HRng(IntPtr ptr) => *((HRng*)&ptr);
    }
    /// <summary>
    /// Bitmap handle
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct HBitmap
    {
        [FieldOffset(0)]
        internal IntPtr Handle;
        public static implicit operator IntPtr(HBitmap hrng) => hrng.Handle;
        public unsafe static explicit operator HBitmap(IntPtr ptr) => *((HBitmap*)&ptr);
    }
}
#endif