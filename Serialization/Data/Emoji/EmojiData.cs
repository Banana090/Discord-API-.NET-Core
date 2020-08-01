using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI.Serialization.Data
{
    internal class EmojiData
    {
        /// <summary>
        /// emoji id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// emoji name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// roles this emoji is whitelisted to
        /// </summary>
        public RoleData[] roles { get; set; }
        /// <summary>
        /// user that created this emoji
        /// </summary>
        public UserData user { get; set; }
        /// <summary>
        /// whether this emoji must be wrapped in colons
        /// </summary>
        public bool require_colons { get; set; }
        /// <summary>
        /// whether this emoji is managed
        /// </summary>
        public bool managed { get; set; }
        /// <summary>
        /// whether this emoji is animated
        /// </summary>
        public bool animated { get; set; }
        /// <summary>
        /// whether this emoji can be used, may be false due to loss of Server Boosts
        /// </summary>
        public bool available { get; set; }
    }
}
