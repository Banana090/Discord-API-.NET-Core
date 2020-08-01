using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class GuildPreviewData
    {
        /// <summary>
        /// guild id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// guild name (2-100 characters)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// icon hash
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// splash hash
        /// </summary>
        public string splash { get; set; }
        /// <summary>
        /// 	discovery splash hash
        /// </summary>
        public string discovery_splash { get; set; }
        /// <summary>
        /// 	custom guild emojis
        /// </summary>
        public EmojiData[] emojis { get; set; }
        /// <summary>
        /// 	enabled guild features
        /// </summary>
        public string[] features { get; set; }
        /// <summary>
        /// approximate number of members in this guild
        /// </summary>
        public int approximate_member_count { get; set; }
        /// <summary>
        /// 	approximate number of online members in this guild
        /// </summary>
        public int approximate_presence_count { get; set; }
        /// <summary>
        /// 	the description for the guild
        /// </summary>
        public string description { get; set; }
    }
}
