using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class IntegrationData
    {
        /// <summary>
        /// integration id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// integration name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// integration type (twitch, youtube, etc)
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// is this integration enabled
        /// </summary>
        public bool enabled { get; set; }
        /// <summary>
        /// is this integration syncing
        /// </summary>
        public bool syncing { get; set; }
        /// <summary>
        /// id that this integration uses for "subscribers"
        /// </summary>
        public string role_id { get; set; }
        /// <summary>
        /// whether emoticons should be synced for this integration (twitch only currently)
        /// </summary>
        public bool enable_emoticons { get; set; }
        /// <summary>
        /// the behavior of expiring subscribers
        /// </summary>
        public IntegrationExpireBehavior expire_behavior { get; set; }
        /// <summary>
        /// the grace period (in days) before expiring subscribers
        /// </summary>
        public int expire_grace_period { get; set; }
        /// <summary>
        /// user for this integration
        /// </summary>
        public UserData user { get; set; }
        /// <summary>
        /// integration account information
        /// </summary>
        public IntegrationAccountData account { get; set; }
        /// <summary>
        /// when this integration was last synced
        /// </summary>
        public DateTime? synced_at { get; set; }
    }
}
