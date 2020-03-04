#if Windows
using Se7en.Mathematic;
using Se7en.Windows.Api.Enum;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Se7en.Windows.Api.Native
{
    public static class User32
    {

#region winuser.h
#region ShowWindow
        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="cmdShow">
        /// Controls how the window is to be shown.<br/>
        /// This parameter is ignored the first time an application calls ShowWindow, if the program that launched the application provides a STARTUPINFO structure.<br/>
        /// Otherwise, the first time ShowWindow is called, the value should be the value obtained by the WinMain function in its nCmdShow parameter.<br/>
        /// In subsequent calls, this parameter can be one of the following values.
        /// </param>
        /// <returns>
        /// If the window was previously visible, the return value is nonzero.<param/>
        /// If the window was previously hidden, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "ShowWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow([In] HWnd hWnd, [In] [MarshalAs(UnmanagedType.I4)] ShowWindowCommands cmdShow);
        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="cmdShow">
        /// Controls how the window is to be shown.<br/>
        /// This parameter is ignored the first time an application calls ShowWindow, if the program that launched the application provides a STARTUPINFO structure.<br/>
        /// Otherwise, the first time ShowWindow is called, the value should be the value obtained by the WinMain function in its nCmdShow parameter.<br/>
        /// In subsequent calls, this parameter can be one of the following values.
        /// </param>
        /// <returns>
        /// If the window was previously visible, the return value is nonzero.<param/>
        /// If the window was previously hidden, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow([In] HWnd hWnd, [In] [MarshalAs(UnmanagedType.I4)] OldShowWindowCommands cmdShow);
#endregion
#region AnimateWindow
        /// <summary>
        /// Enables you to produce special effects when showing or hiding windows.<br/>
        /// There are four types of animation: roll, slide, collapse or expand, and alpha-blended fade.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window to animate. The calling thread must own this window.
        /// </param>
        /// <param name="dwTime">
        /// The time it takes to play the animation, in milliseconds.<br/>
        /// Typically, an animation takes 200 milliseconds to play.
        /// </param>
        /// <param name="dwFlags">
        /// The type of animation.<br/>
        /// This parameter can be one or more of the following values.<br/>
        /// Note that, by default, these flags take effect when showing a window.<br/>
        /// To take effect when hiding a window, use AW_HIDE and a logical OR operator with the appropriate flags.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero. The function will fail in the following situations:<para/>
        /// If the window is already visible and you are trying to show the window.<br/>
        /// If the window is already hidden and you are trying to hide the window.<br/>
        /// If there is no direction specified for the slide or roll animation.<br/>
        /// When trying to animate a child window with AW_BLEND.<br/>
        /// If the thread does not own the window. Note that, in this case, AnimateWindow fails but GetLastError returns ERROR_SUCCESS.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "AnimateWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AnimateWindow([In] HWnd hWnd, [In] [MarshalAs(UnmanagedType.I4)] int dwTime, [In] [MarshalAs(UnmanagedType.I4)] WindowAnimateFlags dwFlags);
#endregion
#region SetForegroundWindow
        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window.<br/>
        /// Keyboard input is directed to the window, and various visual cues are changed for the user.<br/>
        /// The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that should be activated and brought to the foreground.
        /// </param>
        /// <returns>
        /// If the window was brought to the foreground, the return value is nonzero.<param/>
        /// If the window was not brought to the foreground, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "SetForegroundWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow([In] HWnd hWnd);
#endregion
#region AllowSetForegroundWindow
        /// <summary>
        /// Enables the specified process to set the foreground window using the SetForegroundWindow function.<br/>
        /// The calling process must already be able to set the foreground window.<br/>
        /// For more information, see Remarks later in this topic.
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier of the process that will be enabled to set the foreground window.<br/>
        /// If this parameter is ASFW_ANY, all processes will be enabled to set the foreground window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<param/>
        /// If the function fails, the return value is zero. The function will fail if the calling process cannot set the foreground window. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow([In] [MarshalAs(UnmanagedType.I4)] int dwProcessId);
#endregion
#region LockSetForegroundWindow
        /// <summary>
        /// The foreground process can call the LockSetForegroundWindow function to disable calls to the SetForegroundWindow function.
        /// </summary>
        /// <param name="uLockCode">
        /// Specifies whether to enable or disable calls to SetForegroundWindow. This parameter can be one of the following values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<param/>
        /// If the function fails, the return value is zero. The function will fail if the calling process cannot set the foreground window. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "LockSetForegroundWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LockSetForegroundWindow([In] [MarshalAs(UnmanagedType.U4)] LockCode uLockCode);
#endregion
#region GetWindowDC
        /// <summary>
        /// The GetWindowDC function retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars.<br/>
        /// A window device context permits painting anywhere in a window, because the origin of the device context is the upper-left corner of the window instead of the client area.<para/>
        /// GetWindowDC assigns default attributes to the window device context each time it retrieves the device context. Previous attributes are lost.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window with a device context that is to be retrieved.<br/>
        /// If this value is NULL, GetWindowDC retrieves the device context for the entire screen.<para/>
        /// If this parameter is NULL, GetWindowDC retrieves the device context for the primary display monitor.<br/>
        /// To get the device context for other display monitors, use the EnumDisplayMonitors and CreateDC functions.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a device context for the specified window.<br/>
        /// If the function fails, the return value is NULL, indicating an error or an invalid hWnd parameter.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetWindowDC")]
        public static extern HDc GetWindowDC(HWnd hwnd);
#endregion
#region ReleaseDC
        /// <summary>
        /// The ReleaseDC function releases a device context (DC), freeing it for use by other applications.<br/>
        /// The effect of the ReleaseDC function depends on the type of DC.<br/>
        /// It frees only common and window DCs. It has no effect on class or private DCs.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be released.
        /// </param>
        /// <param name="hDC">
        /// A handle to the DC to be released.
        /// </param>
        /// <returns>
        /// The return value indicates whether the DC was released. If the DC was released, the return value is 1.<br/>
        /// If the DC was not released, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "ReleaseDC")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseDC(HWnd hWnd, [In] HDc hDC);
#endregion
#region BeginPaint
        /// <summary>
        /// The BeginPaint function prepares the specified window for painting and fills a PAINTSTRUCT structure with information about the painting.
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window to be repainted.
        /// </param>
        /// <param name="lpPaint">
        /// Pointer to the PAINTSTRUCT structure that will receive painting information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a display device context for the specified window.<br/>
        /// If the function fails, the return value is NULL, indicating that no display device context is available.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "BeginPaint")]
        public static extern HDc BeginPaint([In] HWnd hWnd, [Out] out PaintStruct lpPaint);
#endregion
#region EndPaint
        /// <summary>
        /// The EndPaint function marks the end of painting in the specified window.<br/>
        /// This function is required for each call to the BeginPaint function, but only after painting is complete.
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window that has been repainted.
        /// </param>
        /// <param name="hDC">
        /// Pointer to a PAINTSTRUCT structure that contains the painting information retrieved by BeginPaint.
        /// </param>
        /// <returns>
        /// The return value is always nonzero.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "EndPaint")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndPaint([In] HWnd hWnd, [In] ref PaintStruct hDC);
#endregion
#region GetUpdateRect
        /// <summary>
        /// The GetUpdateRect function retrieves the coordinates of the smallest rectangle that completely encloses the update region of the specified window.<br/>
        /// GetUpdateRect retrieves the rectangle in logical coordinates.<br/>
        /// If there is no update region, GetUpdateRect retrieves an empty rectangle (sets all coordinates to zero).
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose update region is to be retrieved.
        /// </param>
        /// <param name="lpRect">
        /// Pointer to the RECT structure that receives the coordinates, in device units, of the enclosing rectangle.<para/>
        /// An application can set this parameter to NULL to determine whether an update region exists for the window. <br/>
        /// If this parameter is NULL, GetUpdateRect returns nonzero if an update region exists, and zero if one does not. <br/>
        /// This provides a simple and efficient means of determining whether a WM_PAINT message resulted from an invalid area.
        /// </param>
        /// <param name="erase">
        /// Specifies whether the background in the update region is to be erased.<br/>
        /// If this parameter is TRUE and the update region is not empty,<br/>
        /// GetUpdateRect sends a WM_ERASEBKGND message to the specified window to erase the background.
        /// </param>
        /// <returns>
        /// If the update region is not empty, the return value is nonzero.<br/>
        /// If there is no update region, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetUpdateRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetUpdateRect([In] HWnd hWnd, [Out] out Rect lpRect, [In][MarshalAs(UnmanagedType.Bool)] bool erase);
#endregion
#region GetUpdateRgn
        /// <summary>
        /// The GetUpdateRgn function retrieves the update region of a window by copying it into the specified region.<br/>
        /// The coordinates of the update region are relative to the upper-left corner of the window (that is, they are client coordinates).
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window with an update region that is to be retrieved.
        /// </param>
        /// <param name="hRgn">
        /// Handle to the region to receive the update region.
        /// </param>
        /// <param name="erase">
        /// Specifies whether the window background should be erased and whether nonclient areas of child windows should be drawn. If this parameter is FALSE, no drawing is done.
        /// </param>
        /// <returns>
        /// The return value indicates the complexity of the resulting region
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetUpdateRgn")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern RgnStatus GetUpdateRgn([In] HWnd hWnd, [In] HRng hRgn, [In][MarshalAs(UnmanagedType.Bool)] bool erase);
#endregion
#region SetWindowRgn
        /// <summary>
        /// he SetWindowRgn function sets the window region of a window. The window region determines the area within the window where the system permits drawing.<br/>
        /// The system does not display any portion of a window that lies outside of the window region
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window region is to be set.
        /// </param>
        /// <param name="hRgn">
        /// A handle to a region. The function sets the window region of the window to this region.<para/>
        /// If hRgn is NULL, the function sets the window region to NULL.
        /// </param>
        /// <param name="bRedraw">
        /// Specifies whether the system redraws the window after setting the window region.<br/>
        /// If bRedraw is TRUE, the system does so; otherwise, it does not.<para/>
        /// Typically, you set bRedraw to TRUE if the window is visible.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "SetWindowRgn")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowRgn([In] HWnd hWnd, [Out] out HRng hRgn, [In][MarshalAs(UnmanagedType.Bool)] bool bRedraw);
#endregion
#region GetWindowRgn
        /// <summary>
        /// The GetWindowRgn function obtains a copy of the window region of a window.<br/>
        /// The window region of a window is set by calling the SetWindowRgn function.<br/>
        /// The window region determines the area within the window where the system permits drawing.<br/>
        /// The system does not display any portion of a window that lies outside of the window region
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose window region is to be obtained.
        /// </param>
        /// <param name="hRgn">
        /// Handle to the region which will be modified to represent the window region.
        /// </param>
        /// <returns>
        /// The return value specifies the type of the region that the function obtains.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetWindowRgn")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern RgnStatus GetWindowRgn([In] HWnd hWnd, [In] HRng hRgn);
#endregion
#region GetWindowRgnBox
        /// <summary>
        /// The GetWindowRgnBox function retrieves the dimensions of the tightest bounding rectangle for the window region of a window.
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window.
        /// </param>
        /// <param name="lprc">
        /// Pointer to a RECT structure that receives the rectangle dimensions, in device units relative to the upper-left corner of the window.
        /// </param>
        /// <returns>
        /// The return value specifies the type of the region that the function obtains.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetWindowRgnBox")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern RgnStatus GetWindowRgnBox([In] HWnd hWnd, [Out] out Rect lprc);
#endregion
#region ExcludeUpdateRgn
        /// <summary>
        /// The ExcludeUpdateRgn function prevents drawing within invalid areas of a window by excluding an updated region in the window from a clipping region.
        /// </summary>
        /// <param name="hDC">
        /// Handle to the device context associated with the clipping region.
        /// </param>
        /// <param name="hWnd">
        /// Handle to the window to update.
        /// </param>
        /// <returns>
        /// The return value specifies the complexity of the excluded region
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "ExcludeUpdateRgn")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern RgnStatus ExcludeUpdateRgn([In] HDc hDC, [In] HWnd hWnd);
#endregion
#region InvalidateRect
        /// <summary>
        /// The InvalidateRect function adds a rectangle to the specified window's update region.<br/>
        /// The update region represents the portion of the window's client area that must be redrawn.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose update region has changed.<br/>
        /// If this parameter is NULL, the system invalidates and redraws all windows,<br/>
        /// not just the windows for this application, and sends the WM_ERASEBKGND and WM_NCPAINT messages before the function returns.<br/>
        /// Setting this parameter to NULL is not recommended.
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a RECT structure that contains the client coordinates of the rectangle to be added to the update region.<br/>
        /// If this parameter is NULL, the entire client area is added to the update region.
        /// </param>
        /// <param name="bErase">
        /// Specifies whether the background within the update region is to be erased when the update region is processed.<br/>
        /// If this parameter is TRUE, the background is erased when the BeginPaint function is called.<br/>
        /// If this parameter is FALSE, the background remains unchanged.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "InvalidateRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect([In] HWnd hWnd, [In] ref Rect lpRect, [In] bool bErase);
#endregion
#region ValidateRect
        /// <summary>
        /// The ValidateRect function validates the client area within a rectangle by removing the rectangle from the update region of the specified window.
        /// </summary>
        /// <param name="hWnd">
        /// Handle to the window whose update region is to be modified.<br/>
        /// If this parameter is NULL, the system invalidates and redraws all windows and sends the WM_ERASEBKGND and WM_NCPAINT messages to the window procedure before the function returns.
        /// </param>
        /// <param name="lpRect">
        /// Pointer to a RECT structure that contains the client coordinates of the rectangle to be removed from the update region.<br/>
        /// If this parameter is NULL, the entire client area is removed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "ValidateRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ValidateRect([In] HWnd hWnd, [In] ref Rect lpRect);
#endregion
        // ...
#region WindowFromDC
        /// <summary>
        /// The WindowFromDC function returns a handle to the window associated with the specified display device context (DC). Output functions that use the specified device context draw into this window.
        /// </summary>
        /// <param name="hDC">
        /// Handle to the device context from which a handle to the associated window is to be retrieved.
        /// </param>
        /// <returns>
        /// The return value is a handle to the window associated with the specified DC.<br/>
        /// If no window is associated with the specified DC, the return value is NULL.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "WindowFromDC")]
        public static extern IntPtr WindowFromDC([In] IntPtr hDC);
#endregion
#region GetDC
        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.<br/>
        /// You can use the returned handle in subsequent GDI functions to draw in the DC.<br/>
        /// The device context is an opaque data structure, whose values are used internally by GDI.<para/>
        /// The GetDCEx function is an extension to GetDC, which gives an application more control over how and whether clipping occurs in the client area.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.<br/>
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport(ExternDll.User32)]
        public static extern IntPtr GetDC([In] IntPtr hWnd);
