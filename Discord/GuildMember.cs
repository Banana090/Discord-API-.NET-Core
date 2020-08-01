using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI
{
    public class GuildMember
    {
        public User User { get; internal set; }
        public string Nick { get; internal set; }
        public string[] Roles { get; internal set; }

        //joined_at : ISO8601 timestamp
        //premium_since? : ISO8601 timestamp

        public bool Deaf { get; internal set; }
        public bool Mute { get; internal set; }

        //Set ONLY when joining guild, triggering GUILD_MEMBER_ADD
        public Guild Guild { get; internal set; }

        internal GuildMember(Guild guild, GuildMemberData data)
        {
            User = new User(data.user);
            Nick = data.nick;
            Roles = data.roles;
            Deaf = data.deaf;
            Mute = data.mute;
            Guild = guild;
        }
    }
}
