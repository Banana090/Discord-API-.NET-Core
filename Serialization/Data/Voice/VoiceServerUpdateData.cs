using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data.Voice
{
    internal class VoiceServerUpdateData
    {
        public string token { get; set; }
        public string guild_id { get; set; }
        public string endpoint { get; set; }
    }
}
