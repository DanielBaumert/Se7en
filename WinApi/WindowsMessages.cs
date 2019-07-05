namespace Se7en.WinApi {
    public static class WindowsMessages {
        /// <summary>
        /// The WM_ACTIVATE message is sent when a window is being activated or deactivated.<para/>
        /// This message is sent first to the window procedure of the top-level window being deactivated; it is then sent to the window procedure of the top-level window being activated.
        /// </summary>
        public const int WM_ACTIVATE = 0x6;
        /// <summary>
        /// The WM_ACTIVATEAPP message is sent when a window belonging to a different application than the active window is about to be activated.<para/>
        /// The message is sent to the application whose window is being activated and to the application whose window is being deactivated.
        /// </summary>
        public const int WM_ACTIVATEAPP = 0x1C;
        /// <summary>
        /// The WM_AFXFIRST specifies the first afx message.
        /// </summary>
        public const int WM_AFXFIRST = 0x360;
        /// <summary>
        /// The WM_AFXFIRST specifies the last afx message.
        /// </summary>
        public const int WM_AFXLAST = 0x37F;
        /// <summary>
        /// The WM_APP constant is used by applications to help define private messages, usually of the form WM_APP+X, where X is an integer value.
        /// </summary>
        public const int WM_APP = 0x8000;
        /// <summary>
        /// The WM_ASKCBFORMATNAME message is sent to the clipboard owner by a clipboard viewer window to request the name of a CF_OWNERDISPLAY clipboard format.
        /// </summary>
        public const int WM_ASKCBFORMATNAME = 0x30C;
        /// <summary>
        /// The WM_CANCELJOURNAL message is posted to an application when a user cancels the application's journaling activities.<para/>
        /// The message is posted with a NULL window handle.
        /// </summary>
        public const int WM_CANCELJOURNAL = 0x4B;
        /// <summary>
        /// The WM_CANCELMODE message is sent to cancel certain modes, such as mouse capture.<para/>
        /// For example, the system sends this message to the active window when a dialog box or message box is displayed.<para/>
        /// Certain functions also send this message explicitly to the specified window regardless of whether it is the active window.<para/>
        /// For example, the EnableWindow function sends this message when disabling the specified window.
        /// </summary>
        public const int WM_CANCELMODE = 0x1F;
        /// <summary>
        /// The WM_CAPTURECHANGED message is sent to the window that is losing the mouse capture.
        /// </summary>
        public const int WM_CAPTURECHANGED = 0x215;
        /// <summary>
        /// The WM_CHANGECBCHAIN message is sent to the first window in the clipboard viewer chain when a window is being removed from the chain.
        /// </summary>
        public const int WM_CHANGECBCHAIN = 0x30D;
        /// <summary>
        /// An application sends the WM_CHANGEUISTATE message to indicate that the user interface (UI) state should be changed.
        /// </summary>
        public const int WM_CHANGEUISTATE = 0x127;
        /// <summary>
        /// The WM_CHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function.<para/>
        /// The WM_CHAR message contains the character code of the key that was pressed.
        /// </summary>
        public const int WM_CHAR = 0x102;
        /// <summary>
        /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_CHAR message.
        /// </summary>
        public const int WM_CHARTOITEM = 0x2F;
        /// <summary>
        /// The WM_CHILDACTIVATE message is sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.
        /// </summary>
        public const int WM_CHILDACTIVATE = 0x22;
        /// <summary>
        /// An application sends a WM_CLEAR message to an edit control or combo box to delete (clear) the current selection, if any, from the edit control.
        /// </summary>
        public const int WM_CLEAR = 0x303;
        /// <summary>
        /// The WM_CLOSE message is sent as a signal that a window or an application should terminate.
        /// </summary>
        public const int WM_CLOSE = 0x10;
        /// <summary>
        /// The WM_COMMAND message is sent when the user selects a command item from a menu, when a control sends a notification message to its parent window, or when an accelerator keystroke is translated.
        /// </summary>
        public const int WM_COMMAND = 0x111;
        /// <summary>
        /// The WM_COMPACTING message is sent to all top-level windows when the system detects more than 12.<para/>
        ///  percent of system time over a 30- to 60-second interval is being spent compacting memory.<para/>
        /// This indicates that system memory is low.
        /// </summary>
        public const int WM_COMPACTING = 0x41;
        /// <summary>
        /// The system sends the WM_COMPAREITEM message to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box.<para/>
        /// Whenever the application adds a new item, the system sends this message to the owner of a combo box or list box created with the CBS_SORT or LBS_SORT style.
        /// </summary>
        public const int WM_COMPAREITEM = 0x39;
        /// <summary>
        /// The WM_CONTEXTMENU message notifies a window that the user clicked the right mouse button (right-clicked) in the window.
        /// </summary>
        public const int WM_CONTEXTMENU = 0x7B;
        /// <summary>
        /// An application sends the WM_COPY message to an edit control or combo box to copy the current selection to the clipboard in CF_TEXT format.
        /// </summary>
        public const int WM_COPY = 0x301;
        /// <summary>
        /// An application sends the WM_COPYDATA message to pass data to another application.
        /// </summary>
        public const int WM_COPYDATA = 0x4A;
        /// <summary>
        /// The WM_CREATE message is sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function.<para/>
        /// (The message is sent before the function returns.<para/>
        ///  The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
        /// </summary>
        public const int WM_CREATE = 0x1;
        /// <summary>
        /// The WM_CTLCOLORBTN message is sent to the parent window of a button before drawing the button.<para/>
        /// The parent window can change the button's text and background colors.<para/>
        /// However, only owner-drawn buttons respond to the parent window processing this message.
        /// </summary>
        public const int WM_CTLCOLORBTN = 0x135;
        /// <summary>
        /// The WM_CTLCOLORDLG message is sent to a dialog box before the system draws the dialog box.<para/>
        /// By responding to this message, the dialog box can set its text and background colors using the specified display device context handle.
        /// </summary>
        public const int WM_CTLCOLORDLG = 0x136;
        /// <summary>
        /// An edit control that is not read-only or disabled sends the WM_CTLCOLOREDIT message to its parent window when the control is about to be drawn.<para/>
        /// By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the edit control.
        /// </summary>
        public const int WM_CTLCOLOREDIT = 0x133;
        /// <summary>
        /// Sent to the parent window of a list box before the system draws the list box.<para/>
        /// By responding to this message, the parent window can set the text and background colors of the list box by using the specified display device context handle.
        /// </summary>
        public const int WM_CTLCOLORLISTBOX = 0x134;
        /// <summary>
        /// The WM_CTLCOLORMSGBOX message is sent to the owner window of a message box before Windows draws the message box.<para/>
        /// By responding to this message, the owner window can set the text and background colors of the message box by using the given display device context handle.
        /// </summary>
        public const int WM_CTLCOLORMSGBOX = 0x132;
        /// <summary>
        /// The WM_CTLCOLORSCROLLBAR message is sent to the parent window of a scroll bar control when the control is about to be drawn.<para/>
        /// By responding to this message, the parent window can use the display context handle to set the background color of the scroll bar control.
        /// </summary>
        public const int WM_CTLCOLORSCROLLBAR = 0x137;
        /// <summary>
        /// A static control, or an edit control that is read-only or disabled, sends the WM_CTLCOLORSTATIC message to its parent window when the control is about to be drawn.<para/>
        /// By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the static control.
        /// </summary>
        public const int WM_CTLCOLORSTATIC = 0x138;
        /// <summary>
        /// An application sends a WM_CUT message to an edit control or combo box to delete (cut) the current selection, if any, in the edit control and copy the deleted text to the clipboard in CF_TEXT format.
        /// </summary>
        public const int WM_CUT = 0x300;
        /// <summary>
        /// The WM_DEADCHAR message is posted to the window with the keyboard focus when a WM_KEYUP message is translated by the TranslateMessage function.<para/>
        /// WM_DEADCHAR specifies a character code generated by a dead key.<para/>
        /// A dead key is a key that generates a character, such as the umlaut (double-dot), that is combined with another character to form a composite character.<para/>
        /// For example, the umlaut-O character (Ö) is generated by typing the dead key for the umlaut character, and then typing the O key.
        /// </summary>
        public const int WM_DEADCHAR = 0x103;
        /// <summary>
        /// Sent to the owner of a list box or combo box when the list box or combo box is destroyed or when items are removed by the LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or CB_RESETCONTENT message.<para/>
        /// The system sends a WM_DELETEITEM message for each deleted item.<para/>
        /// The system sends the WM_DELETEITEM message for any deleted list box or combo box item with nonzero item data.
        /// </summary>
        public const int WM_DELETEITEM = 0x2D;
        /// <summary>
        /// The WM_DESTROY message is sent when a window is being destroyed.<para/>
        /// It is sent to the window procedure of the window being destroyed after the window is removed from the screen.<para/>
        /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed.<para/>
        /// During the processing of the message, it can be assumed that all child windows still exist.
        /// </summary>
        public const int WM_DESTROY = 0x2;
        /// <summary>
        /// The WM_DESTROYCLIPBOARD message is sent to the clipboard owner when a call to the EmptyClipboard function empties the clipboard.
        /// </summary>
        public const int WM_DESTROYCLIPBOARD = 0x307;
        /// <summary>
        /// Notifies an application of a change to the hardware configuration of a device or the computer.
        /// </summary>
        public const int WM_DEVICECHANGE = 0x219;
        /// <summary>
        /// The WM_DEVMODECHANGE message is sent to all top-level windows whenever the user changes device-mode settings.
        /// </summary>
        public const int WM_DEVMODECHANGE = 0x1B;
        /// <summary>
        /// The WM_DISPLAYCHANGE message is sent to all windows when the display resolution has changed.
        /// </summary>
        public const int WM_DISPLAYCHANGE = 0x7E;
        /// <summary>
        /// The WM_DRAWCLIPBOARD message is sent to the first window in the clipboard viewer chain when the content of the clipboard changes.<para/>
        /// This enables a clipboard viewer window to display the new content of the clipboard.
        /// </summary>
        public const int WM_DRAWCLIPBOARD = 0x308;
        /// <summary>
        /// The WM_DRAWITEM message is sent to the parent window of an owner-drawn button, combo box, list box, or menu when a visual aspect of the button, combo box, list box, or menu has changed.
        /// </summary>
        public const int WM_DRAWITEM = 0x2B;
        /// <summary>
        /// Sent when the user drops a file on the window of an application that has registered itself as a recipient of dropped files.
        /// </summary>
        public const int WM_DROPFILES = 0x233;
        /// <summary>
        /// The WM_ENABLE message is sent when an application changes the enabled state of a window.<para/>
        /// It is sent to the window whose enabled state is changing.<para/>
        /// This message is sent before the EnableWindow function returns, but after the enabled state (WS_DISABLED style bit) of the window has changed.
        /// </summary>
        public const int WM_ENABLE = 0xA;
        /// <summary>
        /// The WM_ENDSESSION message is sent to an application after the system processes the results of the WM_QUERYENDSESSION message.<para/>
        /// The WM_ENDSESSION message informs the application whether the session is ending.
        /// </summary>
        public const int WM_ENDSESSION = 0x16;
        /// <summary>
        /// The WM_ENTERIDLE message is sent to the owner window of a modal dialog box or menu that is entering an idle state.<para/>
        /// A modal dialog box or menu enters an idle state when no messages are waiting in its queue after it has processed one or more previous messages.
        /// </summary>
        public const int WM_ENTERIDLE = 0x121;
        /// <summary>
        /// The WM_ENTERMENULOOP message informs an application's main window procedure that a menu modal loop has been entered.
        /// </summary>
        public const int WM_ENTERMENULOOP = 0x211;
        /// <summary>
        /// The WM_ENTERSIZEMOVE message is sent one time to a window after it enters the moving or sizing modal loop.<para/>
        /// The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value.<para/>
        /// The operation is complete when DefWindowProc returns.
        /// </summary>
        public const int WM_ENTERSIZEMOVE = 0x231;
        /// <summary>
        /// The WM_ERASEBKGND message is sent when the window background must be erased (for example, when a window is resized).<para/>
        /// The message is sent to prepare an invalidated portion of a window for painting.
        /// </summary>
        public const int WM_ERASEBKGND = 0x14;
        /// <summary>
        /// The WM_EXITMENULOOP message informs an application's main window procedure that a menu modal loop has been exited.
        /// </summary>
        public const int WM_EXITMENULOOP = 0x212;
        /// <summary>
        /// The WM_EXITSIZEMOVE message is sent one time to a window, after it has exited the moving or sizing modal loop.<para/>
        /// The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value.<para/>
        /// The operation is complete when DefWindowProc returns.
        /// </summary>
        public const int WM_EXITSIZEMOVE = 0x232;
        /// <summary>
        /// An application sends the WM_FONTCHANGE message to all top-level windows in the system after changing the pool of font resources.
        /// </summary>
        public const int WM_FONTCHANGE = 0x1D;
        /// <summary>
        /// The WM_GETDLGCODE message is sent to the window procedure associated with a control.<para/>
        /// By default, the system handles all keyboard input to the control; the system interprets certain types of keyboard input as dialog box navigation keys.<para/>
        /// To override this default behavior, the control can respond to the WM_GETDLGCODE message to indicate the types of input it wants to process itself.
        /// </summary>
        public const int WM_GETDLGCODE = 0x87;
        /// <summary>
        /// An application sends a WM_GETFONT message to a control to retrieve the font with which the control is currently drawing its text.
        /// </summary>
        public const int WM_GETFONT = 0x31;
        /// <summary>
        /// An application sends a WM_GETHOTKEY message to determine the hot key associated with a window.
        /// </summary>
        public const int WM_GETHOTKEY = 0x33;
        /// <summary>
        /// The WM_GETICON message is sent to a window to retrieve a handle to the large or small icon associated with a window.<para/>
        /// The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption.
        /// </summary>
        public const int WM_GETICON = 0x7F;
        /// <summary>
        /// The WM_GETMINMAXINFO message is sent to a window when the size or position of the window is about to change.<para/>
        /// An application can use this message to override the window's default maximized size and position, or its default minimum or maximum tracking size.
        /// </summary>
        public const int WM_GETMINMAXINFO = 0x24;
        /// <summary>
        /// Active Accessibility sends the WM_GETOBJECT message to obtain information about an accessible object contained in a server application.<para/>
        /// Applications never send this message directly.<para/>
        /// It is sent only by Active Accessibility in response to calls to AccessibleObjectFromPoint, AccessibleObjectFromEvent, or AccessibleObjectFromWindow.<para/>
        /// However, server applications handle this message.
        /// </summary>
        public const int WM_GETOBJECT = 0x3D;
        /// <summary>
        /// An application sends a WM_GETTEXT message to copy the text that corresponds to a window into a buffer provided by the caller.
        /// </summary>
        public const int WM_GETTEXT = 0xD;
        /// <summary>
        /// An application sends a WM_GETTEXTLENGTH message to determine the length, in characters, of the text associated with a window.
        /// </summary>
        public const int WM_GETTEXTLENGTH = 0xE;
        /// <summary>
        /// Definition Needed
        /// </summary>
        public const int WM_HANDHELDFIRST = 0x358;
        /// <summary>
        /// Definition Needed
        /// </summary>
        public const int WM_HANDHELDLAST = 0x35F;
        /// <summary>
        /// Indicates that the user pressed the F1 key.<para/>
        /// If a menu is active when F1 is pressed, WM_HELP is sent to the window associated with the menu; otherwise, WM_HELP is sent to the window that has the keyboard focus.<para/>
        /// If no window has the keyboard focus, WM_HELP is sent to the currently active window.
        /// </summary>
        public const int WM_HELP = 0x53;
        /// <summary>
        /// The WM_HOTKEY message is posted when the user presses a hot key registered by the RegisterHotKey function.<para/>
        /// The message is placed at the top of the message queue associated with the thread that registered the hot key.
        /// </summary>
        public const int WM_HOTKEY = 0x312;
        /// <summary>
        /// This message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar.<para/>
        /// This message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control.
        /// </summary>
        public const int WM_HSCROLL = 0x114;
        /// <summary>
        /// The WM_HSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window.<para/>
        /// This occurs when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's horizontal scroll bar.<para/>
        /// The owner should scroll the clipboard image and update the scroll bar values.
        /// </summary>
        public const int WM_HSCROLLCLIPBOARD = 0x30E;
        /// <summary>
        /// Windows NT 3.<para/>
        /// 1 and earlier: The WM_ICONERASEBKGND message is sent to a minimized window when the background of the icon must be filled before painting the icon.<para/>
        /// A window receives this message only if a class icon is defined for the window; otherwise, WM_ERASEBKGND is sent.<para/>
        /// This message is not sent by newer versions of Windows.
        /// </summary>
        public const int WM_ICONERASEBKGND = 0x27;
        /// <summary>
        /// Sent to an application when the IME gets a character of the conversion result.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_CHAR = 0x286;
        /// <summary>
        /// Sent to an application when the IME changes composition status as a result of a keystroke.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_COMPOSITION = 0x10F;
        /// <summary>
        /// Sent to an application when the IME window finds no space to extend the area for the composition window.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_COMPOSITIONFULL = 0x284;
        /// <summary>
        /// Sent by an application to direct the IME window to carry out the requested command.<para/>
        /// The application uses this message to control the IME window that it has created.<para/>
        /// To send this message, the application calls the SendMessage function with the following parameters.
        /// </summary>
        public const int WM_IME_CONTROL = 0x283;
        /// <summary>
        /// Sent to an application when the IME ends composition.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_ENDCOMPOSITION = 0x10E;
        /// <summary>
        /// Sent to an application by the IME to notify the application of a key press and to keep message order.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_KEYDOWN = 0x290;
        /// <summary>
        /// Definition Needed
        /// </summary>
        public const int WM_IME_KEYLAST = 0x10F;
        /// <summary>
        /// Sent to an application by the IME to notify the application of a key release and to keep message order.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_KEYUP = 0x291;
        /// <summary>
        /// Sent to an application to notify it of changes to the IME window.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_NOTIFY = 0x282;
        /// <summary>
        /// Sent to an application to provide commands and request information.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_REQUEST = 0x288;
        /// <summary>
        /// Sent to an application when the operating system is about to change the current IME.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_SELECT = 0x285;
        /// <summary>
        /// Sent to an application when a window is activated.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_SETCONTEXT = 0x281;
        /// <summary>
        /// Sent immediately before the IME generates the composition string as a result of a keystroke.<para/>
        /// A window receives this message through its WindowProc function.
        /// </summary>
        public const int WM_IME_STARTCOMPOSITION = 0x10D;
        /// <summary>
        /// The WM_INITDIALOG message is sent to the dialog box procedure immediately before a dialog box is displayed.<para/>
        /// Dialog box procedures typically use this message to initialize controls and carry out any other initialization tasks that affect the appearance of the dialog box.
        /// </summary>
        public const int WM_INITDIALOG = 0x110;
        /// <summary>
        /// The WM_INITMENU message is sent when a menu is about to become active.<para/>
        /// It occurs when the user clicks an item on the menu bar or presses a menu key.<para/>
        /// This allows the application to modify the menu before it is displayed.
        /// </summary>
        public const int WM_INITMENU = 0x116;
        /// <summary>
        /// The WM_INITMENUPOPUP message is sent when a drop-down menu or submenu is about to become active.<para/>
        /// This allows an application to modify the menu before it is displayed, without changing the entire menu.
        /// </summary>
        public const int WM_INITMENUPOPUP = 0x117;
        /// <summary>
        /// The WM_INPUTLANGCHANGE message is sent to the topmost affected window after an application's input language has been changed.<para/>
        /// You should make any application-specific settings and pass the message to the DefWindowProc function, which passes the message to all first-level child windows.<para/>
        /// These child windows can pass the message to DefWindowProc to have it pass the message to their child windows, and so on.
        /// </summary>
        public const int WM_INPUTLANGCHANGE = 0x51;
        /// <summary>
        /// The WM_INPUTLANGCHANGEREQUEST message is posted to the window with the focus when the user chooses a new input language, either with the hotkey (specified in the Keyboard control panel application) or from the indicator on the system taskbar.<para/>
        /// An application can accept the change by passing the message to the DefWindowProc function or reject the change (and prevent it from taking place) by returning immediately.
        /// </summary>
        public const int WM_INPUTLANGCHANGEREQUEST = 0x50;
        /// <summary>
        /// The WM_KEYDOWN message is posted to the window with the keyboard focus when a nonsystem key is pressed.<para/>
        /// A nonsystem key is a key that is pressed when the ALT key is not pressed.
        /// </summary>
        public const int WM_KEYDOWN = 0x100;
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        public const int WM_KEYFIRST = 0x100;
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        public const int WM_KEYLAST = 0x108;
        /// <summary>
        /// The WM_KEYUP message is posted to the window with the keyboard focus when a nonsystem key is released.<para/>
        /// A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus.
        /// </summary>
        public const int WM_KEYUP = 0x101;
        /// <summary>
        /// The WM_KILLFOCUS message is sent to a window immediately before it loses the keyboard focus.
        /// </summary>
        public const int WM_KILLFOCUS = 0x8;
        /// <summary>
        /// The WM_LBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_LBUTTONDBLCLK = 0x203;
        /// <summary>
        /// The WM_LBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x201;
        /// <summary>
        /// The WM_LBUTTONUP message is posted when the user releases the left mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_LBUTTONUP = 0x202;
        /// <summary>
        /// The WM_MBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_MBUTTONDBLCLK = 0x209;
        /// <summary>
        /// The WM_MBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_MBUTTONDOWN = 0x207;
        /// <summary>
        /// The WM_MBUTTONUP message is posted when the user releases the middle mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_MBUTTONUP = 0x208;
        /// <summary>
        /// An application sends the WM_MDIACTIVATE message to a multiple-document interface (MDI) client window to instruct the client window to activate a different MDI child window.
        /// </summary>
        public const int WM_MDIACTIVATE = 0x222;
        /// <summary>
        /// An application sends the WM_MDICASCADE message to a multiple-document interface (MDI) client window to arrange all its child windows in a cascade format.
        /// </summary>
        public const int WM_MDICASCADE = 0x227;
        /// <summary>
        /// An application sends the WM_MDICREATE message to a multiple-document interface (MDI) client window to create an MDI child window.
        /// </summary>
        public const int WM_MDICREATE = 0x220;
        /// <summary>
        /// An application sends the WM_MDIDESTROY message to a multiple-document interface (MDI) client window to close an MDI child window.
        /// </summary>
        public const int WM_MDIDESTROY = 0x221;
        /// <summary>
        /// An application sends the WM_MDIGETACTIVE message to a multiple-document interface (MDI) client window to retrieve the handle to the active MDI child window.
        /// </summary>
        public const int WM_MDIGETACTIVE = 0x229;
        /// <summary>
        /// An application sends the WM_MDIICONARRANGE message to a multiple-document interface (MDI) client window to arrange all minimized MDI child windows.<para/>
        /// It does not affect child windows that are not minimized.
        /// </summary>
        public const int WM_MDIICONARRANGE = 0x228;
        /// <summary>
        /// An application sends the WM_MDIMAXIMIZE message to a multiple-document interface (MDI) client window to maximize an MDI child window.<para/>
        /// The system resizes the child window to make its client area fill the client window.<para/>
        /// The system places the child window's window menu icon in the rightmost position of the frame window's menu bar, and places the child window's restore icon in the leftmost position.<para/>
        /// The system also appends the title bar text of the child window to that of the frame window.
        /// </summary>
        public const int WM_MDIMAXIMIZE = 0x225;
        /// <summary>
        /// An application sends the WM_MDINEXT message to a multiple-document interface (MDI) client window to activate the next or previous child window.
        /// </summary>
        public const int WM_MDINEXT = 0x224;
        /// <summary>
        /// An application sends the WM_MDIREFRESHMENU message to a multiple-document interface (MDI) client window to refresh the window menu of the MDI frame window.
        /// </summary>
        public const int WM_MDIREFRESHMENU = 0x234;
        /// <summary>
        /// An application sends the WM_MDIRESTORE message to a multiple-document interface (MDI) client window to restore an MDI child window from maximized or minimized size.
        /// </summary>
        public const int WM_MDIRESTORE = 0x223;
        /// <summary>
        /// An application sends the WM_MDISETMENU message to a multiple-document interface (MDI) client window to replace the entire menu of an MDI frame window, to replace the window menu of the frame window, or both.
        /// </summary>
        public const int WM_MDISETMENU = 0x230;
        /// <summary>
        /// An application sends the WM_MDITILE message to a multiple-document interface (MDI) client window to arrange all of its MDI child windows in a tile format.
        /// </summary>
        public const int WM_MDITILE = 0x226;
        /// <summary>
        /// The WM_MEASUREITEM message is sent to the owner window of a combo box, list box, list view control, or menu item when the control or menu is created.
        /// </summary>
        public const int WM_MEASUREITEM = 0x2C;
        /// <summary>
        /// The WM_MENUCHAR message is sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key.<para/>
        /// This message is sent to the window that owns the menu.
        /// </summary>
        public const int WM_MENUCHAR = 0x120;
        /// <summary>
        /// The WM_MENUCOMMAND message is sent when the user makes a selection from a menu.
        /// </summary>
        public const int WM_MENUCOMMAND = 0x126;
        /// <summary>
        /// The WM_MENUDRAG message is sent to the owner of a drag-and-drop menu when the user drags a menu item.
        /// </summary>
        public const int WM_MENUDRAG = 0x123;
        /// <summary>
        /// The WM_MENUGETOBJECT message is sent to the owner of a drag-and-drop menu when the mouse cursor enters a menu item or moves from the center of the item to the top or bottom of the item.
        /// </summary>
        public const int WM_MENUGETOBJECT = 0x124;
        /// <summary>
        /// The WM_MENURBUTTONUP message is sent when the user releases the right mouse button while the cursor is on a menu item.
        /// </summary>
        public const int WM_MENURBUTTONUP = 0x122;
        /// <summary>
        /// The WM_MENUSELECT message is sent to a menu's owner window when the user selects a menu item.
        /// </summary>
        public const int WM_MENUSELECT = 0x11F;
        /// <summary>
        /// The WM_MOUSEACTIVATE message is sent when the cursor is in an inactive window and the user presses a mouse button.<para/>
        /// The parent window receives this message only if the child window passes it to the DefWindowProc function.
        /// </summary>
        public const int WM_MOUSEACTIVATE = 0x21;
        /// <summary>
        /// Use WM_MOUSEFIRST to specify the first mouse message.<para/>
        /// Use the PeekMessage() Function.
        /// </summary>
        public const int WM_MOUSEFIRST = 0x200;
        /// <summary>
        /// The WM_MOUSEHOVER message is posted to a window when the cursor hovers over the client area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        public const int WM_MOUSEHOVER = 0x2A1;
        /// <summary>
        /// Definition Needed
        /// </summary>
        public const int WM_MOUSELAST = 0x20D;
        /// <summary>
        /// The WM_MOUSELEAVE message is posted to a window when the cursor leaves the client area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        public const int WM_MOUSELEAVE = 0x2A3;
        /// <summary>
        /// The WM_MOUSEMOVE message is posted to a window when the cursor moves.<para/>
        /// If the mouse is not captured, the message is posted to the window that contains the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_MOUSEMOVE = 0x200;
        /// <summary>
        /// The WM_MOUSEWHEEL message is sent to the focus window when the mouse wheel is rotated.<para/>
        /// The DefWindowProc function propagates the message to the window's parent.<para/>
        /// There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        public const int WM_MOUSEWHEEL = 0x20A;
        /// <summary>
        /// The WM_MOUSEHWHEEL message is sent to the focus window when the mouse's horizontal scroll wheel is tilted or rotated.<para/>
        /// The DefWindowProc function propagates the message to the window's parent.<para/>
        /// There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        public const int WM_MOUSEHWHEEL = 0x20E;
        /// <summary>
        /// The WM_MOVE message is sent after a window has been moved.
        /// </summary>
        public const int WM_MOVE = 0x3;
        /// <summary>
        /// The WM_MOVING message is sent to a window that the user is moving.<para/>
        /// By processing this message, an application can monitor the position of the drag rectangle and, if needed, change its position.
        /// </summary>
        public const int WM_MOVING = 0x216;
        /// <summary>
        /// Non Client Area Activated Caption(Title) of the Form
        /// </summary>
        public const int WM_NCACTIVATE = 0x86;
        /// <summary>
        /// The WM_NCCALCSIZE message is sent when the size and position of a window's client area must be calculated.<para/>
        /// By processing this message, an application can control the content of the window's client area when the size or position of the window changes.
        /// </summary>
        public const int WM_NCCALCSIZE = 0x83;
        /// <summary>
        /// The WM_NCCREATE message is sent prior to the WM_CREATE message when a window is first created.
        /// </summary>
        public const int WM_NCCREATE = 0x81;
        /// <summary>
        /// The WM_NCDESTROY message informs a window that its nonclient area is being destroyed.<para/>
        /// The DestroyWindow function sends the WM_NCDESTROY message to the window following the WM_DESTROY message.<para/>
        /// WM_DESTROY is used to free the allocated memory object associated with the window.
        /// </summary>
        public const int WM_NCDESTROY = 0x82;
        /// <summary>
        /// The WM_NCHITTEST message is sent to a window when the cursor moves, or when a mouse button is pressed or released.<para/>
        /// If the mouse is not captured, the message is sent to the window beneath the cursor.<para/>
        /// Otherwise, the message is sent to the window that has captured the mouse.
        /// </summary>
        public const int WM_NCHITTEST = 0x84;
        /// <summary>
        /// The WM_NCLBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCLBUTTONDBLCLK = 0xA3;
        /// <summary>
        /// The WM_NCLBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;
        /// <summary>
        /// The WM_NCLBUTTONUP message is posted when the user releases the left mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCLBUTTONUP = 0xA2;
        /// <summary>
        /// The WM_NCMBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCMBUTTONDBLCLK = 0xA9;
        /// <summary>
        /// The WM_NCMBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCMBUTTONDOWN = 0xA7;
        /// <summary>
        /// The WM_NCMBUTTONUP message is posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCMBUTTONUP = 0xA8;
        /// <summary>
        /// The WM_NCMOUSEHOVER message is posted to a window when the cursor hovers over the nonclient area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        public const int WM_NCMOUSEHOVER = 0x2A0;
        /// <summary>
        /// The WM_NCMOUSELEAVE message is posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        public const int WM_NCMOUSELEAVE = 0x2A2;
        /// <summary>
        /// The WM_NCMOUSEMOVE message is posted to a window when the cursor is moved within the nonclient area of the window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCMOUSEMOVE = 0xA0;
        /// <summary>
        /// The WM_NCPAINT message is sent to a window when its frame must be painted.
        /// </summary>
        public const int WM_NCPAINT = 0x85;
        /// <summary>
        /// The WM_NCRBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCRBUTTONDBLCLK = 0xA6;
        /// <summary>
        /// The WM_NCRBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCRBUTTONDOWN = 0xA4;
        /// <summary>
        /// The WM_NCRBUTTONUP message is posted when the user releases the right mouse button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCRBUTTONUP = 0xA5;
        /// <summary>
        /// The WM_NCXBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCXBUTTONDBLCLK = 0xAD;
        /// <summary>
        /// The WM_NCXBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCXBUTTONDOWN = 0xAB;
        /// <summary>
        /// The WM_NCXBUTTONUP message is posted when the user releases the first or second X button while the cursor is within the nonclient area of a window.<para/>
        /// This message is posted to the window that contains the cursor.<para/>
        /// If a window has captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCXBUTTONUP = 0xAC;
        /// <summary>
        /// The WM_NCUAHDRAWCAPTION message is an undocumented message related to themes.<para/>
        /// When handling WM_NCPAINT, this message should also be handled.
        /// </summary>
        public const int WM_NCUAHDRAWCAPTION = 0xAE;
        /// <summary>
        /// The WM_NCUAHDRAWFRAME message is an undocumented message related to themes.<para/>
        /// When handling WM_NCPAINT, this message should also be handled.
        /// </summary>
        public const int WM_NCUAHDRAWFRAME = 0xAF;
        /// <summary>
        /// The WM_NEXTDLGCTL message is sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box
        /// </summary>
        public const int WM_NEXTDLGCTL = 0x28;
        /// <summary>
        /// The WM_NEXTMENU message is sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu.
        /// </summary>
        public const int WM_NEXTMENU = 0x213;
        /// <summary>
        /// Sent by a common control to its parent window when an event has occurred or the control requires some information.
        /// </summary>
        public const int WM_NOTIFY = 0x4E;
        /// <summary>
        /// Determines if a window accepts ANSI or Unicode structures in the WM_NOTIFY notification message.<para/>
        /// WM_NOTIFYFORMAT messages are sent from a common control to its parent window and from the parent window to the common control.
        /// </summary>
        public const int WM_NOTIFYFORMAT = 0x55;
        /// <summary>
        /// The WM_NULL message performs no operation.<para/>
        /// An application sends the WM_NULL message if it wants to post a message that the recipient window will ignore.
        /// </summary>
        public const int WM_NULL = 0x0;
        /// <summary>
        /// Occurs when the control needs repainting
        /// </summary>
        public const int WM_PAINT = 0xF;
        /// <summary>
        /// The WM_PAINTCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area needs repainting.
        /// </summary>
        public const int WM_PAINTCLIPBOARD = 0x309;
        /// <summary>
        /// Windows NT 3.<para/>
        /// 1 and earlier: The WM_PAINTICON message is sent to a minimized window when the icon is to be painted.<para/>
        /// This message is not sent by newer versions of Microsoft Windows, except in unusual circumstances explained in the Remarks.
        /// </summary>
        public const int WM_PAINTICON = 0x26;
        /// <summary>
        /// This message is sent by the OS to all top-level and overlapped windows after the window with the keyboard focus realizes its logical palette.<para/>
        /// This message enables windows that do not have the keyboard focus to realize their logical palettes and update their client areas.
        /// </summary>
        public const int WM_PALETTECHANGED = 0x311;
        /// <summary>
        /// The WM_PALETTEISCHANGING message informs applications that an application is going to realize its logical palette.
        /// </summary>
        public const int WM_PALETTEISCHANGING = 0x310;
        /// <summary>
        /// The WM_PARENTNOTIFY message is sent to the parent of a child window when the child window is created or destroyed, or when the user clicks a mouse button while the cursor is over the child window.<para/>
        /// When the child window is being created, the system sends WM_PARENTNOTIFY just before the CreateWindow or CreateWindowEx function that creates the window returns.<para/>
        /// When the child window is being destroyed, the system sends the message before any processing to destroy the window takes place.
        /// </summary>
        public const int WM_PARENTNOTIFY = 0x210;
        /// <summary>
        /// An application sends a WM_PASTE message to an edit control or combo box to copy the current content of the clipboard to the edit control at the current caret position.<para/>
        /// Data is inserted only if the clipboard contains data in CF_TEXT format.
        /// </summary>
        public const int WM_PASTE = 0x302;
        /// <summary>
        /// Definition Needed
        /// </summary>
        public const int WM_PENWINFIRST = 0x380;
        /// <summary>
        /// Definition Needed
        /// </summary>
        public const int WM_PENWINLAST = 0x38F;
        /// <summary>
        /// Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.<para/>
        /// Obsolete : use POWERBROADCAST instead
        /// </summary>
        public const int WM_POWER = 0x48;
        /// <summary>
        /// Notifies applications that a power-management event has occurred.
        /// </summary>
        public const int WM_POWERBROADCAST = 0x218;
        /// <summary>
        /// The WM_PRINT message is sent to a window to request that it draw itself in the specified device context, most commonly in a printer device context.
        /// </summary>
        public const int WM_PRINT = 0x317;
        /// <summary>
        /// The WM_PRINTCLIENT message is sent to a window to request that it draw its client area in the specified device context, most commonly in a printer device context.
        /// </summary>
        public const int WM_PRINTCLIENT = 0x318;
        /// <summary>
        /// The WM_QUERYDRAGICON message is sent to a minimized (iconic) window.<para/>
        /// The window is about to be dragged by the user but does not have an icon defined for its class.<para/>
        /// An application can return a handle to an icon or cursor.<para/>
        /// The system displays this cursor or icon while the user drags the icon.
        /// </summary>
        public const int WM_QUERYDRAGICON = 0x37;
        /// <summary>
        /// The WM_QUERYENDSESSION message is sent when the user chooses to end the session or when an application calls one of the system shutdown functions.<para/>
        /// If any application returns zero, the session is not ended.<para/>
        /// The system stops sending WM_QUERYENDSESSION messages as soon as one application returns zero.<para/>
        /// After processing this message, the system sends the WM_ENDSESSION message with the wParam parameter set to the results of the WM_QUERYENDSESSION message.
        /// </summary>
        public const int WM_QUERYENDSESSION = 0x11;
        /// <summary>
        /// This message informs a window that it is about to receive the keyboard focus, giving the window the opportunity to realize its logical palette when it receives the focus.
        /// </summary>
        public const int WM_QUERYNEWPALETTE = 0x30F;
        /// <summary>
        /// The WM_QUERYOPEN message is sent to an icon when the user requests that the window be restored to its previous size and position.
        /// </summary>
        public const int WM_QUERYOPEN = 0x13;
        /// <summary>
        /// The WM_QUEUESYNC message is sent by a computer-based training (CBT) application to separate user-input messages from other messages sent through the WH_JOURNALPLAYBACK Hook procedure.
        /// </summary>
        public const int WM_QUEUESYNC = 0x23;
        /// <summary>
        /// Once received, it ends the application's Message Loop, signaling the application to end.<para/>
        /// It can be sent by pressing Alt+F4, Clicking the X in the upper right-hand of the program, or going to File->Exit.
        /// </summary>
        public const int WM_QUIT = 0x12;
        /// <summary>
        /// he WM_RBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_RBUTTONDBLCLK = 0x206;
        /// <summary>
        /// The WM_RBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_RBUTTONDOWN = 0x204;
        /// <summary>
        /// The WM_RBUTTONUP message is posted when the user releases the right mouse button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_RBUTTONUP = 0x205;
        /// <summary>
        /// The WM_RENDERALLFORMATS message is sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard formats.<para/>
        /// For the content of the clipboard to remain available to other applications, the clipboard owner must render data in all the formats it is capable of generating, and place the data on the clipboard by calling the SetClipboardData function.
        /// </summary>
        public const int WM_RENDERALLFORMATS = 0x306;
        /// <summary>
        /// The WM_RENDERFORMAT message is sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in that format.<para/>
        /// The clipboard owner must render data in the specified format and place it on the clipboard by calling the SetClipboardData function.
        /// </summary>
        public const int WM_RENDERFORMAT = 0x305;
        /// <summary>
        /// The WM_SETCURSOR message is sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.
        /// </summary>
        public const int WM_SETCURSOR = 0x20;
        /// <summary>
        /// When the controll got the focus
        /// </summary>
        public const int WM_SETFOCUS = 0x7;
        /// <summary>
        /// An application sends a WM_SETFONT message to specify the font that a control is to use when drawing text.
        /// </summary>
        public const int WM_SETFONT = 0x30;
        /// <summary>
        /// An application sends a WM_SETHOTKEY message to a window to associate a hot key with the window.<para/>
        /// When the user presses the hot key, the system activates the window.
        /// </summary>
        public const int WM_SETHOTKEY = 0x32;
        /// <summary>
        /// An application sends the WM_SETICON message to associate a new large or small icon with a window.<para/>
        /// The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption.
        /// </summary>
        public const int WM_SETICON = 0x80;
        /// <summary>
        /// An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn.
        /// </summary>
        public const int WM_SETREDRAW = 0xB;
        /// <summary>
        /// Text / Caption changed on the control.<para/>
        /// An application sends a WM_SETTEXT message to set the text of a window.
        /// </summary>
        public const int WM_SETTEXT = 0xC;
        /// <summary>
        /// An application sends the WM_SETTINGCHANGE message to all top-level windows after making a change to the WIN.<para/>
        /// NI file.<para/>
        /// The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.<para/>
        /// NI.
        /// </summary>
        public const int WM_SETTINGCHANGE = 0x1A;
        /// <summary>
        /// The WM_SHOWWINDOW message is sent to a window when the window is about to be hidden or shown
        /// </summary>
        public const int WM_SHOWWINDOW = 0x18;
        /// <summary>
        /// The WM_SIZE message is sent to a window after its size has changed.
        /// </summary>
        public const int WM_SIZE = 0x5;
        /// <summary>
        /// The WM_SIZECLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area has changed size.
        /// </summary>
        public const int WM_SIZECLIPBOARD = 0x30B;
        /// <summary>
        /// The WM_SIZING message is sent to a window that the user is resizing.<para/>
        /// By processing this message, an application can monitor the size and position of the drag rectangle and, if needed, change its size or position.
        /// </summary>
        public const int WM_SIZING = 0x214;
        /// <summary>
        /// The WM_SPOOLERSTATUS message is sent from Print Manager whenever a job is added to or removed from the Print Manager queue.
        /// </summary>
        public const int WM_SPOOLERSTATUS = 0x2A;
        /// <summary>
        /// The WM_STYLECHANGED message is sent to a window after the SetWindowLong function has changed one or more of the window's styles.
        /// </summary>
        public const int WM_STYLECHANGED = 0x7D;
        /// <summary>
        /// The WM_STYLECHANGING message is sent to a window when the SetWindowLong function is about to change one or more of the window's styles.
        /// </summary>
        public const int WM_STYLECHANGING = 0x7C;
        /// <summary>
        /// The WM_SYNCPAINT message is used to synchronize painting while avoiding linking independent GUI threads.
        /// </summary>
        public const int WM_SYNCPAINT = 0x88;
        /// <summary>
        /// The WM_SYSCHAR message is posted to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function.<para/>
        /// It specifies the character code of a system character key — that is, a character key that is pressed while the ALT key is down.
        /// </summary>
        public const int WM_SYSCHAR = 0x106;
        /// <summary>
        /// This message is sent to all top-level windows when a change is made to a system color setting.
        /// </summary>
        public const int WM_SYSCOLORCHANGE = 0x15;
        /// <summary>
        /// A window receives this message when the user chooses a command from the Window menu (formerly known as the system or control menu) or when the user chooses the maximize button, minimize button, restore button, or close button.
        /// </summary>
        public const int WM_SYSCOMMAND = 0x112;
        /// <summary>
        /// The WM_SYSDEADCHAR message is sent to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function.<para/>
        /// WM_SYSDEADCHAR specifies the character code of a system dead key — that is, a dead key that is pressed while holding down the ALT key.
        /// </summary>
        public const int WM_SYSDEADCHAR = 0x107;
        /// <summary>
        /// The WM_SYSKEYDOWN message is posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key.<para/>
        /// It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to the active window.<para/>
        /// The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
        /// </summary>
        public const int WM_SYSKEYDOWN = 0x104;
        /// <summary>
        /// The WM_SYSKEYUP message is posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down.<para/>
        /// It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent to the active window.<para/>
        /// The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
        /// </summary>
        public const int WM_SYSKEYUP = 0x105;
        /// <summary>
        /// Sent to an application that has initiated a training card with Microsoft Windows Help.<para/>
        /// The message informs the application when the user clicks an authorable button.<para/>
        /// An application initiates a training card by specifying the HELP_TCARD command in a call to the WinHelp function.
        /// </summary>
        public const int WM_TCARD = 0x52;
        /// <summary>
        /// A message that is sent whenever there is a change in the system time.
        /// </summary>
        public const int WM_TIMECHANGE = 0x1E;
        /// <summary>
        /// The WM_TIMER message is posted to the installing thread's message queue when a timer expires.<para/>
        /// The message is posted by the GetMessage or PeekMessage function.
        /// </summary>
        public const int WM_TIMER = 0x113;
        /// <summary>
        /// An application sends a WM_UNDO message to an edit control to undo the last operation.<para/>
        /// When this message is sent to an edit control, the previously deleted text is restored or the previously added text is deleted.
        /// </summary>
        public const int WM_UNDO = 0x304;
        /// <summary>
        /// The WM_UNINITMENUPOPUP message is sent when a drop-down menu or submenu has been destroyed.
        /// </summary>
        public const int WM_UNINITMENUPOPUP = 0x125;
        /// <summary>
        /// The WM_USER constant is used by applications to help define private messages for use by private window classes, usually of the form WM_USER+X, where X is an integer value.
        /// </summary>
        public const int WM_USER = 0x400;
        /// <summary>
        /// The WM_USERCHANGED message is sent to all windows after the user has logged on or off.<para/>
        /// When the user logs on or off, the system updates the user-specific settings.<para/>
        /// The system sends this message immediately after updating the settings.
        /// </summary>
        public const int WM_USERCHANGED = 0x54;
        /// <summary>
        /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_KEYDOWN message.
        /// </summary>
        public const int WM_VKEYTOITEM = 0x2E;
        /// <summary>
        /// The WM_VSCROLL message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar.<para/>
        /// This message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control.
        /// </summary>
        public const int WM_VSCROLL = 0x115;
        /// <summary>
        /// The WM_VSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's vertical scroll bar.<para/>
        /// The owner should scroll the clipboard image and update the scroll bar values.
        /// </summary>
        public const int WM_VSCROLLCLIPBOARD = 0x30A;
        /// <summary>
        /// The WM_WINDOWPOSCHANGED message is sent to a window whose size, position, or place in the Z order has changed as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        public const int WM_WINDOWPOSCHANGED = 0x47;
        /// <summary>
        /// The WM_WINDOWPOSCHANGING message is sent to a window whose size, position, or place in the Z order is about to change as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        public const int WM_WINDOWPOSCHANGING = 0x46;
        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.<para/>
        /// NI file.<para/>
        /// The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.<para/>
        /// NI.<para/>
        /// Note The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system.<para/>
        /// Applications should use the WM_SETTINGCHANGE message.
        /// </summary>
        public const int WM_WININICHANGE = 0x1A;
        /// <summary>
        /// The WM_XBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_XBUTTONDBLCLK = 0x20D;
        /// <summary>
        /// The WM_XBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_XBUTTONDOWN = 0x20B;
        /// <summary>
        /// The WM_XBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the client area of a window.<para/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<para/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_XBUTTONUP = 0x20C;

    }
}