#endregion
        // ...
#region SetFocus
        /// <summary>
        /// Sets the keyboard focus to the specified window. The window must be attached to the calling thread's message queue.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that will receive the keyboard input. If this parameter is NULL, keystrokes are ignored.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that previously had the keyboard focus.<br/>
        /// If the hWnd parameter is invalid or the window is not attached to the calling thread's message queue, the return value is NULL.<br/>
        /// To get extended error information, call GetLastError function.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "SetFocus")]
        public static extern HWnd SetFocus(HWnd hWnd);
#endregion
#region GetActiveWindow 
        /// <summary>
        /// Retrieves the window handle to the active window attached to the calling thread's message queue.
        /// </summary>
        /// <returns>
        /// The return value is the handle to the active window attached to the calling thread's message queue.<bt/>
        /// Otherwise, the return value is NULL.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetActiveWindow")]
        public static extern HWnd GetActiveWindow();
#endregion

#region GetDesktopWindow 
        /// <summary>
        /// Retrieves a handle to the desktop window.<br/>
        /// The desktop window covers the entire screen.<br/>
        /// The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>
        /// The return value is a handle to the desktop window
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetDesktopWindow")]
        public static extern HWnd GetDesktopWindow();
#endregion
#region GetKBCodePage
        /// <summary>
        /// Retrieves the current code page.
        /// </summary>
        /// <returns>
        /// The return value is an OEM code-page identifier, or it is the default identifier if the registry value is not readable.<br/>
        /// For a list of OEM code-page identifiers, see Code Page Identifiers.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetKBCodePage")]
        public static extern uint GetKBCodePage();
