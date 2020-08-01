using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Payloads.Data
{
    internal class VoiceStateUpdateData
    {
        public string guild_id { get; set; }
        public string channel_id { get; set; }
        public bool self_mute { get; set; }
        public bool self_deaf { get; set; }
    }
}
