namespace Se7en.Windows.Api.Enum
{
    public enum VirtualKey : int
    {
        /// <summary>
        ///     The key code bit mask.
        /// </summary>
        KEY_CODE = 0x0000FFFF,

        /// <summary>
        ///     The modifiers bit mask.
        /// </summary>
        MODIFIERS = unchecked((int)0xFFFF0000),

        /// <summary>
        ///     The none.
        /// </summary>
        None = 0x00,

        /// <summary>
        ///     The cancel.
        /// </summary>
        Cancel = 0x03,

        /// <summary>
        ///     The back.
        /// </summary>
        Back = 0x08,

        /// <summary>
        ///     The tab.
        /// </summary>
        Tab = 0x09,

        /// <summary>
        ///     The line feed.
        /// </summary>
        LineFeed = 0x0A,

        /// <summary>
        ///     The clear.
        /// </summary>
        Clear = 0x0C,

        /// <summary>
        ///     The return.
        /// </summary>
        Return = 0x0D,

        /// <summary>
        ///     The enter.
        /// </summary>
        Enter = Return,

        /// <summary>
        ///     The shift key.
        /// </summary>
        ShiftKey = 0x10,

        /// <summary>
        ///     The control key.
        /// </summary>
        ControlKey = 0x11,

        /// <summary>
        ///     The menu (alt) key.
        /// </summary>
        Menu = 0x12,

        /// <summary>
        ///     The shift modifier.
        /// </summary>
        Shift = 0x00010000,

        /// <summary>
        ///     The control modifier.
        /// </summary>
        Control = 0x00020000,

        /// <summary>
        ///     The alternate modifier.
        /// </summary>
        Alt = 0x00040000,

        /// <summary>
        ///     The pause.
        /// </summary>
        Pause = 0x13,

        /// <summary>
        ///     The capital.
        /// </summary>
        Capital = 0x14,

        /// <summary>
        ///     The capabilities lock.
        /// </summary>
        CapsLock = 0x14,

        /// <summary>
        ///     The kana mode.
        /// </summary>
        KanaMode = 0x15,

        /// <summary>
        ///     The hanguel mode.
        /// </summary>
        HanguelMode = 0x15,

        /// <summary>
        ///     The hangul mode.
        /// </summary>
        HangulMode = 0x15,

        /// <summary>
        ///     The junja mode.
        /// </summary>
        JunjaMode = 0x17,

        /// <summary>
        ///     The final mode.
        /// </summary>
        FinalMode = 0x18,

        /// <summary>
        ///     The hanja mode.
        /// </summary>
        HanjaMode = 0x19,

        /// <summary>
        ///     The kanji mode.
        /// </summary>
        KanjiMode = 0x19,

        /// <summary>
        ///     The escape.
        /// </summary>
        Escape = 0x1B,

        /// <summary>
        ///     The ime convert.
        /// </summary>
        IMEConvert = 0x1C,

        /// <summary>
        ///     The ime nonconvert.
        /// </summary>
        IMENonconvert = 0x1D,

        /// <summary>
        ///     The ime accept.
        /// </summary>
        IMEAccept = 0x1E,

        /// <summary>
        ///     The ime aceept.
        /// </summary>
        IMEAceept = IMEAccept,

        /// <summary>
        ///     The ime mode change.
        /// </summary>
        IMEModeChange = 0x1F,

        /// <summary>
        ///     The space.
        /// </summary>
        Space = 0x20,

        /// <summary>
        ///     The prior.
        /// </summary>
        Prior = 0x21,

        /// <summary>
        ///     The page up.
        /// </summary>
        PageUp = Prior,

        /// <summary>
        ///     The next.
        /// </summary>
        Next = 0x22,

        /// <summary>
        ///     The page down.
        /// </summary>
        PageDown = Next,

        /// <summary>
        ///     The end.
        /// </summary>
        End = 0x23,

        /// <summary>
        ///     The home.
        /// </summary>
        Home = 0x24,

        /// <summary>
        ///     The left.
        /// </summary>
        Left = 0x25,

        /// <summary>
        ///     The up.
        /// </summary>
        Up = 0x26,

        /// <summary>
        ///     The right.
        /// </summary>
        Right = 0x27,

        /// <summary>
        ///     The down.
        /// </summary>
        Down = 0x28,

