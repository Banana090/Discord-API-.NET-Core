using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI
{
    public class Role
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public Color Color { get; internal set; }
        /// <summary>
        /// if this role is pinned in the user listing
        /// </summary>
        public bool Hoist { get; internal set; }
        public int Position { get; internal set; }
        public int Permissions { get; internal set; }
        /// <summary>
        /// whether this role is managed by an integration
        /// </summary>
        public bool Managed { get; internal set; }
        public bool Mentionable { get; internal set; }

        internal Role(RoleData data)
        {
            Id = data.id;
            Name = data.name;
            Color = new Color(data.color);
            Hoist = data.hoist;
            Position = data.position;
            Permissions = data.permissions;
            Managed = data.managed;
            Mentionable = data.mentionable;
        }
    }
}
