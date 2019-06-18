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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(Vector2i start, Vector2i end, Color color) {
            DrawLine(start.X, start.Y, end.X, end.Y, color);
        }


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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Fill(Color color) {
            for (int i = 0; i < _pixelCount; i++) {
                *((int*)(_bitmapBuffer) + i) = color.Value;
            }
        }

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