        /// <summary>
        ///     The select.
        /// </summary>
        Select = 0x29,

        /// <summary>
        ///     The print.
        /// </summary>
        Print = 0x2A,

        /// <summary>
        ///     The execute.
        /// </summary>
        Execute = 0x2B,

        /// <summary>
        ///     The snapshot.
        /// </summary>
        Snapshot = 0x2C,

        /// <summary>
        ///     The print screen.
        /// </summary>
        PrintScreen = Snapshot,

        /// <summary>
        ///     The insert.
        /// </summary>
        Insert = 0x2D,

        /// <summary>
        ///     The delete.
        /// </summary>
        Delete = 0x2E,

        /// <summary>
        ///     The help.
        /// </summary>
        Help = 0x2F,

        /// <summary>
        ///     0.
        /// </summary>
        D0 = 0x30,

        /// <summary>
        ///     1.
        /// </summary>
        D1 = 0x31,

        /// <summary>
        ///     2.
        /// </summary>
        D2 = 0x32,

        /// <summary>
        ///     3.
        /// </summary>
        D3 = 0x33,

        /// <summary>
        ///     4.
        /// </summary>
        D4 = 0x34,

        /// <summary>
        ///     5.
        /// </summary>
        D5 = 0x35,

        /// <summary>
        ///     6.
        /// </summary>
        D6 = 0x36,

        /// <summary>
        ///     7.
        /// </summary>
        D7 = 0x37,

        /// <summary>
        ///     8.
        /// </summary>
        D8 = 0x38,

        /// <summary>
        ///     9.
        /// </summary>
        D9 = 0x39,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        A = 0x41,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        B = 0x42,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        C = 0x43,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        D = 0x44,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        E = 0x45,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        F = 0x46,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        G = 0x47,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        H = 0x48,

        /// <summary>
        ///     Zero-based index of the.
        /// </summary>
        I = 0x49,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        J = 0x4A,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        K = 0x4B,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        L = 0x4C,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        M = 0x4D,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        N = 0x4E,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        O = 0x4F,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        P = 0x50,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        Q = 0x51,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        R = 0x52,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        S = 0x53,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        T = 0x54,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        U = 0x55,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        V = 0x56,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        W = 0x57,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        X = 0x58,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        Y = 0x59,

        /// <summary>
        ///     The const int to process.
        /// </summary>
        Z = 0x5A,

        /// <summary>
        ///     The window.
        /// </summary>
        LWin = 0x5B,

        /// <summary>
        ///     The window.
        /// </summary>
        RWin = 0x5C,

        /// <summary>
        ///     The apps.
        /// </summary>
        Apps = 0x5D,

        /// <summary>
        ///     The sleep.
        /// </summary>
        Sleep = 0x5F,

        /// <summary>
        ///     Number of pad 0s.
        /// </summary>
        NumPad0 = 0x60,

        /// <summary>
        ///     Number of pad 1s.
        /// </summary>
        NumPad1 = 0x61,

        /// <summary>
        ///     Number of pad 2s.
        /// </summary>
        NumPad2 = 0x62,

        /// <summary>
        ///     Number of pad 3s.
        /// </summary>
        NumPad3 = 0x63,

        /// <summary>
        ///     Number of pad 4s.
        /// </summary>
        NumPad4 = 0x64,

        /// <summary>
        ///     Number of pad 5s.
        /// </summary>
        NumPad5 = 0x65,

        /// <summary>
        ///     Number of pad 6s.
        /// </summary>
        NumPad6 = 0x66,

        /// <summary>
        ///     Number of pad 7s.
        /// </summary>
        NumPad7 = 0x67,

        /// <summary>
        ///     Number of pad 8s.
        /// </summary>
        NumPad8 = 0x68,

        /// <summary>
        ///     Number of pad 9s.
        /// </summary>
        NumPad9 = 0x69,

        /// <summary>
        ///     The multiply.
        /// </summary>
        Multiply = 0x6A,

        /// <summary>
        ///     The add.
        /// </summary>
        Add = 0x6B,

        /// <summary>
        ///     The separator.
        /// </summary>
        Separator = 0x6C,

        /// <summary>
        ///     The subtract.
        /// </summary>
        Subtract = 0x6D,

        /// <summary>
        ///     The decimal.
        /// </summary>
        Decimal = 0x6E,

