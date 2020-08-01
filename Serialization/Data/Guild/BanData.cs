using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class BanData
    {
        /// <summary>
        /// the reason for the ban
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// the banned user
        /// </summary>
        public UserData user { get; set; }
    }
}
