using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class VoiceRegionData
    {
        /// <summary>
        /// unique ID for the region
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// name of the region
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// true if this is a vip-only server
        /// </summary>
        public bool vip { get; set; }
        /// <summary>
        /// true for a single server that is closest to the current user's client
        /// </summary>
        public bool optimal { get; set; }
        /// <summary>
        /// whether this is a deprecated voice region (avoid switching to these)
        /// </summary>
        public bool deprecated { get; set; }
        /// <summary>
        /// whether this is a custom voice region (used for events/etc)
        /// </summary>
        public bool custom { get; set; }
    }
}
