using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class EmbedVideoData
    {
        /// <summary>
        /// source url of video
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// height of video
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// width of video
        /// </summary>
        public int width { get; set; }
    }
}
