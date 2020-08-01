using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class AttachmentData
    {
        /// <summary>
        /// attachment id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// name of file attached
        /// </summary>
        public string filename { get; set; }
        /// <summary>
        /// size of file in bytes
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// source url of file
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// a proxied url of file
        /// </summary>
        public string proxy_url { get; set; }
        /// <summary>
        /// height of file (if image)
        /// </summary>
        public int? height { get; set; }
        /// <summary>
        /// width of file (if image)
        /// </summary>
        public int? width { get; set; }
    }
}
