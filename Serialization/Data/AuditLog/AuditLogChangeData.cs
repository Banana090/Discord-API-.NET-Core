using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class AuditLogChangeData
    {
        /// <summary>
        /// name of audit log change key
        /// </summary>
        public string key { get; set; }
    }

    internal class AuditLogChangeData<T> : AuditLogChangeData
    {
        /// <summary>
        /// new value of the key
        /// </summary>
        public T new_value { get; set; }
        /// <summary>
        /// old value of the key
        /// </summary>
        public T old_value { get; set; }
    }
}
