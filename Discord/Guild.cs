using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using DiscordAPI.Helpers;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI
{
    public class Guild
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string IconUrl { get; internal set; }
        public string SplashUrl { get; internal set; }
        public string DiscoverySplashUrl { get; internal set; }
        public string Owner_Id { get; internal set; }
        public int permissions { get; internal set; }
        public string VoiceRegion { get; internal set; }
        public string afk_channel_id { get; internal set; }
        public int AFKTimeout { get; internal set; }
        public VerificationLevel VerificationLevel { get; internal set; }
        public MessageNotificationsLevel DefaultMessageNotification { get; internal set; }
        public ExplicitContentFilterLevel ExplicitContentFilter { get; internal set; }
        public Role[] roles { get; internal set; }
        public CustomEmoji[] emojis { get; internal set; }
        public string[] features { get; internal set; }
        public MFALevel mfa_level { get; internal set; }
        public string application_id { get; internal set; }
        public bool widget_enabled { get; internal set; }
        public string widget_channel_id { get; internal set; }
        public string system_channel_id { get; internal set; }
        public int system_channel_flags { get; internal set; }
        public string rules_channel_id { get; internal set; }
        //public DateTime joined_at { get; set; }
        public bool large { get; internal set; }
        public bool unavailable { get; internal set; }
        public int member_count { get; internal set; }
        //public VoiceState[] voice_states { get; internal set; }
        public List<GuildMember> members { get; internal set; }
        //public Channel[] channels { get; set; }
        // presences { get; set; }
        public int max_members { get; internal set; }
        public string vanity_url_code { get; internal set; }
        public string description { get; internal set; }
        public string bannerUrl { get; internal set; }
        public PremiumTier premium_tier { get; internal set; }
        public int premium_subscription_count { get; internal set; }
        public string preferred_locale { get; internal set; }
        public string public_updates_channel_id { get; internal set; }

        internal Guild(GuildCreateData data)
        {
            Id = data.id;
            Name = data.name;
            IconUrl = CDNHelper.GetGuildIconUrl(Id, data.icon);
            SplashUrl = CDNHelper.GetGuildSplashUrl(Id, data.splash);
            DiscoverySplashUrl = CDNHelper.GetGuildDiscoverySplashUrl(Id, data.discovery_splash);
            VoiceRegion = data.region;
            AFKTimeout = data.afk_timeout;
            VerificationLevel = data.verification_level;
            DefaultMessageNotification = data.default_message_notifications;
            ExplicitContentFilter = data.explicit_content_filter;
            features = data.features;
            mfa_level = data.mfa_level;
            application_id = data.application_id;
            widget_enabled = data.widget_enabled;
            widget_channel_id = data.widget_channel_id;
            system_channel_id = data.system_channel_id;
            system_channel_flags = data.system_channel_flags;
            rules_channel_id = data.rules_channel_id;
            large = data.large;
            unavailable = data.unavailable;
            member_count = data.member_count;
            max_members = data.max_members;
            vanity_url_code = data.vanity_url_code;
            description = data.description;
            bannerUrl = CDNHelper.GetGuildBannerUrl(Id, data.banner);
            premium_tier = data.premium_tier;
            premium_subscription_count = data.premium_subscription_count;
            preferred_locale = data.preferred_locale;
            public_updates_channel_id = data.public_updates_channel_id;
            Owner_Id = data.owner_id;
            permissions = data.permissions;
            afk_channel_id = data.afk_channel_id;

            roles = new Role[data.roles.Length];
            for (int i = 0; i < roles.Length; i++)
                roles[i] = new Role(data.roles[i]);

            emojis = new CustomEmoji[data.emojis.Length];
            for (int i = 0; i < emojis.Length; i++)
                emojis[i] = new CustomEmoji(data.emojis[i]);

            members = new List<GuildMember>();
            for (int i = 0; i < data.members.Length; i++)
                members.Add(new GuildMember(this, data.members[i]));
        }

        internal void Update(GuildData data)
        {
            Id = data.id;
            Name = data.name;
            IconUrl = CDNHelper.GetGuildIconUrl(Id, data.icon);
            SplashUrl = CDNHelper.GetGuildSplashUrl(Id, data.splash);
            DiscoverySplashUrl = CDNHelper.GetGuildDiscoverySplashUrl(Id, data.discovery_splash);
            VoiceRegion = data.region;
            AFKTimeout = data.afk_timeout;
            VerificationLevel = data.verification_level;
            DefaultMessageNotification = data.default_message_notifications;
            ExplicitContentFilter = data.explicit_content_filter;
            features = data.features;
            mfa_level = data.mfa_level;
            application_id = data.application_id;
            widget_enabled = data.widget_enabled;
            widget_channel_id = data.widget_channel_id;
            system_channel_id = data.system_channel_id;
            system_channel_flags = data.system_channel_flags;
            rules_channel_id = data.rules_channel_id;
            max_members = data.max_members;
            vanity_url_code = data.vanity_url_code;
            description = data.description;
            bannerUrl = CDNHelper.GetGuildBannerUrl(Id, data.banner);
            premium_tier = data.premium_tier;
            premium_subscription_count = data.premium_subscription_count;
            preferred_locale = data.preferred_locale;
            public_updates_channel_id = data.public_updates_channel_id;
            Owner_Id = data.owner_id;
            permissions = data.permissions;
            afk_channel_id = data.afk_channel_id;

            roles = new Role[data.roles.Length];
            for (int i = 0; i < roles.Length; i++)
                roles[i] = new Role(data.roles[i]);

            emojis = new CustomEmoji[data.emojis.Length];
            for (int i = 0; i < emojis.Length; i++)
                emojis[i] = new CustomEmoji(data.emojis[i]);
        }

        internal void AddMember(GuildMember member)
        {
            members.Add(member);
        }

        internal GuildMember RemoveMember(string id)
        {
            GuildMember member = members.First(x => x.User.Id == id);
            if (member != null)
                members.Remove(member);
            return member;
        }
    }
}
