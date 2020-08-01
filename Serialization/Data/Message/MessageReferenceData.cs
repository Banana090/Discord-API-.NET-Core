using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class MessageReferenceData
    {
        /// <summary>
        /// id of the originating message
        /// </summary>
        public string message_id { get; set; }
        /// <summary>
        /// id of the originating message's channel
        /// </summary>
        public string channel_id { get; set; }
        /// <summary>
        /// id of the originating message's guild
        /// </summary>
        public string guild_id { get; set; }
    }
}
