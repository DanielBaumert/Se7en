namespace Se7en.OpenCl
{
    public readonly struct IndexElement<T> where T : unmanaged
    {
        public readonly int Index;
        public readonly T Element;
    
        public IndexElement(int index, T element)
        {
            Index = index;
            Element = element;
        }
    }
}
