using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data.Guild
{
    internal class GuildEmojisUpdateEventData
    {
        public string guild_id { get; set; }
        public EmojiData[] emojis { get; set; }
    }
}
