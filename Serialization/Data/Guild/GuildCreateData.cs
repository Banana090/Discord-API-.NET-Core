using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class GuildCreateData : GuildData
    {
        /// <summary>
        /// 	when this guild was joined at
        /// </summary>
        public DateTime? joined_at { get; set; }
        /// <summary>
        /// 	whether this is considered a large guild
        /// </summary>
        public bool large { get; set; }
        /// <summary>
        /// whether this guild is unavailable
        /// </summary>
        public bool unavailable { get; set; }
        /// <summary>
        /// total number of members in this guild
        /// </summary>
        public int member_count { get; set; }
        /// <summary>
        /// 	(without the guild_id key)
        /// </summary>
        public VoiceStateData[] voice_states { get; set; }
        /// <summary>
        /// users in the guild
        /// </summary>
        public GuildMemberData[] members { get; set; }
        /// <summary>
        /// channels in the guild
        /// </summary>
        public ChannelData[] channels { get; set; }
        /// <summary>
        /// presences of the users in the guild
        /// </summary>
        public PresenceUpdateData[] presences { get; set; }
    }
}
