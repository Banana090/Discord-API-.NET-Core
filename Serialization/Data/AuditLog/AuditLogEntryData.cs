using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class AuditLogEntryData
    {
        /// <summary>
        /// id of the affected entity (webhook, user, role, etc.)
        /// </summary>
        public string target_id { get; set; }
        /// <summary>
        /// changes made to the target_id
        /// </summary>
        public AuditLogChangeData[] changes { get; set; }
        /// <summary>
        /// the user who made the changes
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// id of the entry
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// type of action that occurred
        /// </summary>
        public AuditLogEvent action_type { get; set; }
        /// <summary>
        /// additional info for certain action types
        /// </summary>
        public OptionalAuditEntryInfoData options { get; set; }
        /// <summary>
        /// the reason for the change (0-512 characters)
        /// </summary>
        public string reason { get; set; }
    }
}
