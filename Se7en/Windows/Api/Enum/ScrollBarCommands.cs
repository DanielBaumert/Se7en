using System;
using System.Collections.Generic;
using System.Text;

namespace Se7en.Windows.Api.Enum
{

    public enum ScrollBarPosition
    {
        SB_HORZ           =  0,
        SB_VERT           =  1,
        SB_CTL            =  2,
        SB_BOTH           =  3
    }

    public enum ScrollBarCommands : int
    {
        SB_LINEUP          =  0,
        SB_LINELEFT        =  0,
        SB_LINEDOWN        =  1,
        SB_LINERIGHT       =  1,
        SB_PAGEUP          =  2,
        SB_PAGELEFT        =  2,
        SB_PAGEDOWN        =  3,
        SB_PAGERIGHT       =  3,
        SB_THUMBPOSITION   =  4,
        SB_THUMBTRACK      =  5,
        SB_TOP             =  6,
        SB_LEFT            =  6,
        SB_BOTTOM          =  7,
        SB_RIGHT           =  7,
        SB_ENDSCROLL       =  8
    }
}
