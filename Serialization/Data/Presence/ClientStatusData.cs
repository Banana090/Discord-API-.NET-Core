using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ClientStatusData
    {
        /// <summary>
        /// the user's status set for an active desktop (Windows, Linux, Mac) application session
        /// </summary>
        public string desktop { get; set; }
        /// <summary>
        /// the user's status set for an active mobile (iOS, Android) application session
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// the user's status set for an active web (browser, bot account) application session
        /// </summary>
        public string web { get; set; }
    }
}
