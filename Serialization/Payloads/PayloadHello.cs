using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordAPI.Serialization.Payloads
{
    internal class PayloadHello : Payload
    {
        [JsonPropertyName("d")]
        public HelloData data { get; set; }

        internal class HelloData
        {
            [JsonPropertyName("heartbeat_interval")]
            public int heartbeatInterval { get; set; }
        }
    }
}
