using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class MessageActivityData
    {
        /// <summary>
        /// type of message activity
        /// </summary>
        public MessageActivityType type { get; set; }
        /// <summary>
        /// party_id from a Rich Presence event
        /// </summary>
        public string party_id { get; set; }
    }
}
