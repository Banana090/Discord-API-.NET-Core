using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Payloads.Data
{
    internal class VoiceIdentifyData
    {
        public string server_id { get; set; }
        public string user_id { get; set; }
        public string session_id { get; set; }
        public string token { get; set; }
    }
}
