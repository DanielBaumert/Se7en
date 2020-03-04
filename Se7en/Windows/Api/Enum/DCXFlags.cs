#if Windows
using System;

namespace Se7en.Windows.Api.Enum
{
    [Flags]
    public enum DCXFlags : int
    {
        /// <summary>
        /// Returns a DC that corresponds to the window rectangle rather than the client rectangle.
        /// </summary>
        DCX_WINDOW = 0x00000001,
        /// <summary>
        /// Returns a DC from the cache, rather than the OWNDC or CLASSDC window. Essentially overrides CS_OWNDC and CS_CLASSDC.
        /// </summary>
        DCX_CACHE = 0x00000002,
        /// <summary>
        /// This flag is ignored.
        /// </summary>
        DCX_NORESETATTRS = 0x00000004,
        /// <summary>
        /// Excludes the visible regions of all child windows below the window identified by hWnd.
        /// </summary>
        DCX_CLIPCHILDREN = 0x00000008,
        /// <summary>
        /// Excludes the visible regions of all sibling windows above the window identified by hWnd.
        /// </summary>
        DCX_CLIPSIBLINGS = 0x00000010,
        /// <summary>
        /// Uses the visible region of the parent window.<br/>
        /// The parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored.<br/>
        /// The origin is set to the upper-left corner of the window identified by hWnd.
        /// </summary>
        DCX_PARENTCLIP = 0x00000020,
        /// <summary>
        /// The clipping region identified by hrgnClip is excluded from the visible region of the returned DC.
        /// </summary>
        DCX_EXCLUDERGN = 0x00000040,
        /// <summary>
        /// The clipping region identified by hrgnClip is intersected with the visible region of the returned DC.
        /// </summary>
        DCX_INTERSECTRGN = 0x00000080,
        /// <summary>
        /// Exclude the windoes update region from the vivible region
        /// </summary>
        DCX_EXCLUDEUPDATE = 0x00000100,
        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        DCX_INTERSECTUPDATE = 0x00000200,
        /// <summary>
        /// Allows drawing even if there is a LockWindowUpdate call in effect that would otherwise exclude this window.<br/>
        /// Used for drawing during tracking.
        /// </summary>
        DCX_LOCKWINDOWUPDATE = 0x00000400,
        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        DCX_VALIDATE = 0x00200000,
    }
}
#endif