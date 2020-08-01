using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordAPI.Serialization.Payloads
{
    internal class PayloadEvent<T> : Payload
    {
        [JsonPropertyName("t")]
        public string eventName { get; set; }
        [JsonPropertyName("s")]
        public int sequence { get; set; }
        [JsonPropertyName("d")]
        public T data { get; set; }
    }

    internal class PayloadEvent : Payload
    {
        [JsonPropertyName("t")]
        public string eventName { get; set; }
        [JsonPropertyName("s")]
        public int sequence { get; set; }
    }
}
