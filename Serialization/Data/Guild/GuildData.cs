using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class GuildData
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
        ///	icon hash
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// splash hash
        /// </summary>
        public string splash { get; set; }
        /// <summary>
        /// discovery splash hash
        /// </summary>
        public string discovery_splash { get; set; }
        /// <summary>
        /// whether or not the user is the owner of the guild
        /// </summary>
        public bool owner { get; set; }
        /// <summary>
        /// id of owner
        /// </summary>
        public string owner_id { get; set; }
        /// <summary>
        /// total permissions for the user in the guild (does not include channel overrides)
        /// </summary>
        public int permissions { get; set; }
        /// <summary>
        /// voice region id for the guild
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// id of afk channel
        /// </summary>
        public string afk_channel_id { get; set; }
        /// <summary>
        /// afk timeout in seconds
        /// </summary>
        public int afk_timeout { get; set; }
        /// <summary>
        /// whether this guild is embeddable (e.g. widget)
        /// </summary>
        public bool embed_enabled { get; set; }
        /// <summary>
        /// if not null, the channel id that the widget will generate an invite to
        /// </summary>
        public string embed_channel_id { get; set; }
        /// <summary>
        /// verification level required for the guild
        /// </summary>
        public VerificationLevel verification_level { get; set; }
        /// <summary>
        /// default message notifications level
        /// </summary>
        public MessageNotificationsLevel default_message_notifications { get; set; }
        /// <summary>
        /// explicit content filter level
        /// </summary>
        public ExplicitContentFilterLevel explicit_content_filter { get; set; }
        /// <summary>
        /// roles in the guild
        /// </summary>
        public RoleData[] roles { get; set; }
        /// <summary>
        /// custom guild emojis
        /// </summary>
        public EmojiData[] emojis { get; set; }
        /// <summary>
        /// enabled guild features
        /// </summary>
        public string[] features { get; set; }
        /// <summary>
        /// required MFA level for the guild
        /// </summary>
        public MFALevel mfa_level { get; set; }
        /// <summary>
        /// application id of the guild creator if it is bot-created
        /// </summary>
        public string application_id { get; set; }
        /// <summary>
        /// whether or not the server widget is enabled
        /// </summary>
        public bool widget_enabled { get; set; }
        /// <summary>
        /// the channel id for the server widget
        /// </summary>
        public string widget_channel_id { get; set; }
        /// <summary>
        /// the id of the channel where guild notices such as welcome messages and boost events are posted
        /// </summary>
        public string system_channel_id { get; set; }
        /// <summary>
        /// system channel flags
        /// </summary>
        public int system_channel_flags { get; set; }
        /// <summary>
        /// the id of the channel where "PUBLIC" guilds display rules and/or guidelines
        /// </summary>
        public string rules_channel_id { get; set; }
        /// <summary>
        /// 	the maximum amount of presences for the guild (the default value, currently 25000, is in effect when null is returned)
        /// </summary>
        public int? max_presences { get; set; }
        /// <summary>
        /// the maximum amount of members for the guild
        /// </summary>
        public int max_members { get; set; }
        /// <summary>
        /// the vanity url code for the guild
        /// </summary>
        public string vanity_url_code { get; set; }
        /// <summary>
        /// the description for the guild
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// banner hash
        /// </summary>
        public string banner { get; set; }
        /// <summary>
        /// premium tier (Server Boost level)
        /// </summary>
        public PremiumTier premium_tier { get; set; }
        /// <summary>
        /// 	the number of boosts this server currently has
        /// </summary>
        public int premium_subscription_count { get; set; }
        /// <summary>
        /// the preferred locale of a "PUBLIC" guild used in server discovery and notices from Discord; defaults to "en-US"
        /// </summary>
        public string preferred_locale { get; set; }
        /// <summary>
        /// the id of the channel where admins and moderators of "PUBLIC" guilds receive notices from Discord
        /// </summary>
        public string public_updates_channel_id { get; set; }
    }
}
