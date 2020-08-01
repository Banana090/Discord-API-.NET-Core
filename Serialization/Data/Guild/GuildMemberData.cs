using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class GuildMemberData
    {
        /// <summary>
        /// the user this guild member represents
        /// </summary>
        public UserData user { get; set; }
        /// <summary>
        /// this users guild nickname (if one is set)
        /// </summary>
        public string nick { get; set; }
        /// <summary>
        /// 	array of role object ids
        /// </summary>
        public string[] roles { get; set; }
        /// <summary>
        /// 	when the user joined the guild
        /// </summary>
        public DateTime? joined_at { get; set; }
        /// <summary>
        /// when the user started boosting the guild
        /// </summary>
        public DateTime? premium_since { get; set; }
        /// <summary>
        /// whether the user is deafened in voice channels
        /// </summary>
        public bool deaf { get; set; }
        /// <summary>
        /// whether the user is muted in voice channels
        /// </summary>
        public bool mute { get; set; }
    }
}
