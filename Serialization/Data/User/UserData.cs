using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class UserData
    {
        /// <summary>
        /// the user's id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// the user's username, not unique across the platform
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// the user's 4-digit discord-tag
        /// </summary>
        public string discriminator { get; set; }
        /// <summary>
        /// the user's avatar hash
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// whether the user belongs to an OAuth2 application
        /// </summary>
        public bool bot { get; set; }
        /// <summary>
        /// whether the user is an Official Discord System user (part of the urgent message system)
        /// </summary>
        public bool system { get; set; }
        /// <summary>
        /// whether the user has two factor enabled on their account
        /// </summary>
        public bool mfa_enabled { get; set; }
        /// <summary>
        /// the user's chosen language option
        /// </summary>
        public string locale { get; set; }
        /// <summary>
        /// whether the email on this account has been verified
        /// </summary>
        public bool verified { get; set; }
        /// <summary>
        /// the user's email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// the flags on a user's account
        /// </summary>
        public int flags { get; set; }
        /// <summary>
        /// the type of Nitro subscription on a user's account
        /// </summary>
        public PremiumType premium_type { get; set; }
    }
}
