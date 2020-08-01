using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class WebhookData
    {
        /// <summary>
        /// the id of the webhook
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// the type of the webhook
        /// </summary>
        public WebhookType type { get; set; }
        /// <summary>
        /// the guild id this webhook is for
        /// </summary>
        public string guild_id { get; set; }
        /// <summary>
        /// the channel id this webhook is for
        /// </summary>
        public string channel_id { get; set; }
        /// <summary>
        /// the user this webhook was created by (not returned when getting a webhook with its token)
        /// </summary>
        public UserData user { get; set; }
        /// <summary>
        /// the default name of the webhook
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// the default avatar of the webhook
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// the secure token of the webhook (returned for Incoming Webhooks)
        /// </summary>
        public string token { get; set; }
    }
}
