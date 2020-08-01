using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ChannelData
    {
        /// <summary>
        /// the id of this channel
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// the type of channel
        /// </summary>
        public ChannelType type { get; set; }
        /// <summary>
        /// the id of the guild
        /// </summary>
        public string guild_id { get; set; }
        /// <summary>
        /// sorting position of the channel
        /// </summary>
        public int position { get; set; }
        /// <summary>
        /// explicit permission overwrites for members and roles
        /// </summary>
        public OverwriteData[] permission_overwrites { get; set; }
        /// <summary>
        /// the name of the channel (2-100 characters)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// the channel topic (0-1024 characters)
        /// </summary>
        public string topic { get; set; }
        /// <summary>
        /// whether the channel is nsfw
        /// </summary>
        public bool nsfw { get; set; }
        /// <summary>
        /// the id of the last message sent in this channel (may not point to an existing or valid message)
        /// </summary>
        public string last_message_id { get; set; }
        /// <summary>
        /// the bitrate (in bits) of the voice channel
        /// </summary>
        public int bitrate { get; set; }
        /// <summary>
        /// the user limit of the voice channel
        /// </summary>
        public int user_limit { get; set; }
        /// <summary>
        /// amount of seconds a user has to wait before sending another message (0-21600); bots, as well as users with the permission manage_messages or manage_channel, are unaffected
        /// </summary>
        public int rate_limit_per_user { get; set; }
        /// <summary>
        /// the recipients of the DM
        /// </summary>
        public UserData[] recipients { get; set; }
        /// <summary>
        /// icon hash
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// id of the DM creator
        /// </summary>
        public string owner_id { get; set; }
        /// <summary>
        /// application id of the group DM creator if it is bot-created
        /// </summary>
        public string application_id { get; set; }
        /// <summary>
        /// id of the parent category for a channel (each parent category can contain up to 50 channels)
        /// </summary>
        public string parent_id { get; set; }
        /// <summary>
        /// when the last pinned message was pinned
        /// </summary>
        public DateTime? last_pin_timestamp { get; set; }
    }
}
