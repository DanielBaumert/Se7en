using System.Runtime.InteropServices;

namespace Se7en.Mathematic {
    public unsafe struct MemoryMatrix<T> where T : unmanaged {

        private static int _sizeOfT = sizeof(T);

        public readonly T* Ptr;

        public readonly int Width;
        public readonly int Height;
        public readonly int Stride;
        public readonly int Count;

        public T this[int x, int y] {
            get => *(Ptr + x + (y * Stride));
            set => *(Ptr + x + (y * Stride)) = value;
        }
        public T this[int index] {
            get {
                int x = index % Stride;
                int y = index / Stride;
                return *(Ptr + x + (y * Stride));
            }
            set {
                int x = index % Stride;
                int y = index / Stride;
                *(Ptr + x + (y * Stride)) = value;
            }
        }
        public MemoryMatrix(int width, int height)
            : this((T*) Marshal.AllocHGlobal(width * height * _sizeOfT), width, height, width) {
        }
        public MemoryMatrix(T* ptr, int width, int height)
            : this(ptr, width, height, width) {
        }
        public MemoryMatrix(T* ptr, int width, int height, int stride) {
            Ptr = ptr;
            Width = width;
            Height = height;
            Stride = stride;
            Count = Width * Height;
        }

    }
}
