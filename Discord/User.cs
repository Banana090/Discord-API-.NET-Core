using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;
using DiscordAPI.Helpers;

namespace DiscordAPI
{
    public class User
    {
        public string Id { get; }
        public string Username { get; }
        public string Discriminator { get; }
        public string AvatarUrl { get; }
        public bool IsBot { get; }
        public bool IsSystem { get; }
        public bool IsMfaEnabled { get; }
        //public string Locale { get; }
        //public bool IsEmailVerified { get; private set; }
        //public string Email { get; private set; }
        //public int Flags { get; private set; }
        public PremiumType PremiumType { get; private set; }

        internal User(UserData userData)
        {
            Id = userData.id;
            Username = userData.username;
            Discriminator = userData.discriminator;
            if (userData.avatar != null) AvatarUrl = CDNHelper.GetUserAvatarUrl(userData.id, userData.avatar);
            else AvatarUrl = CDNHelper.GetDefaultUserAvatarUrl(userData.discriminator);
            IsBot = userData.bot;
            IsSystem = userData.system;
            IsMfaEnabled = userData.mfa_enabled;
            //if (userData.locale != null) Locale = userData.locale;
            //else Locale = "unknown";
            //IsEmailVerified = userData.verified;
            //Email = userData.email;
            //Flags = userData.flags;
            PremiumType = userData.premium_type;
        }
    }
}
