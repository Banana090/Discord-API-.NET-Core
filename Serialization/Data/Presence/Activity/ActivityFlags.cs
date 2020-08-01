using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    [Flags]
    public enum ActivityFlags : int
    {
        INSTANCE = 1,
        JOIN = 2,
        SPECTATE = 4,
        JOIN_REQUEST = 8,
        SYNC = 16,
        PLAY = 32
    }
}
