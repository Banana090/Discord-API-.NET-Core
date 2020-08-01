using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ActivityAssetsData
    {
        /// <summary>
        /// the id for a large asset of the activity, usually a snowflake
        /// </summary>
        public string large_image { get; set; }
        /// <summary>
        /// text displayed when hovering over the large image of the activity
        /// </summary>
        public string large_text { get; set; }
        /// <summary>
        /// the id for a small asset of the activity, usually a snowflake
        /// </summary>
        public string small_image { get; set; }
        /// <summary>
        /// text displayed when hovering over the small image of the activity
        /// </summary>
        public string small_text { get; set; }
    }
}
