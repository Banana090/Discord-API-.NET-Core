using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class EmbedData
    {
        /// <summary>
        /// title of embed
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// type of embed (always "rich" for webhook embeds)
        /// <para>Embed types are "loosely defined" and, for the most part, are not used by our clients for rendering.
        /// Embed attributes power what is rendered.
        /// Embed types should be considered deprecated and might be removed in a future API version.
        /// </para>
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// description of embed
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// url of embed
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// timestamp of embed content
        /// </summary>
        public DateTime? timestamp { get; set; }
        /// <summary>
        /// color code of the embed
        /// </summary>
        public int color { get; set; }
        /// <summary>
        /// footer information
        /// </summary>
        public EmbedFooterData footer { get; set; }
        /// <summary>
        /// image information
        /// </summary>
        public EmbedImageData image { get; set; }
        /// <summary>
        /// thumbnail information
        /// </summary>
        public EmbedThumbnailData thumbnail { get; set; }
        /// <summary>
        /// video information
        /// </summary>
        public EmbedVideoData video { get; set; }
        /// <summary>
        /// provider information
        /// </summary>
        public EmbedProviderData provider { get; set; }
        /// <summary>
        /// author information
        /// </summary>
        public EmbedAuthorData author { get; set; }
        /// <summary>
        /// fields information
        /// </summary>
        public EmbedFieldData[] fields { get; set; }
    }
}
