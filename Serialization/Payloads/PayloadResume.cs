using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DiscordAPI.Serialization.Payloads
{
    internal class PayloadResume : Payload
    {
        [JsonPropertyName("d")]
        public ResumeDate data { get; set; }

        internal PayloadResume(string token, string session_id, int seq)
        {
            opcode = Opcode.RESUME;
            data = new ResumeDate(token, session_id, seq);
        }

        internal class ResumeDate
        {
            public string token { get; set; }
            public string session_id { get; set; }
            public int seq { get; set; }

            public ResumeDate(string token, string session_id, int seq)
            {
                this.token = token;
                this.session_id = session_id;
                this.seq = seq;
            }
        }
    }
}
