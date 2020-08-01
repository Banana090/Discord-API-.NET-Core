using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    [Flags]
    internal enum UserFlags : int
    {
        NONE = 0,
        DISCORD_EMPLOYEE = 1,
        DISCORD_PARTNER = 2,
        HYPESQUAD_EVENTS = 4,
        BUG_HUNTER_LEVEL_1 = 8,
        HOUSE_BRAVERY = 16,
        HOUSE_BRILLIANCE = 32,
        HOUSE_BALANCE = 64,
        EARLY_SUPPORTER = 128,
        TEAM_USER = 256,
        SYSTEM = 512,
        BUG_HUNTER_LEVEL_2 = 1024
    }
}
