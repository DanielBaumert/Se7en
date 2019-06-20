using Se7en.WinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.Math {
    public unsafe struct NativMatrix<T> where T : unmanaged{
        public readonly int Width;
        public readonly int Height;
        public readonly int Count;
        public readonly int Stride;
        public readonly int SizeOfT;
        public readonly T* Ptr; 


        public T this[int index] {
            get => *(Ptr + index);
            set {
                *(Ptr + index) = value;
            }
        }

        public T this[int x, int y] {
            get => *(Ptr + x + (y * Width));
            set => *(Ptr + x + (y * Width)) = value;
        }

        public NativMatrix(int width, int height) {
            Width = width;
            Height = height;
            SizeOfT = sizeof(T);
            Stride = SizeOfT * Width;
            Count = Stride * Height;
            Ptr = (T*) Kernel32.GlobalAlloc(GlobalAllocFlag.GPTR, Count);
        }

        public NativMatrix(T* source, int width, int height) {
            Width = width;
            Height = height;
            SizeOfT = sizeof(T);
            Stride = SizeOfT * Width;
            Count = Stride * Height;
            Ptr = source;
        }

    }
}
