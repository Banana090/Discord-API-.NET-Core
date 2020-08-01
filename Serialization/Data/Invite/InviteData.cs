using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class InviteData
    {
        /// <summary>
        /// the invite code (unique ID)
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// the guild this invite is for
        /// </summary>
        public GuildData guild { get; set; }
        /// <summary>
        /// the channel this invite is for
        /// </summary>
        public ChannelData channel { get; set; }
        /// <summary>
        /// the user who created the invite
        /// </summary>
        public UserData inviter { get; set; }
        /// <summary>
        /// the target user for this invite
        /// </summary>
        public UserData target_user { get; set; }
        /// <summary>
        /// the type of target user for this invite
        /// </summary>
        public TargetUserType target_user_type { get; set; }
        /// <summary>
        /// approximate count of online members (only present when target_user is set)
        /// </summary>
        public int approximate_presence_count { get; set; }
        /// <summary>
        /// approximate count of total members
        /// </summary>
        public int approximate_member_count { get; set; }
    }
}
