using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class InviteMetadataData
    {
        /// <summary>
        /// number of times this invite has been used
        /// </summary>
        public int uses { get; set; }
        /// <summary>
        /// max number of times this invite can be used
        /// </summary>
        public int max_uses { get; set; }
        /// <summary>
        /// duration (in seconds) after which the invite expires
        /// </summary>
        public int max_age { get; set; }
        /// <summary>
        /// whether this invite only grants temporary membership
        /// </summary>
        public bool temporary { get; set; }
        /// <summary>
        /// when this invite was created
        /// </summary>
        public DateTime? created_at { get; set; }
    }
}
