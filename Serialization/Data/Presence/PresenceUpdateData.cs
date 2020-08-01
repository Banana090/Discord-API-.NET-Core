using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class PresenceUpdateData
    {
        /// <summary>
        /// the user presence is being updated for
        /// </summary>
        public UserData user { get; set; }
        /// <summary>
        /// roles this user is in
        /// </summary>
        public string[] roles { get; set; }
        /// <summary>
        /// null, or the user's current activity
        /// </summary>
        public ActivityData game { get; set; }
        /// <summary>
        /// id of the guild
        /// </summary>
        public string guild_id { get; set; }
        /// <summary>
        /// either "idle", "dnd", "online", or "offline"
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// user's current activities
        /// </summary>
        public ActivityData[] activities { get; set; }
        /// <summary>
        /// user's platform-dependent status
        /// </summary>
        public ClientStatusData client_status { get; set; }
        /// <summary>
        /// when the user started boosting the guild
        /// </summary>
        public DateTime? premium_since { get; set; }
        /// <summary>
        /// this users guild nickname (if one is set)
        /// </summary>
        public string nick { get; set; }
    }
}
