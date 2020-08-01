using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class OptionalAuditEntryInfoData
    {
        /// <summary>
        /// number of days after which inactive members were kicked	
        /// <para>MEMBER_PRUNE</para>
        /// </summary>
        public string delete_member_days { get; set; }
        /// <summary>
        /// number of members removed by the prune	
        /// <para>MEMBER_PRUNE</para>
        /// </summary>
        public string members_removed { get; set; }
        /// <summary>
        /// channel in which the entities were targeted	
        /// <para>MEMBER_MOVE & MESSAGE_PIN & MESSAGE_UNPIN & MESSAGE_DELETE & MESSAGE_BULK_DELETE</para>
        /// </summary>
        public string channel_id { get; set; }
        /// <summary>
        /// id of the message that was targeted	
        /// <para>MESSAGE_PIN & MESSAGE_UNPIN</para>
        /// </summary>
        public string message_id { get; set; }
        /// <summary>
        /// number of entities that were targeted	
        /// <para>MESSAGE_DELETE & MESSAGE_BULK_DELETE & MEMBER_DISCONNECT & MEMBER_MOVE</para>
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// id of the overwritten entity	
        /// <para>CHANNEL_OVERWRITE_CREATE & CHANNEL_OVERWRITE_UPDATE & CHANNEL_OVERWRITE_DELETE</para>
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// type of overwritten entity ("member" or "role")	
        /// <para>CHANNEL_OVERWRITE_CREATE & CHANNEL_OVERWRITE_UPDATE & CHANNEL_OVERWRITE_DELETE</para>
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// name of the role if type is "role"	
        /// <para>CHANNEL_OVERWRITE_CREATE & CHANNEL_OVERWRITE_UPDATE & CHANNEL_OVERWRITE_DELETE</para>
        /// </summary>
        public string role_name { get; set; }
    }
}
