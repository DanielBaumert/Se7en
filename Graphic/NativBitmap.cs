using Se7en.Math;
using Se7en.WinApi;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Se7en.Graphic {

    public unsafe struct NativBitmap : IDisposable {
        private byte* _bitmapBuffer;
        private int _pixelCount;
        private int _pixelWidth;
        private int _byteCount;
        private int _stride;

        public int Width { get; }
        public int Height { get; }
        public PixelFormat PixelFormat { get; }

        public NativBitmap(Vector2i size, PixelFormat pixelFormat)
            : this(size.X, size.Y, pixelFormat) {
        }

        public NativBitmap(int width, int height, PixelFormat pixelFormat) {
            Width = width;
            Height = height;
            PixelFormat = pixelFormat;
            _pixelWidth = ((int)pixelFormat) / 8;

            _pixelCount = Width * Height;
            _byteCount = _pixelCount * _pixelWidth;
            _stride = Width * _pixelWidth;

            _bitmapBuffer = (byte*)Kernel32.GlobalAlloc(GlobalAllocFlag.GMEM_FIXED, _byteCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void SetPixel(Vector2i point, Color color)
            => SetPixel(point.X, point.Y, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void SetPixel(int x, int y, Color color) {
            int offset = x + (y * _stride);
            *(int*)(_bitmapBuffer + offset) = color.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe Color GetPixel(Vector2i point)
            => GetPixel(point.X, point.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe Color GetPixel(int x, int y) {
            int offset = x + (y * _stride);
            return *(Color*)(_bitmapBuffer + offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(Vector2i start, Vector2i end, Color color)
            => DrawLine(new StraightLineEquation(start, end), start.X, end.X, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(int xStart, int yStart, int xEnd, int yEnd, Color color)
            => DrawLine(new StraightLineEquation(xStart, yStart, xEnd, yEnd), xStart, xEnd, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(StraightLineEquation line, int xStart, int xEnd, Color color) {
            Action<int, int, Color> setPixelProxy = SetPixel;
            if (xStart == xEnd) {
                SetPixel(xStart, (int)line.GetValue(xStart), color);
            } else {
                if (xStart < xEnd) {
                    Parallel.For(xStart, xEnd, x => setPixelProxy(x, (int)line.GetValue(x), color));
                } else {
                    Parallel.For(xEnd, xStart, x => setPixelProxy(x, (int)line.GetValue(x), color));
                }
            }
        }

        public void Fill(Color color) {
            Action<int, int, Color> setPixelProxy = SetPixel;
            int height = Height;
            int width = Width;
            Parallel.For(0, height, y
                => Parallel.For(0, width, x
                => setPixelProxy(x, y, color)
            ));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawToBitmap(Bitmap bitmap) {
            if (bitmap.Width != Width)
                throw new ArgumentException("Bitmap.Width != Width");
            if (bitmap.Height != Height)
                throw new ArgumentException("Bitmap.Height != Height");

            if (bitmap.PixelFormat.PixelWidth() != (int)PixelFormat)
                throw new ArgumentException("Bitmap.PixelWidth != PixelWidth");

            Rectangle bmpRect = new Rectangle(Point.Empty, bitmap.Size);
            BitmapData bmpData = bitmap.LockBits(bmpRect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            Kernel32.CopyMemory((void*)bmpData.Scan0, _bitmapBuffer, (uint)_byteCount);

            bitmap.UnlockBits(bmpData);
        }

        public void Dispose() => Kernel32.GlobalFree((IntPtr)_bitmapBuffer);
    }
}