using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SuperEd
{
    public class KeyHook
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public enum VKeys
        {
            //KEY_MLBUTTON = 0x01,
            //KEY_MRBUTTON = 0x02,
            //KEY_MWBUTTON = 0x04,

            //KEY_BACK = 0x08,
            KEY_TAB = 0x09,
            //KEY_RETURN = 0x0D,
            //KEY_CAPS = 0x14,
            //KEY_LWIN = 0x5B,
            //KEY_RWIN = 0x5C,
            //KEY_APPS = 0x5D,
            //KEY_LSHIFT = 0xA0,
            //KEY_RSHIFT = 0xA1,
            //KEY_LCTRL = 0xA2,
            //KEY_RCTRL = 0xA3,
            //KEY_LALT = 0xA4,
            //KEY_RALT = 0xA5,
            //KEY_ESCAPE = 0x1B,
            //KEY_SPACE = 0x20,

            //KEY_INSERT = 0x2D,
            //KEY_DELETE = 0x2E,
            //KEY_END = 0x23,
            //KEY_HOME = 0x24,
            //KEY_PRIOR = 0x21,       // PAGE UP
            //KEY_NEXT = 0x22,        // PAGE DOWN

            //KEY_LEFTARROW = 0x25,
            //KEY_UPARROW = 0x26,
            //KEY_RIGHTARROW = 0x27,
            //KEY_DOWNARROW = 0x28,

            //KEY_SNAPSHOT = 0x2C,
            //KEY_SCROLL = 0x91,
            //KEY_PAUSE = 0x13,

            //KEY_0 = 0x30,
            //KEY_1 = 0x31,
            //KEY_2 = 0x32,
            //KEY_3 = 0x33,
            //KEY_4 = 0x34,
            //KEY_5 = 0x35,
            //KEY_6 = 0x36,
            //KEY_7 = 0x37,
            //KEY_8 = 0x38,
            //KEY_9 = 0x39,

            //KEY_A = 0x41,
            //KEY_B = 0x42,
            //KEY_C = 0x43,
            //KEY_D = 0x44,
            //KEY_E = 0x45,
            //KEY_F = 0x46,
            //KEY_G = 0x47,
            //KEY_H = 0x48,
            //KEY_I = 0x49,
            //KEY_J = 0x4A,
            //KEY_K = 0x4B,
            //KEY_L = 0x4C,
            //KEY_M = 0x4D,
            //KEY_N = 0x4E,
            //KEY_O = 0x4F,
            //KEY_P = 0x50,
            //KEY_Q = 0x51,
            //KEY_R = 0x52,
            //KEY_S = 0x53,
            //KEY_T = 0x54,
            //KEY_U = 0x55,
            //KEY_V = 0x56,
            //KEY_W = 0x57,
            //KEY_X = 0x58,
            //KEY_Y = 0x59,
            //KEY_Z = 0x5A,

            KEY_F1 = 0x70,
            KEY_F2 = 0x71,
            KEY_F3 = 0x72,
            //KEY_F4 = 0x73,
            //KEY_F5 = 0x74,
            //KEY_F6 = 0x75,
            //KEY_F7 = 0x76,
            //KEY_F8 = 0x77,
            //KEY_F9 = 0x78,
            //KEY_F10 = 0x79,
            //KEY_F11 = 0x7A,
            //KEY_F12 = 0x7B,
            //KEY_F13 = 0x7C,
            //KEY_F14 = 0x7D,
            //KEY_F15 = 0x7E,
            //KEY_F16 = 0x7F,
            //KEY_F17 = 0x80,
            //KEY_F18 = 0x81, 
            //KEY_F19 = 0x82, 
            //KEY_F20 = 0x83, 
            //KEY_F21 = 0x84,
            //KEY_F22 = 0x85,
            //KEY_F23 = 0x86, 
            //KEY_F24 = 0x87,

            //KEY_NUMPAD0 = 0x60,
            //KEY_NUMPAD1 = 0x61,
            //KEY_NUMPAD2 = 0x62,
            //KEY_NUMPAD3 = 0x63,
            KEY_NUMPAD4 = 0x64,
            //KEY_NUMPAD5 = 0x65,
            KEY_NUMPAD6 = 0x66,
            //KEY_NUMPAD7 = 0x67,
            //KEY_NUMPAD8 = 0x68,
            //KEY_NUMPAD9 = 0x69,

            //KEY_MULTIPLY = 0x6A,    // Num *
            //KEY_ADD = 0x6B,         // Num +
            //KEY_SEPARATOR = 0x6C,   // |
            //KEY_SUBTRACT = 0x6D,    // Num -
            //KEY_DECIMAL = 0x6E,     // Num .
            //KEY_DIVIDE = 0x6F,      // Num /
            //KEY_NUMLOCK = 0x90,
        }

        public delegate void KeyboardHookCallback(VKeys key);
        private delegate IntPtr KeyboardHookHandler(int nCode, IntPtr wParam, IntPtr lParam);

        private KeyboardHookHandler hookHandler;
        private IntPtr hookID = IntPtr.Zero;

        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYUP = 0x105;

        public event KeyboardHookCallback KeyDown;
        public event KeyboardHookCallback KeyUp;

        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }
        public void Uninstall()
        {
            UnhookWindowsHookEx(hookID);
        }

        private IntPtr SetHook(KeyboardHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(13, proc, GetModuleHandle(module.ModuleName), 0);
        }
        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int iwParam = wParam.ToInt32();

                if ((iwParam == WM_KEYDOWN || iwParam == WM_SYSKEYDOWN))
                    if (KeyDown != null)
                        KeyDown((VKeys)Marshal.ReadInt32(lParam));
                if ((iwParam == WM_KEYUP || iwParam == WM_SYSKEYUP))
                    if (KeyUp != null)
                        KeyUp((VKeys)Marshal.ReadInt32(lParam));
            }

            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        ~KeyHook()
        {
            Uninstall();
        }
    }
}
