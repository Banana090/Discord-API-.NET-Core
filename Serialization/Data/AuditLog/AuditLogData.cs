using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class AuditLogData
    {
        /// <summary>
        /// list of webhooks found in the audit log
        /// </summary>
        public WebhookData[] webhooks { get; set; }
        /// <summary>
        /// list of users found in the audit log
        /// </summary>
        public UserData[] users { get; set; }
        /// <summary>
        /// list of audit log entries
        /// </summary>
        public AuditLogEntryData[] audit_log_entries { get; set; }
        /// <summary>
        /// list of partial integration objects
        /// </summary>
        public IntegrationData[] integrations { get; set; }
    }
}
