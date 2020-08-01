using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class GuildEmbedData
    {
        /// <summary>
        /// whether the embed is enabled
        /// </summary>
        public bool enabled { get; set; }
        /// <summary>
        /// the embed channel id
        /// </summary>
        public string channel_id { get; set; }
    }
}
