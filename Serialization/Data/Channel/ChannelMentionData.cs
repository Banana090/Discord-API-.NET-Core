using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ChannelMentionData
    {
        /// <summary>
        /// id of the channel
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// id of the guild containing the channel
        /// </summary>
        public string guild_id { get; set; }
        /// <summary>
        /// the type of channel
        /// </summary>
        public ChannelType type { get; set; }
        /// <summary>
        /// the name of the channel
        /// </summary>
        public string name { get; set; }
    }
}
