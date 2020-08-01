using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class EmbedFooterData
    {
        /// <summary>
        /// footer text
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// url of footer icon (only supports http(s) and attachments)
        /// </summary>
        public string icon_url { get; set; }
        /// <summary>
        /// a proxied url of footer icon
        /// </summary>
        public string proxy_icon_url { get; set; }
    }
}
