using System.Runtime.InteropServices;

namespace Se7en.AI
{
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct Connector
    {
        [FieldOffset(0)]
        public int Left;
        [FieldOffset(4)]
        public int Right;
        [FieldOffset(8)]
        public int ConnectionIndex;

        public Connector(int left, int right, int connectionIndex)
        {
            Left = left;
            Right = right;
            ConnectionIndex = connectionIndex;
        }
    }
}
