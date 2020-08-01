using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DiscordAPI.Serialization.Payloads
{
    internal class Payload
    {
        [JsonPropertyName("op")]
        public Opcode opcode { get; set; }
    }

    internal class Payload<T> : Payload
    {
        [JsonPropertyName("d")]
        public T data { get; set; }
    }
}
