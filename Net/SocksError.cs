namespace Se7en.Net {

    public enum SocksError : byte {
        RequestGranted = 0x00,
        GeneralFailure = 0x01,
        ConnectionNotAllowedByRuleset = 0x02,
        NetworkUnreachable = 0x03,
        HostUnreachable = 0x04,
        ConnectionRefusedByDestinationHost = 0x05,
        TtlExpired = 0x06,
        CommandNotSupported = 0x07,
        AddressTypeNotSupported = 0x08
    }
}