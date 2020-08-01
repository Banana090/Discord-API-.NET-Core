using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ActivityPartyData
    {
        /// <summary>
        /// the id of the party
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// array of two integers (current_size, max_size)	
        /// used to show the party's current and maximum size
        /// </summary>
        public int[] size { get; set; }
    }
}