        /// <summary>
        ///     The divide.
        /// </summary>
        Divide = 0x6F,

        /// <summary>
        ///     The f1 key.
        /// </summary>
        F1 = 0x70,

        /// <summary>
        ///     The f2 key.
        /// </summary>
        F2 = 0x71,

        /// <summary>
        ///     The f3 key.
        /// </summary>
        F3 = 0x72,

        /// <summary>
        ///     The f4 key.
        /// </summary>
        F4 = 0x73,

        /// <summary>
        ///     The f5 key.
        /// </summary>
        F5 = 0x74,

        /// <summary>
        ///     The f6 key.
        /// </summary>
        F6 = 0x75,

        /// <summary>
        ///     The f7 key.
        /// </summary>
        F7 = 0x76,

        /// <summary>
        ///     The f8 key.
        /// </summary>
        F8 = 0x77,

        /// <summary>
        ///     The f9 key.
        /// </summary>
        F9 = 0x78,

        /// <summary>
        ///     The f10 key.
        /// </summary>
        F10 = 0x79,

        /// <summary>
        ///     The f11 key.
        /// </summary>
        F11 = 0x7A,

        /// <summary>
        ///     The f12 key.
        /// </summary>
        F12 = 0x7B,

        /// <summary>
        ///     The f13 key.
        /// </summary>
        F13 = 0x7C,

        /// <summary>
        ///     The f14 key.
        /// </summary>
        F14 = 0x7D,

        /// <summary>
        ///     The f15 key.
        /// </summary>
        F15 = 0x7E,

        /// <summary>
        ///     The f16 key.
        /// </summary>
        F16 = 0x7F,

        /// <summary>
        ///     The f17 key.
        /// </summary>
        F17 = 0x80,

        /// <summary>
        ///     The f18 key.
        /// </summary>
        F18 = 0x81,

        /// <summary>
        ///     The f19 key.
        /// </summary>
        F19 = 0x82,

        /// <summary>
        ///     The f20 key.
        /// </summary>
        F20 = 0x83,

        /// <summary>
        ///     The f21 key.
        /// </summary>
        F21 = 0x84,

        /// <summary>
        ///     The the f22 key.
        /// </summary>
        F22 = 0x85,

        /// <summary>
        ///     The f23 ke.
        /// </summary>
        F23 = 0x86,

        /// <summary>
        ///     The f24 key.
        /// </summary>
        F24 = 0x87,

        /// <summary>
        ///     Number of locks.
        /// </summary>
        NumLock = 0x90,

        /// <summary>
        ///     The scroll.
        /// </summary>
        Scroll = 0x91,

        /// <summary>
        ///     The left shift key.
        /// </summary>
        LShift = 0xA0,

        /// <summary>
        ///     The right shift key.
        /// </summary>
        RShift = 0xA1,

        /// <summary>
        ///     The left control key.
        /// </summary>
        LControl = 0xA2,

        /// <summary>
        ///     The right control key.
        /// </summary>
        RControl = 0xA3,

        /// <summary>
        ///     The left menu (alt) key.
        /// </summary>
        LMenu = 0xA4,

        /// <summary>
        ///     The right menu (alt) key.
        /// </summary>
        RMenu = 0xA5,

        /// <summary>
        ///     The browser back.
        /// </summary>
        BrowserBack = 0xA6,

        /// <summary>
        ///     The browser forward.
        /// </summary>
        BrowserForward = 0xA7,

        /// <summary>
        ///     The browser refresh.
        /// </summary>
        BrowserRefresh = 0xA8,

        /// <summary>
        ///     The browser stop.
        /// </summary>
        BrowserStop = 0xA9,

        /// <summary>
        ///     The browser search.
        /// </summary>
        BrowserSearch = 0xAA,

        /// <summary>
        ///     The browser favorites.
        /// </summary>
        BrowserFavorites = 0xAB,

        /// <summary>
        ///     The browser home.
        /// </summary>
        BrowserHome = 0xAC,

        /// <summary>
        ///     The volume mute.
        /// </summary>
        VolumeMute = 0xAD,

        /// <summary>
        ///     The volume down.
        /// </summary>
        VolumeDown = 0xAE,

        /// <summary>
        ///     The volume up.
        /// </summary>
        VolumeUp = 0xAF,

