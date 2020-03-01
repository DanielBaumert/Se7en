namespace Se7en.Windows.Api.Enum
{
    public enum HKeyType : int
    {
        CLASSES_ROOT        = unchecked((int)0x80000000),
        CURRENT_USER        = unchecked((int)0x80000001),
        LOCAL_MACHINE       = unchecked((int)0x80000002),
        USERS               = unchecked((int)0x80000003),
        PERFORMANCE_DATA    = unchecked((int)0x80000004),
        CURRENT_CONFIG      = unchecked((int)0x80000005),
        DYN_DATA            = unchecked((int)0x80000006),
    }
}
