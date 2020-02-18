namespace Se7en.Network {

    public enum AuthenticationType : byte {
        NoAuthentication = 0x00,
        GSSAPI = 0x1,
        Login = 0x02,
        NoAcceptableMethods = 0xff
    }
}