        /// <summary>
        ///     The media next track.
        /// </summary>
        MediaNextTrack = 0xB0,

        /// <summary>
        ///     The media previous track.
        /// </summary>
        MediaPreviousTrack = 0xB1,

        /// <summary>
        ///     The media stop.
        /// </summary>
        MediaStop = 0xB2,

        /// <summary>
        ///     The media play pause.
        /// </summary>
        MediaPlayPause = 0xB3,

        /// <summary>
        ///     The launch mail.
        /// </summary>
        LaunchMail = 0xB4,

        /// <summary>
        ///     The select media.
        /// </summary>
        SelectMedia = 0xB5,

        /// <summary>
        ///     The first launch application.
        /// </summary>
        LaunchApplication1 = 0xB6,

        /// <summary>
        ///     The second launch application.
        /// </summary>
        LaunchApplication2 = 0xB7,

        /// <summary>
        ///     The OEM semicolon.
        /// </summary>
        OemSemicolon = 0xBA,

        /// <summary>
        ///     The first OEM.
        /// </summary>
        Oem1 = OemSemicolon,

        /// <summary>
        ///     The oemplus.
        /// </summary>
        Oemplus = 0xBB,

        /// <summary>
        ///     The oemcomma.
        /// </summary>
        Oemcomma = 0xBC,

        /// <summary>
        ///     The OEM minus.
        /// </summary>
        OemMinus = 0xBD,

        /// <summary>
        ///     The OEM period.
        /// </summary>
        OemPeriod = 0xBE,

        /// <summary>
        ///     The OEM question.
        /// </summary>
        OemQuestion = 0xBF,

        /// <summary>
        ///     The second OEM.
        /// </summary>
        Oem2 = OemQuestion,

        /// <summary>
        ///     The oemtilde.
        /// </summary>
        Oemtilde = 0xC0,

        /// <summary>
        ///     The third OEM.
        /// </summary>
        Oem3 = Oemtilde,

        /// <summary>
        ///     The OEM open brackets.
        /// </summary>
        OemOpenBrackets = 0xDB,

        /// <summary>
        ///     The fourth OEM.
        /// </summary>
        Oem4 = OemOpenBrackets,

        /// <summary>
        ///     The OEM pipe.
        /// </summary>
        OemPipe = 0xDC,

        /// <summary>
        ///     The fifth OEM.
        /// </summary>
        Oem5 = OemPipe,

        /// <summary>
        ///     The OEM close brackets.
        /// </summary>
        OemCloseBrackets = 0xDD,

        /// <summary>
        ///     The OEM 6.
        /// </summary>
        Oem6 = OemCloseBrackets,

        /// <summary>
        ///     The OEM quotes.
        /// </summary>
        OemQuotes = 0xDE,

        /// <summary>
        ///     The OEM 7.
        /// </summary>
        Oem7 = OemQuotes,

        /// <summary>
        ///     The OEM 8.
        /// </summary>
        Oem8 = 0xDF,

        /// <summary>
        ///     The OEM backslash.
        /// </summary>
        OemBackslash = 0xE2,

        /// <summary>
        ///     The second OEM 10.
        /// </summary>
        Oem102 = OemBackslash,

        /// <summary>
        ///     The process key.
        /// </summary>
        Process = 0xE5,

        /// <summary>
        ///     The packet.
        /// </summary>
        Packet = 0xE7,

        /// <summary>
        ///     The attn.
        /// </summary>
        Attn = 0xF6,

        /// <summary>
        ///     The crsel.
        /// </summary>
        Crsel = 0xF7,

        /// <summary>
        ///     The exsel.
        /// </summary>
        Exsel = 0xF8,

        /// <summary>
        ///     The erase EOF.
        /// </summary>
        EraseEof = 0xF9,

        /// <summary>
        ///     The play.
        /// </summary>
        Play = 0xFA,

        /// <summary>
        ///     The zoom.
        /// </summary>
        Zoom = 0xFB,

        /// <summary>
        ///     Name of the no.
        /// </summary>
        NoName = 0xFC,

        /// <summary>
        ///     The first pa.
        /// </summary>
        Pa1 = 0xFD,

        /// <summary>
        ///     The OEM clear.
        /// </summary>
        OemClear = 0xFE,
    }
}
