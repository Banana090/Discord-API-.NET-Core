using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data.Guild
{
    internal class GuildBanEventData
    {
        public string guild_id { get; set; }
        public UserData user { get; set; }
    }
}
