using Se7en.Windows.Api.Native;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Se7en
{

    public static class FontLoader {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Font GetFromBytes(byte[] fontData, float emSize, bool gdiVerticalFont)
            => GetFromBytes(fontData, emSize, FontStyle.Regular, GraphicsUnit.Point, 0, gdiVerticalFont);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Font GetFromBytes(byte[] fontData, float emSize, byte gdiCharSet, bool gdiVerticalFont = false)
            => GetFromBytes(fontData, emSize, FontStyle.Regular, GraphicsUnit.Point, gdiCharSet, gdiVerticalFont);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Font GetFromBytes(byte[] fontData, float emSize, GraphicsUnit graphicsUnit, byte gdiCharSet = 0, bool gdiVerticalFont = false)
            => GetFromBytes(fontData, emSize, FontStyle.Regular, graphicsUnit, gdiCharSet, gdiVerticalFont);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Font GetFromBytes(byte[] fontData, float emSize, FontStyle fontStyle = FontStyle.Regular, GraphicsUnit graphicsUnit = GraphicsUnit.Point, byte gdiCharSet = 0, bool gdiVerticalFont = false)
            => GetFont(fontData, emSize, fontStyle, graphicsUnit, gdiCharSet, gdiVerticalFont);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Font GetFont(byte[] fontData, float emSize, FontStyle fontStyle, GraphicsUnit graphicsUnit, byte gdiCharSet, bool gdiVerticalFont) {
            IntPtr unsafeMemoryBlock = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, unsafeMemoryBlock, fontData.Length);
            uint pcFont = 0;
            Gdi32.AddFontMemResourceEx(unsafeMemoryBlock, (uint)fontData.Length, IntPtr.Zero, ref pcFont);
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            privateFonts.AddMemoryFont(unsafeMemoryBlock, fontData.Length);
            Font font = new Font(privateFonts.Families[0], emSize, fontStyle, graphicsUnit, gdiCharSet, gdiVerticalFont);
            privateFonts.Dispose();
            Marshal.FreeCoTaskMem(unsafeMemoryBlock);
            return font;
        }

    }
}
