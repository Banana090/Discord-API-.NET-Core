using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI
{
    [Flags]
    public enum MessageFlags : int
    {
        CROSSPOSTED = 1,
        IS_CROSSPOST = 2,
        SUPPRESS_EMBEDS = 4,
        SOURCE_MESSAGE_DELETED = 8,
        URGENT = 16
    }

    public enum MessageActivityType : int
    {
        JOIN = 1,
        SPECTATE = 2,
        LISTEN = 3,
        JOIN_REQUEST = 5
    }

    public enum Opcode : int
    {
        EVENT = 0,
        HEARTBEAT = 1,
        IDENTIFY = 2,
        PRESENCE_UPDATE = 3,
        VOICE_STATE_UPDATE = 4,
        RESUME = 6,
        RECONNECT = 7,
        REQUEST_GUILD_MEMBERS = 8,
        INVALID_SESSION = 9,
        HELLO = 10,
        HEARTBEAT_ACK = 11
    }

    public enum VerificationLevel : int
    {
        NONE = 0,
        LOW = 1,
        MEDIUM = 2,
        HIGH = 3,
        VERY_HIGH = 4
    }

    public enum MessageNotificationsLevel : int
    {
        ALL_MESSAGES = 0,
        ONLY_MENTIONS = 1
    }

    public enum ExplicitContentFilterLevel : int
    {
        DISABLED = 0,
        MEMBERS_WITHOUT_ROLES = 1,
        ALL_MEMBERS = 2
    }

    public enum MFALevel : int
    {
        NONE = 0,
        ELEVATED = 1
    }

    [Flags]
    public enum SystemChannelFlags : int
    {
        SUPPRESS_JOIN_NOTIFICATIONS = 1,
        SUPPRESS_PREMIUM_SUBSCRIPTIONS = 2
    }

    public enum PremiumTier : int
    {
        NONE = 0,
        TIER_1 = 1,
        TIER_2 = 2,
        TIER_3 = 3
    }

    public enum ChannelType : int
    {
        GUILD_TEXT = 0,
        DM = 1,
        GUILD_VOICE = 2,
        GROUP_DM = 3,
        GUILD_CATEGORY = 4,
        GUILD_NEWS = 5,
        GUILD_STORE = 6
    }

    public enum MessageType : int
    {
        DEFAULT = 0,
        RECIPIENT_ADD = 1,
        RECIPIENT_REMOVE = 2,
        CALL = 3,
        CHANNEL_NAME_CHANGE = 4,
        CHANNEL_ICON_CHANGE = 5,
        CHANNEL_PINNED_MESSAGE = 6,
        GUILD_MEMBER_JOIN = 7,
        USER_PREMIUM_GUILD_SUBSCRIPTION = 8,
        USER_PREMIUM_GUILD_SUBSCRIPTION_TIER_1 = 9,
        USER_PREMIUM_GUILD_SUBSCRIPTION_TIER_2 = 10,
        USER_PREMIUM_GUILD_SUBSCRIPTION_TIER_3 = 11,
        CHANNEL_FOLLOW_ADD = 12,
        GUILD_DISCOVERY_DISQUALIFIED = 14,
        GUILD_DISCOVERY_REQUALIFIED = 15
    }

    public enum PremiumType : int
    {
        NONE = 0,
        NITRO_CLASSIC = 1,
        NITRO = 2
    }
}
