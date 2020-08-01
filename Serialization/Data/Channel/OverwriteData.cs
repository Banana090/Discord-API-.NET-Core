using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class OverwriteData
    {
        /// <summary>
        /// role or user id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// either "role" or "member"
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// permission bit set
        /// </summary>
        public int allow { get; set; }
        /// <summary>
        /// permission bit set
        /// </summary>
        public int deny { get; set; }
    }
}
