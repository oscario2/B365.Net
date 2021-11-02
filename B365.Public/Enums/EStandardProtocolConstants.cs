namespace B365.Public.Enums
{
    // readit.StandardProtocolConstants
    enum EStandardProtocolConstants
    {
        RecordDelim = '', // 0x1
        FieldDelim = '', // 0x2
        HandshakeMessageDelim = '\u0003',
        MessageDelim = '', // 0xb
        ClientConnect = 0x0,
        ClientPoll = 0x1,
        ClientSend = 0x2,
        ClientConnectFast = 0x3,
        InitialTopicLoad = 0x14,
        Delta = 0x15,
        ClientSubscribe = 0x16,
        ClientUnsubscribe = 0x17,
        ClientSwapSubscriptions = 0x1a,
        NoneEncoding = 0x0,
        EncryptedEncoding = 0x11,
        CompressedEncoding = 0x12,
        Base64Encoding = 0x13,
        ServerPing = 0x18,
        ClientPing = 0x19,
        ClientAbort = 0x1c,
        ClientClose = 0x1d,
        AckItl = 0x1e,
        AckDelta = 0x1f,
        AckResponse = 0x20,

        // custom
        GameDelim = '|',
        ColumnDelim = ';'
    }
}