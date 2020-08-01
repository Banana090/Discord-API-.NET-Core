using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class MessageApplicationData
    {
        /// <summary>
        /// id of the application
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// id of the embed's image asset
        /// </summary>
        public string cover_image { get; set; }
        /// <summary>
        /// application's description
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// id of the application's icon
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// name of the application
        /// </summary>
        public string name { get; set; }
    }
}
