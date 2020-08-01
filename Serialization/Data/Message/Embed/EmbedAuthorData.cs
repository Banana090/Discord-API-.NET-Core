using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class EmbedAuthorData
    {
        /// <summary>
        /// name of author
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// url of author
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// url of author icon (only supports http(s) and attachments)
        /// </summary>
        public string icon_url { get; set; }
        /// <summary>
        /// a proxied url of author icon
        /// </summary>
        public string proxy_icon_url { get; set; }
    }
}
