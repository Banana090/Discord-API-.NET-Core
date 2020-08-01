using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ReactionData
    {
        /// <summary>
        /// times this emoji has been used to react
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// whether the current user reacted using this emoji
        /// </summary>
        public bool me { get; set; }
        /// <summary>
        /// emoji information
        /// </summary>
        public EmojiData emoji { get; set; }
    }
}
