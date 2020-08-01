using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ChannelPinsUpdateEventData
    {
        /// <summary>
        /// the id of the guild
        /// </summary>
        public string guild_id { get; set; }
        /// <summary>
        /// the id of the channel
        /// </summary>
        public string channel_id { get; set; }
        /// <summary>
        /// the time at which the most recent pinned message was pinned
        /// </summary>
        public DateTime last_pin_timestamp { get; set; }
    }
}
