using Se7en.Mathematic;
using Se7en.WinApi;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Se7en.Windows {
    class LowLevelHook {

        #region Events

        public static event Action<string, KeyButtonsEvents> KeyboardEvent;
        public static event Action<MouseButtonsEvents, Vector2i> MouseEvent;

        #endregion
        #region Values

        private static bool LShiftPress = false;
        private static bool RShiftPress = false;
        private static bool CapsPressed = false;

        private static LowLevelHookCallback KBCallback = new LowLevelHookCallback(LLKeyboardCallback);
        private static LowLevelHookCallback MCallback = new LowLevelHookCallback(LLMouseCallback);

        #endregion
        #region Hooks

        private static IntPtr KBHook = IntPtr.Zero;
        private static IntPtr MHook = IntPtr.Zero;

        #endregion
        #region Functions

        /// <summary>
        /// Apply Low level hook to keyboard
        /// </summary>
        public static void HookKeyboard() {
            if (KBHook != IntPtr.Zero)
                return;
            KBHook = User32.SetWindowsHookEx(HookType.WH_KEYBOARD_LL, KBCallback, IntPtr.Zero, 0);
        }
        /// <summary>
        /// Apply Low level hook to mouse
        /// </summary>
        public static void HookMouse() {
            if (MHook != IntPtr.Zero)
                return;
            MHook = User32.SetWindowsHookEx(HookType.WH_MOUSE_LL, MCallback, IntPtr.Zero, 0);
        }

        /// <summary>
        /// Remove low level hook from keyboard
        /// </summary>
        public static void UnhookKeyboard() {
            if (User32.UnhookWindowsHookEx(KBHook))
                KBHook = IntPtr.Zero;
        }
        /// <summary>
        /// Remove low level hook from mouse
        /// </summary>
        public static void UnhookMouse() {
            if (User32.UnhookWindowsHookEx(MHook))
                MHook = IntPtr.Zero;
        }

        #endregion
        #region Callbacks

        private static IntPtr LLKeyboardCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode > -1) {
                KeyButtonsEvents p = (KeyButtonsEvents)wParam;
                Keys key = (Keys)Marshal.ReadInt32(lParam);
                if (key == Keys.LShiftKey)
                    LShiftPress = (p == KeyButtonsEvents.KeyDown);
                if (key == Keys.RShiftKey)
                    RShiftPress = (p == KeyButtonsEvents.KeyDown);
                if (key == Keys.CapsLock)
                    CapsPressed = (p == KeyButtonsEvents.KeyDown);
                string v = (LShiftPress || RShiftPress || CapsPressed) ? key.ToString() : key.ToString().ToLower();
                KeyboardEvent?.Invoke(v, p);
            }
            return User32.CallNextHookEx(KBHook, nCode, wParam, lParam);
        }
        private static IntPtr LLMouseCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode > -1) {
                MouseButtonsEvents b = (MouseButtonsEvents)wParam;
                Vector2i location = (Vector2i)Marshal.PtrToStructure(lParam, typeof(Vector2i));
                MouseEvent?.Invoke(b, location);
            }
            return User32.CallNextHookEx(KBHook, nCode, wParam, lParam);
        }

        #endregion
    }
}