#endregion
#region GetKeyState
        /// <summary>
        /// Retrieves the status of the specified virtual key.<br/>
        /// The status specifies whether the key is up, down, or toggled (on, off—alternating each time the key is pressed).
        /// </summary>
        /// <param name="virtualKey">
        /// A virtual key. If the desired virtual key is a letter or digit (A through Z, a through z, or 0 through 9), nVirtKey must be set to the ASCII value of that character.<br/>
        /// For other keys, it must be a virtual-key code.
        /// </param>
        /// <returns>
        /// The return value specifies the status of the specified virtual key, as follows:<param/>
        /// - If the high-order bit is 1, the key is down; otherwise, it is up.<br/>
        /// - If the low-order bit is 1, the key is toggled. A key, such as the CAPS LOCK key, is toggled if it is turned on. <br/>
        /// - The key is off and untoggled if the low-order bit is 0. <br/>
        /// A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetKeyState")]
        public static extern short GetKeyState([In] [MarshalAs(UnmanagedType.I4)] VirtualKey virtualKey);
#endregion
#region GetWindowRect
        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window.<br/>
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32, EntryPoint = "GetWindowRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect([In] HWnd hWnd, [Out] out Rect lpRect);
#endregion
#region SetCursorPos
        /// <summary>
        /// Moves the cursor to the specified screen coordinates.<br/>
        /// If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </summary>
        /// <param name="x">
        /// The new x-coordinate of the cursor, in screen coordinates.
        /// </param>
        /// <param name="y">
        /// The new y-coordinate of the cursor, in screen coordinates.
        /// </param>
        /// <returns>
        /// Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);
        /// <summary>
        /// Moves the cursor to the specified screen coordinates.<br/>
        /// If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </summary>
        /// <param name="pos">
        /// The new position of the cursor, in screen coordinates.
        /// </param>
        /// <returns>
        /// Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.
        /// </returns>
        public static bool SetCursorPos(Vector2i pos) => SetCursorPos(pos.X, pos.Y);
