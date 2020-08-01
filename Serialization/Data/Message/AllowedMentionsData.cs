using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class AllowedMentionsData
    {
        /// <summary>
        /// An array of allowed mention types to parse from the content.
        /// </summary>
        public string[] parse { get; set; }
        /// <summary>
        /// Array of role_ids to mention (Max size of 100)
        /// </summary>
        public string[] roles { get; set; }
        /// <summary>
        /// Array of user_ids to mention (Max size of 100)
        /// </summary>
        public string[] users { get; set; }
    }
}
