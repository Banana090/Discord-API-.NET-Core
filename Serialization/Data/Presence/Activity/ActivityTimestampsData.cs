using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ActivityTimestampsData
    {
        /// <summary>
        /// unix time (in milliseconds) of when the activity started
        /// </summary>
        public ulong start { get; set; }
        /// <summary>
        /// unix time (in milliseconds) of when the activity ends
        /// </summary>
        public ulong end { get; set; }
    }
}
