using Se7en.Windows.Api;
using Se7en.Windows.Api.Enum;
using Se7en.Windows.Api.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace Se7en.Windows
{
    public class HookManager
    {
        public static event KeyboardHookCallback KeyboardEvent;
        public static event MouseHookCallback MouseEvent;

        private static bool LShiftPress = false;
        private static bool RShiftPress = false;
        private static bool CapsPressed = false;

        private unsafe static LowLevelKeyboardHookCallback KBCallback = new LowLevelKeyboardHookCallback(LLKeyboardCallback);
        private unsafe static LowLevelMouseHookCallback MCallback = new LowLevelMouseHookCallback(LLMouseCallback);

        private static IntPtr KBHook = IntPtr.Zero;
        private static IntPtr MHook = IntPtr.Zero;

        /// <summary>
        /// Apply Low level hook to keyboard
        /// </summary>
        public static void HookKeyboard()
        {
            if (KBHook != IntPtr.Zero)
                return;
            KBHook = User32.SetWindowsHookEx(HookTyp.WH_KEYBOARD_LL, KBCallback, IntPtr.Zero, 0);
        }
        /// <summary>
        /// Apply Low level hook to mouse
        /// </summary>
        public static void HookMouse()
        {
            if (MHook != IntPtr.Zero)
                return;
            MHook = User32.SetWindowsHookEx(HookTyp.WH_MOUSE_LL, MCallback, IntPtr.Zero, 0);
        }

        /// <summary>
        /// Remove low level hook from keyboard
        /// </summary>
        public static void UnhookKeyboard()
        {
            if (User32.UnhookWindowsHookEx(KBHook))
                KBHook = IntPtr.Zero;
        }
        /// <summary>
        /// Remove low level hook from mouse
        /// </summary>
        public static void UnhookMouse()
        {
            if (User32.UnhookWindowsHookEx(MHook))
                MHook = IntPtr.Zero;
        }
        private unsafe static IntPtr LLKeyboardCallback(int nCode, KeyboardButtonsState wParam, KeyBoardLowlevelHookStruct* lParam)
        {
            if (nCode > -1)
            {
                KeyBoardLowlevelHookStruct hookStruct = *lParam;
                VirtualKey key = hookStruct.VkCode;
                if (key == VirtualKey.LShift) LShiftPress = (wParam == KeyboardButtonsState.WM_KEYDOWN);
                if (key == VirtualKey.RShift) RShiftPress = (wParam == KeyboardButtonsState.WM_KEYDOWN);
                if (key == VirtualKey.CapsLock) CapsPressed = (wParam == KeyboardButtonsState.WM_KEYDOWN);
                string v = (LShiftPress || RShiftPress || CapsPressed) ? key.ToString() : key.ToString().ToLower();
                KeyboardEvent.Invoke(v, wParam, hookStruct);
            }
            return User32.CallNextHookEx(KBHook, nCode, (IntPtr) wParam, (IntPtr) lParam);
        }

        private unsafe static IntPtr LLMouseCallback(int nCode, MouseButtonsState wParam, MouseLowlevelHookStruct* lParam)
        {
            if (nCode > -1)
            {
                MouseEvent.Invoke(nCode, wParam, *lParam);
            }
            return User32.CallNextHookEx(KBHook, nCode, (IntPtr) wParam, (IntPtr) lParam);
        }

    }
}
