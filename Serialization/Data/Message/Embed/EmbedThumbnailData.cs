using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class EmbedThumbnailData
    {
        /// <summary>
        /// source url of thumbnail (only supports http(s) and attachments)
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// a proxied url of the thumbnail
        /// </summary>
        public string proxy_url { get; set; }
        /// <summary>
        /// height of thumbnail
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// width of thumbnail
        /// </summary>
        public int width { get; set; }
    }
}
