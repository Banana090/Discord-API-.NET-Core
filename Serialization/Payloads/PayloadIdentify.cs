using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordAPI.Serialization.Payloads
{
    internal class PayloadIdentify : Payload
    {
        [JsonPropertyName("d")]
        public IdentifyData data { get; set; }

        internal PayloadIdentify(string token)
        {
            opcode = Opcode.IDENTIFY;
            data = new IdentifyData(token);
        }

        internal PayloadIdentify() { }

        internal class IdentifyData
        {
            public string token { get; set; }
            public Properties properties { get; set; }

            public IdentifyData(string token)
            {
                this.token = token;
                properties = new Properties()
                {
                    os = "linux",
                    browser = "Discord.NetCore",
                    device = "Discord.NetCore"
                };
            }

            internal struct Properties
            {
                [JsonPropertyName("$os")]
                public string os { get; set; }
                [JsonPropertyName("$browser")]
                public string browser { get; set; }
                [JsonPropertyName("$device")]
                public string device { get; set; }
            }
        }
    }
}