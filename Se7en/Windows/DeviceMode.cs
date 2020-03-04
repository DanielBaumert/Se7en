#if Windows
using System;
using System.Collections.Generic;
using System.Text;

namespace Se7en.Windows
{
    // typedef struct _devicemodeA {
    //     BYTE  dmDeviceName[CCHDEVICENAME];
    //     WORD  dmSpecVersion;
    //     WORD  dmDriverVersion;
    //     WORD  dmSize;
    //     WORD  dmDriverExtra;
    //     DWORD dmFields;
    //     union {
    //     struct {
    //         short dmOrientation;
    //         short dmPaperSize;
    //         short dmPaperLength;
    //         short dmPaperWidth;
    //         short dmScale;
    //         short dmCopies;
    //         short dmDefaultSource;
    //         short dmPrintQuality;
    //     } DUMMYSTRUCTNAME;
    //     POINTL dmPosition;
    //     struct {
    //         POINTL dmPosition;
    //         DWORD  dmDisplayOrientation;
    //         DWORD  dmDisplayFixedOutput;
    //     } DUMMYSTRUCTNAME2;
    //     } DUMMYUNIONNAME;
    //     short dmColor;
    //     short dmDuplex;
    //     short dmYResolution;
    //     short dmTTOption;
    //     short dmCollate;
    //     BYTE  dmFormName[CCHFORMNAME];
    //     WORD  dmLogPixels;
    //     DWORD dmBitsPerPel;
    //     DWORD dmPelsWidth;
    //     DWORD dmPelsHeight;
    //     union {
    //     DWORD dmDisplayFlags;
    //     DWORD dmNup;
    //     } DUMMYUNIONNAME2;
    //     DWORD dmDisplayFrequency;
    //     DWORD dmICMMethod;
    //     DWORD dmICMIntent;
    //     DWORD dmMediaType;
    //     DWORD dmDitherType;
    //     DWORD dmReserved1;
    //     DWORD dmReserved2;
    //     DWORD dmPanningWidth;
    //     DWORD dmPanningHeight;
    // } DEVMODEA, *PDEVMODEA, *NPDEVMODEA, *LPDEVMODEA;

}
#endif