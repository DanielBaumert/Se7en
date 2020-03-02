using System;
using System.Drawing;

namespace Se7en.Graphic
{
    public static class _
    {
        public static int PixelWidth(this System.Drawing.Imaging.PixelFormat pixelFormat)
           => pixelFormat switch
           {
               System.Drawing.Imaging.PixelFormat.Format24bppRgb => 24,
               System.Drawing.Imaging.PixelFormat.Format32bppArgb => 32,
               System.Drawing.Imaging.PixelFormat.Format32bppPArgb => 32,
               System.Drawing.Imaging.PixelFormat.Format32bppRgb => 32,
               _ => throw new NotSupportedException(pixelFormat.ToString())
           };

    }
}
