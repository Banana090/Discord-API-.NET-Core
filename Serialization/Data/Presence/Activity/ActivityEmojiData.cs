using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ActivityEmojiData
    {
        /// <summary>
        /// the name of the emoji
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// the id of the emoji
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// whether this emoji is animated
        /// </summary>
        public bool animated { get; set; }
    }
}
