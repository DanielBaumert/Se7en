using Se7en.Math;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Se7en.Graphic {
    public unsafe struct NativBitmap : IDisposable{
        private byte* _bitmapBuffer;
        private int _pixelCount;
        private int _byteCount;
        private int _stride;

        public int Width { get; }
        public int Height { get; }
        public PixelFormat PixelFormat { get; }
        public NativBitmap(int width, int height, PixelFormat pixelFormat) {
            Width = width;
            Height = height;
            PixelFormat = pixelFormat;

            _pixelCount = Width * Height;
            _byteCount = _pixelCount * (int)PixelFormat;
            _stride = Width * (int)PixelFormat;

            _bitmapBuffer = (byte*)Marshal.AllocHGlobal(_byteCount);
        }

        public NativBitmap(Vector2i size, PixelFormat pixelFormat) {
            Width = size.X;
            Height = size.Y;
            PixelFormat = pixelFormat;

            _pixelCount = Width * Height;
            _byteCount = _pixelCount * (int)PixelFormat;
            _stride = Width * (int)PixelFormat;

            _bitmapBuffer = (byte*)Marshal.AllocHGlobal(_byteCount);
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
        public unsafe void DrawLine(StraightLineEquation line, int xStart, int xEnd, Color color) {
            Action<int, int, Color> setPixelProxy = SetPixel;
            Parallel.For(xStart, xEnd, x => setPixelProxy(x, (int)line.GetValue(x), color));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawToBitmap(ref Bitmap bitmap) {
            if (bitmap.Width != Width)
                throw new ArgumentException("Bitmap.Width != Width");
            if (bitmap.Height != Height)
                throw new ArgumentException("Bitmap.Height != Height");

            if (bitmap.PixelFormat.PixelWidth() != (int) PixelFormat)
                throw new ArgumentException("Bitmap.PixelWidth != PixelWidth");

            Rectangle bmpRect = new Rectangle(Point.Empty, bitmap.Size);
            BitmapData bmpData = bitmap.LockBits(bmpRect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            Buffer.MemoryCopy(_bitmapBuffer, (void*)bmpData.Scan0, _byteCount, _byteCount);

            bitmap.UnlockBits(bmpData);
        }

        public void Dispose() => Marshal.FreeHGlobal((IntPtr)_bitmapBuffer);
    }
}
