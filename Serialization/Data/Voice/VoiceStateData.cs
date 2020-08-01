using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class VoiceStateData
    {
        /// <summary>
        /// the guild id this voice state is for
        /// </summary>
        public string guild_id { get; set; }
        /// <summary>
        /// the channel id this user is connected to
        /// </summary>
        public string channel_id { get; set; }
        /// <summary>
        /// the user id this voice state is for
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// the guild member this voice state is for
        /// </summary>
        public GuildMemberData member { get; set; }
        /// <summary>
        /// the session id for this voice state
        /// </summary>
        public string session_id { get; set; }
        /// <summary>
        /// whether this user is deafened by the server
        /// </summary>
        public bool deaf { get; set; }
        /// <summary>
        /// whether this user is muted by the server
        /// </summary>
        public bool mute { get; set; }
        /// <summary>
        /// whether this user is locally deafened
        /// </summary>
        public bool self_deaf { get; set; }
        /// <summary>
        /// whether this user is locally muted
        /// </summary>
        public bool self_mute { get; set; }
        /// <summary>
        /// whether this user is streaming using "Go Live"
        /// </summary>
        public bool self_stream { get; set; }
        /// <summary>
        /// whether this user is muted by the current user
        /// </summary>
        public bool suppress { get; set; }
    }
}
