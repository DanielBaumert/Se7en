#region MIT License

// Copyright (c) 2019 se7en- Daniel Baumert
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

#endregion

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Se7en.Math;
using Se7en.WinApi;

namespace Se7en.Graphic {
    public unsafe struct NativBitmap : IDisposable {
        private readonly byte* _bitmapBuffer;
        private readonly int _pixelCount;
        private readonly int _pixelWidth;
        private readonly int _byteCount;
        private readonly int _stride;

        public int Width { get; }
        public int Height { get; }
        public PixelFormat PixelFormat { get; }

        public NativBitmap(Vector2i size, PixelFormat pixelFormat)
            : this(size.X, size.Y, pixelFormat) { }

        //todo support diffrent pixel sizes
        public NativBitmap(int width, int height, PixelFormat pixelFormat) {
            Width = width;
            Height = height;
            PixelFormat = pixelFormat;
            _pixelWidth = (int)pixelFormat / 8;

            _pixelCount = Width * Height;
            _byteCount = _pixelCount * _pixelWidth;
            _stride = Width * _pixelWidth;

            _bitmapBuffer = (byte*)Kernel32.GlobalAlloc(GlobalAllocFlag.GPTR, _byteCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPixel(Vector2i point, Color color) {
            SetPixel(point.X, point.Y, color);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPixel(int x, int y, Color color)
            => *((int*)_bitmapBuffer + x + (y * Width)) = color.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Color GetPixel(Vector2i point)
            => GetPixel(point.X, point.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Color GetPixel(int x, int y)
            => *((Color*)_bitmapBuffer + x + (y * Width));

        #region Line
        #region Draw

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(Vector2i start, Vector2i end, Color color) 
            => DrawLine(start.X, start.Y, end.X, end.Y, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(int xStart, int yStart, Vector2i end, Color color) 
            => DrawLine(xStart, yStart, end.X, end.Y, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(Vector2i start, int xEnd, int yEnd, Color color) 
            => DrawLine(start.X, start.Y, xEnd, yEnd, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(int x0, int y0, int x1, int y1, Color color) {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            // ReSharper disable CompareOfFloatsByEqualityOperator
            if (dx == 0) {
                for (int y = y0; y != y1; y += sy) {
                    SetPixel(x0, y, color);
                }
            } else if (dy == 0) {
                for (int x = x0; x != x1; x += sx) {
                    SetPixel(x, y0, color);
                }
            } else {
                dx = System.Math.Abs(dx);
                dy = -System.Math.Abs(dy);

                int err = dx + dy;
                while (true) {
                    SetPixel(x0, y0, color);
                    
                    if (x0 == x1 && y0 == y1)
                        break;

                    int e2 = 2 * err;
                    // EITHER horizontal OR vertical step (but not both!)
                    if (e2 > dy) {
                        err += dy;
                        x0 += sx;
                    } else if (e2 < dx) {
                        // <--- this "else" makes the difference
                        err += dx;
                        y0 += sy;
                    }
                }
            }
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }

        #endregion
        #region Fill
        //TODO
        #endregion
        #endregion
        #region Rect
        #region Draw

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRect(Vector2i position, Vector2i size, Color color)
            => DrawRect(position.X, position.Y, size.X, size.Y, color);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRect(Vector2i position, int width, int height, Color color)
            => DrawRect(position.X, position.Y, width, height, color);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRect(int x, int y, Vector2i size, Color color)
            => DrawRect(x, y, size.X, size.Y, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRect(int x, int y, int width, int height, Color color) {
            int x1 = x + width;
            int y1 = y + height;

            DrawLine(x, y, x1, y, color);
            DrawLine(x, y, x, y1, color);
            DrawLine(x1, y1, x1, y, color);
            DrawLine(x1, y1, x, y1, color);
        }

        #endregion
        #region Fill
        //TODO
        #endregion
        #endregion
        #region Cirle
        #region Draw
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawCircle(Vector2i position, int radius, Color color)
            => DrawCircle(position.X, position.Y, radius, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawCircle(int x, int y, int radius, Color color) {
            int f = 1 - radius;
            int ddF_x = 0;
            int ddF_y = -2 * radius;
            int x0 = 0;
            int y0 = radius;

            SetPixel(x, y + radius, color);
            SetPixel(x, y - radius, color);
            SetPixel(x + radius, y, color);
            SetPixel(x - radius, y, color);

            while (x0 < y0) {
                if (f >= 0) {
                    y0--;
                    ddF_y += 2;
                    f += ddF_y;
                }
                x0++;
                ddF_x += 2;
                f += ddF_x + 1;

                int x1 = x + x0;
                int x2 = x - x0;
                int x3 = x + y0;
                int x4 = x - y0;

                int y1 = y + y0;
                int y2 = y - y0;
                int y3 = y + x0;
                int y4 = y - y0;

                SetPixel(x1, y1, color);
                SetPixel(x2, y1, color);
                SetPixel(x1, y2, color);
                SetPixel(x2, y2, color);
                SetPixel(x3, y3, color);
                SetPixel(x4, y3, color);
                SetPixel(x3, y4, color);
                SetPixel(x4, y4, color);
            }
        }

        #endregion
        #endregion
        #region Ellipse
        #region Draw

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawEllipse(Vector2i positionCenter, Vector2i size, Color color)
            => DrawEllipse(positionCenter.X, positionCenter.Y, size.X, size.Y, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawEllipse(Vector2i positionCenter, int width, int height, Color color)
            => DrawEllipse(positionCenter.X, positionCenter.Y, width, height, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawEllipse(int xCenter, int yCenter, Vector2i size, Color color)
            => DrawEllipse(xCenter, yCenter, size.X, size.Y, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawEllipse(int xCenter, int yCenter, int width, int height, Color color) {
            int dx = 0; 
            int dy = height; /* im I. Quadranten von links oben nach rechts unten */
            long a2 = width * width;
            long b2 = height * height;
            long err = b2 - (2 * height - 1) * a2;

            do {
                SetPixel(xCenter + dx, yCenter + dy, color); /* I. Quadrant */
                SetPixel(xCenter - dx, yCenter + dy, color); /* II. Quadrant */
                SetPixel(xCenter - dx, yCenter - dy, color); /* III. Quadrant */
                SetPixel(xCenter + dx, yCenter - dy, color); /* IV. Quadrant */

                long e2 = 2 * err; /* Fehler im 1. Schritt */
                if (e2 < (2 * dx + 1) * b2) {
                    dx++;
                    err += (2 * dx + 1) * b2;
                }
                if (e2 > -(2 * dy - 1) * a2) {
                    dy--;
                    err -= (2 * dy - 1) * a2;
                }
            } while (dy >= 0);

            while (dx++ < width) { /* fehlerhafter Abbruch bei flachen Ellipsen (b=1) */
                SetPixel(xCenter + dx, yCenter, color); /* -> Spitze der Ellipse vollenden */
                SetPixel(xCenter - dx, yCenter, color);
            }
        }

        #endregion
        #region Fill
        //TODO
        #endregion
        #endregion
        #region Fill

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fill(Color color) {
            byte* bitmapBufferProxy = _bitmapBuffer;
            Parallel.For(0, _pixelCount, i => *((int*)bitmapBufferProxy + i) = color.Value);
        }
        
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawToBitmap(Bitmap bitmap) {
            if (bitmap.Width != Width) {
                throw new ArgumentException("Bitmap.Width != Width");
            }
            if (bitmap.Height != Height) {
                throw new ArgumentException("Bitmap.Height != Height");
            }

            if (bitmap.PixelFormat.PixelWidth() != (int)PixelFormat) {
                throw new ArgumentException("Bitmap.PixelWidth != PixelWidth");
            }

            Rectangle bmpRect = new Rectangle(Point.Empty, bitmap.Size);
            BitmapData bmpData = bitmap.LockBits(bmpRect, ImageLockMode.WriteOnly, bitmap.PixelFormat);

            Kernel32.CopyMemory(bmpData.Scan0, (IntPtr)_bitmapBuffer, (uint)_byteCount);

            bitmap.UnlockBits(bmpData);
        }

        public void Dispose() {
            Kernel32.GlobalFree((IntPtr)_bitmapBuffer);
        }
    }
}