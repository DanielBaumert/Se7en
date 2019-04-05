namespace Se7en
{

    public delegate void Action<T1>(T1 arg1);
    public delegate void Action<T1, T2>(T1 arg1, T2 arg2);
    public delegate void Action<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
    public delegate void Action<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg);

    public unsafe delegate void UnsafeAction<T1>(T1* arg1) where T1 : unmanaged;
    public unsafe delegate void UnsafeAction<T1, T2>(T1* arg1, T2 arg2) where T1 : unmanaged;
    public unsafe delegate void UnsafeAction<T1, T2, T3>(T1* arg1, T2 arg2, T3 arg3) where T1 : unmanaged;
    public unsafe delegate void UnsafeAction<T1, T2, T3, T4>(T1* arg1, T2 arg2, T3 arg3, T4 arg) where T1 : unmanaged;


    public delegate TOut Func<T1, TOut>(T1 arg1);
    public delegate TOut Func<T1, T2, TOut>(T1 arg1, T2 arg2);
    public delegate TOut Func<T1, T2, T3, TOut>(T1 arg1, T2 arg2, T3 arg3);
    public delegate TOut Func<T1, T2, T3, T4, TOut>(T1 arg1, T2 arg2, T3 arg3, T4 arg);

    public unsafe delegate TOut UnsafeFunc<T1, TOut>(T1* arg1) where T1 : unmanaged;
    public unsafe delegate TOut UnsafeFunc<T1, T2, TOut>(T1* arg1, T2 arg2) where T1 : unmanaged;
    public unsafe delegate TOut UnsafeFunc<T1, T2, T3, TOut>(T1* arg1, T2 arg2, T3 arg3) where T1 : unmanaged;
    public unsafe delegate TOut UnsafeFunc<T1, T2, T3, T4, TOut>(T1* arg1, T2 arg2, T3 arg3, T4 arg) where T1 : unmanaged;

    public static class Utils
    {
    }
}
