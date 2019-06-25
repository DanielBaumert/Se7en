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
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Se7en.Exceptions;
using Se7en.Mathematic;
using Se7en.WinApi;

namespace Se7en.Graphic {
    public unsafe struct NativBitmap : IDisposable {
        private readonly byte* _bitmapBuffer;
        private readonly int _pixelCount;
        private readonly int _pixelWidth;
        private readonly int _byteCount;
        private readonly int _stride;
        private Bitmap? _bitmap;
        private bool _isStartetdPaint;
        public bool Aliasing { get; set; }
        public int Width { get; }
        public int Height { get; }
        public PixelFormat PixelFormat { get; }
        public Bitmap Bitmap {
            get => _bitmap;
            private set {
                if (_bitmap != value) {
                    if (value.Width != Width) {
                        throw new ArgumentException("Bitmap.Width != Width");
                    }
                    if (value.Height != Height) {
                        throw new ArgumentException("Bitmap.Height != Height");
                    }

                    if (value.PixelFormat.PixelWidth() != (int)PixelFormat) {
                        throw new ArgumentException("Bitmap.PixelWidth != PixelWidth");
                    }

                    Interlocked.Exchange(ref _bitmap, value)?.Dispose();
                } 
            }
        }
        public NativBitmap(Vector2i size, PixelFormat pixelFormat)
            : this(size.X, size.Y, pixelFormat) { }

        //todo support diffrent pixel sizes
        public NativBitmap(int width, int height, PixelFormat pixelFormat, bool aliasing = false) {
            Width = width;
            Height = height;
            PixelFormat = pixelFormat;
            Aliasing = aliasing;
            _bitmap = null;

            _isStartetdPaint = false;
            _pixelWidth = (int)pixelFormat / 8;
            _pixelCount = Width * Height;
            _byteCount = _pixelCount * _pixelWidth;
            _stride = Width * _pixelWidth;

            _bitmapBuffer = (byte*)Kernel32.GlobalAlloc(GlobalAllocFlag.GPTR, _byteCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private System.Drawing.Imaging.PixelFormat ConvertToSysPixelFormat(PixelFormat pixelFormat)
                => pixelFormat switch {
                    PixelFormat.Bit32 => System.Drawing.Imaging.PixelFormat.Format32bppArgb,
                    _ => throw new NotSupportedException()
                };
   

        public void Beginn(Bitmap bmp = null) {
            if (bmp != null)
                _bitmap = bmp;
            else if (_bitmap == null)
                _bitmap = new Bitmap(Width, Height, ConvertToSysPixelFormat(PixelFormat));

            
            

            _isStartetdPaint = true;
        }

        public void End() {
            _isStartetdPaint = false;
        }

        //MultiSupport
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPixel(Vector2i point, Color color, float brightness)
            => SetPixel(point.X, point.Y, color, brightness);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPixel(int x, int y, Color color, float brightness) {
            color.A = (byte)(brightness * 255);
            SetPixel(x, y, color);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPixel(Vector2i point, Color color)
        => SetPixel(point.X, point.Y, color);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetPixel(int x, int y, Color color) {
            if (!_isStartetdPaint)
                throw new LockedBitmapException("Bevor you can use a draw method pleas user .Beginn() at first");

            if (x < 0 || Width <= x || y < 0 || Height <= y)
                 return;

            *((int*)_bitmapBuffer + x + (y * Width)) = color.Value;
        }
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
            int dx = x1 - x0,
                dy = y1 - y0;
            int sx = x0 < x1 ? 1 : -1,
                sy = y0 < y1 ? 1 : -1;

            // ReSharper disable CompareOfFloatsByEqualityOperator

            if (dx == 0) {
                for (int y = y0; y != y1; y += sy) {
                    SetPixel(x0, y, color);
                }
            } else if (dy == 0) {
                for (int x = x0; x != x1; x += sx) {
                    SetPixel(x, y0, color);
                }
            } else if (Aliasing) {
                bool steep = dy.Abs() > dx.Abs();

                if (steep) {
                    Swap(ref x0, ref y0);
                    Swap(ref x1, ref y1);
                }
                if (x0 > x1) {
                    Swap(ref x0, ref x1);
                    Swap(ref y0, ref y1);
                }

                int gradient = dy / dx;


                int xend = Round(x0);
                float yend = y0 + gradient * (xend - x0);
                float xgap = RFPart(x0 + 0.5f);
                int xpxl1 = xend,
                    ypxl1 = IPart(yend);

                if (steep) {
                    SetPixel(ypxl1, xpxl1, color, RFPart(yend) * xgap);
                    SetPixel(ypxl1 + 1, xpxl1, color, FPart(yend) * xgap);
                } else {
                    SetPixel(xpxl1, ypxl1, color, RFPart(yend) * xgap);
                    SetPixel(xpxl1, ypxl1 + 1, color, FPart(yend) * xgap);
                }

                float intery = yend + gradient;

                xend = Round(x1);
                yend = y1 + gradient * (xend + x1);
                xgap = FPart(x1 + 0.5f);
                int xpxl2 = xend,
                    ypxl2 = IPart(yend);

                if (steep) {
                    SetPixel(ypxl2, xpxl2, color, RFPart(yend) * xgap);
                    SetPixel(ypxl2 + 1, xpxl2, color, FPart(yend) * xgap);
                } else {
                    SetPixel(xpxl2, ypxl2, color, RFPart(yend) * xgap);
                    SetPixel(xpxl2, ypxl2 + 1, color, FPart(yend) * xgap);
                }

                if (steep) {
                    for (int x = xpxl1 + 1; x < xpxl2; x++) {
                        SetPixel((int)intery, x, color, RFPart(intery));
                        SetPixel((int)intery + 1, x, color, FPart(intery));
                        intery += gradient;
                    }
                } else {
                    for (int x = xpxl2; x < xpxl2; x++) {
                        SetPixel(x, (int)intery, color, RFPart(intery));
                        SetPixel(x, (int)intery + 1, color, FPart(intery));
                        intery += gradient;
                    }
                }
            } else {  // dx = 0
                dx = System.Math.Abs(dx);
                dy = -System.Math.Abs(dy);

                int err = dx + dy;
                while (true) {
                    SetPixel(x0, y0, color);

                    if (x0 == x1 && y0 == y1)
                        break;

                    int e2 = err << 1;
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
        }
        // ReSharper restore CompareOfFloatsByEqualityOperator
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Swap(ref int a, ref int b) {
            int tmp = a;
            a = b;
            b = tmp;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int IPart(float d)
            => (int)d;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int Round(float d)
            => (int)(d + 0.50000);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float FPart(float x)
             => (float)(x - (int)x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float RFPart(float x)
            => 1f - (float)(x - (int)x);

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
            int xLocal = 0;
            int yLocal = radius;

            SetPixel(x, y + radius, color);
            SetPixel(x, y - radius, color);
            SetPixel(x + radius, y, color);
            SetPixel(x - radius, y, color);

            while (xLocal < yLocal) {
                if (f >= 0) {
                    yLocal--;
                    ddF_y += 2;
                    f += ddF_y;
                }
                xLocal++;
                ddF_x += 2;
                f += ddF_x + 1;

                int x1 = x + xLocal,
                    x2 = x - xLocal,
                    x3 = x + yLocal,
                    x4 = x - yLocal;

                int y1 = y + yLocal,
                    y2 = y - yLocal,
                    y3 = y + xLocal,
                    y4 = y - xLocal;

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