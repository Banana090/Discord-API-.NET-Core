using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class EmbedImageData
    {
        /// <summary>
        /// source url of image (only supports http(s) and attachments)
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// a proxied url of the image
        /// </summary>
        public string proxy_url { get; set; }
        /// <summary>
        /// height of image
        /// </summary>
        public string height { get; set; }
        /// <summary>
        /// width of image
        /// </summary>
        public string width { get; set; }
    }
}
