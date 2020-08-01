using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class MessageReactionAddData
    {
        /// <summary>
        /// the id of the user
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// the id of the channel
        /// </summary>
        public string channel_id { get; set; }
        /// <summary>
        /// the id of the message
        /// </summary>
        public string message_id { get; set; }
        /// <summary>
        /// the id of the guild
        /// </summary>
        public string guild_id { get; set; }
        /// <summary>
        /// the member who reacted if this happened in a guild
        /// </summary>
        public GuildMemberData member { get; set; }
        /// <summary>
        /// the emoji used to react - example
        /// </summary>
        public EmojiData emoji { get; set; }
    }
}
