using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DiscordAPI.Serialization.Payloads
{
    internal class PayloadHeartbeat : Payload
    {
        [JsonPropertyName("d")]
        public int sequence { get; set; }

        public PayloadHeartbeat(int sequence)
        {
            opcode = Opcode.HEARTBEAT;
            this.sequence = sequence;
        }

        internal PayloadHeartbeat() { }
    }
}
