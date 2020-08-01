using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class RoleData
    {
        /// <summary>
        /// role id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// role name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// integer representation of hexadecimal color code
        /// </summary>
        public int color { get; set; }
        /// <summary>
        /// if this role is pinned in the user listing
        /// </summary>
        public bool hoist { get; set; }
        /// <summary>
        /// position of this role
        /// </summary>
        public int position { get; set; }
        /// <summary>
        /// permission bit set
        /// </summary>
        public int permissions { get; set; }
        /// <summary>
        /// whether this role is managed by an integration
        /// </summary>
        public bool managed { get; set; }
        /// <summary>
        /// whether this role is mentionable
        /// </summary>
        public bool mentionable { get; set; }
    }
}