#endregion
#region GetWindowRect
        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(HWnd hWnd,  [Out] out Rect lpRect);
#endregion
        //TODO: doku
#region FindWindow
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern HWnd FindWindow(string className, string windowName);
#endregion

#endregion

        /// <summary>
        /// Releases the mouse capture from a window in the current thread and restores normal mouse input processing.<br/>
        /// A window that has captured the mouse receives all mouse input, regardless of the position of the cursor, except when a mouse button is clicked while the cursor hot spot is in the window of another thread.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32)]
        public static extern bool ReleaseCapture();

        [DllImport(ExternDll.User32)]
        public static extern bool GetClientRect(HWnd hWnd, out Rect windowRect);

        [DllImport(ExternDll.User32)]
        public static extern IntPtr WindowFromPoint(Vector2i point);
        [DllImport(ExternDll.User32)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport(ExternDll.User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

#region Window Updater

        [DllImport(ExternDll.User32)]
        public static extern bool UpdateWindow(HWnd hwnd);
        [DllImport(ExternDll.User32)]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        [DllImport(ExternDll.User32)]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

#endregion

#region HookLowLevelMouseHookCallback

#region SetWindowsHookEx
        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the system for certain types of events.<br/>
        /// These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="hookType">
        /// The type of hook procedure to be installed.
        /// </param>
        /// <param name="lpfn">
        /// A pointer to LowLevelKeyboardHookCallback the hook procedure.<br/>
        /// If the dwThreadId parameter is zero or specifies the identifier of a thread created by a different process, the lpfn parameter must point to a hook procedure in a DLL.<br/>
        /// Otherwise, lpfn can point to a hook procedure in the code associated with the current process.
        /// </param>
        /// <param name="hMod">
        /// A handle to the DLL containing the hook procedure pointed to by the lpfn parameter.<br/>
        /// The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process and <br/>
        /// if the hook procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        /// The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero,<br/>
        /// the hook procedure is associated with all existing threads running in the same desktop as the calling thread.<br/>
        /// For Windows Store apps, see the Remarks section.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the hook procedure.<br/>
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx([MarshalAs(UnmanagedType.I4)] HookTyp hookType, LowLevelBasicHookCallback lpfn, IntPtr hMod, uint dwThreadId);
        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the system for certain types of events.<br/>
        /// These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="hookType">
        /// The type of hook procedure to be installed.
        /// </param>
        /// <param name="lpfn">
        /// A pointer to LowLevelKeyboardHookCallback the hook procedure.<br/>
        /// If the dwThreadId parameter is zero or specifies the identifier of a thread created by a different process, the lpfn parameter must point to a hook procedure in a DLL.<br/>
        /// Otherwise, lpfn can point to a hook procedure in the code associated with the current process.
        /// </param>
        /// <param name="hMod">
        /// A handle to the DLL containing the hook procedure pointed to by the lpfn parameter.<br/>
        /// The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process and <br/>
        /// if the hook procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        /// The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero,<br/>
        /// the hook procedure is associated with all existing threads running in the same desktop as the calling thread.<br/>
        /// For Windows Store apps, see the Remarks section.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the hook procedure.<br/>
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx([MarshalAs(UnmanagedType.I4)] HookTyp hookType, LowLevelKeyboardHookCallback lpfn, IntPtr hMod, uint dwThreadId);
        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the system for certain types of events.<br/>
        /// These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="hookType">
        /// The type of hook procedure to be installed.
        /// </param>
        /// <param name="lpfn">
        /// A pointer to the LowLevelMouseHookCallback hook procedure.<br/>
        /// If the dwThreadId parameter is zero or specifies the identifier of a thread created by a different process, the lpfn parameter must point to a hook procedure in a DLL.<br/>
        /// Otherwise, lpfn can point to a hook procedure in the code associated with the current process.
        /// </param>
        /// <param name="hMod">
        /// A handle to the DLL containing the hook procedure pointed to by the lpfn parameter.<br/>
        /// The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process and <br/>
        /// if the hook procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        /// The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero,<br/>
        /// the hook procedure is associated with all existing threads running in the same desktop as the calling thread.<br/>
        /// For Windows Store apps, see the Remarks section.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the hook procedure.<br/>
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx([MarshalAs(UnmanagedType.I4)] HookTyp hookType, LowLevelMouseHookCallback lpfn, IntPtr hMod, uint dwThreadId);
#endregion



        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

#endregion

        [DllImport(ExternDll.User32, EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong32(HandleRef hWnd, [In] [MarshalAs(UnmanagedType.I4)] WindowLongParam nIndex, int dwNewLong);

        [DllImport(ExternDll.User32, EntryPoint = "SetWindowLongPtr")]
        private static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, [In] [MarshalAs(UnmanagedType.I4)] WindowLongParam nIndex, IntPtr dwNewLong);
        public static IntPtr SetWindowLongPtr(HandleRef hWnd, WindowLongParam nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }




        [DllImport(ExternDll.User32, EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, [In] [MarshalAs(UnmanagedType.I4)] WindowLongParam nIndex);

        [DllImport(ExternDll.User32, EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, [In] [MarshalAs(UnmanagedType.I4)] WindowLongParam nIndex);
        public static IntPtr GetWindowLongPtr(IntPtr hWnd, WindowLongParam nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return GetWindowLongPtr32(hWnd, nIndex);
        }


#region Message

#region Send
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, ref IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, int lParam);

#endregion
#region Post

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, ref IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, int lParam);
#endregion

#endregion
        //[DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        //public static extern HWnd FindWindow(string className, string windowName);
#region Monotors
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumDisplayMonitorsCallback lpfnEnum, IntPtr dwData);
        [DllImport(ExternDll.User32, EntryPoint = "GetMonitorInfoA", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool WinGetMonitorInfo(IntPtr hMonitor, ref MonitorInfo monitorInfo);
        [DllImport(ExternDll.User32, EntryPoint = "GetMonitorInfoA", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool WinGetMonitorInfo(IntPtr hMonitor, ref MonitorInfoEx monitorInfo);

        [DllImport(ExternDll.User32, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetSystemMetrics(int nIndex);
#endregion

#region SytemParametersInfo

        [DllImport(ExternDll.User32, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetSystemMetrics([In] [MarshalAs(UnmanagedType.I4)] SystemMetric nIndex);

        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public unsafe static extern bool SystemParametersInfo(SPI uiAction, int uiParam, void* pvParam, int fWinIni);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public unsafe static extern bool SystemParametersInfo(SPI uiAction, int uiParam, IntPtr pvParam, int fWinIni);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public unsafe static extern bool SystemParametersInfo(SPI uiAction, bool uiParam, void* pvParam, int fWinIni);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public unsafe static extern bool SystemParametersInfo(SPI uiAction, bool uiParam, IntPtr pvParam, int fWinIni);
        //[DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        //[ResourceExposure(ResourceScope.None)]
        //public static extern bool SystemParametersInfo(int nAction, int nParam, ref NativeMethods.HIGHCONTRAST_I rc, int nUpdate);
        //[DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        //[ResourceExposure(ResourceScope.None)]
        //public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] NativeMethods.NONCLIENTMETRICS metrics, int nUpdate);

#endregion
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetDoubleClickTime();
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetCursorPos([In, Out] Vector2i pt);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern short VkKeyScan(char key);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern short GetKeyState(int keyCode);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetCapture();
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr SetCapture(HandleRef hwnd);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetFocus();
    }
}
#endif