using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class EmbedFieldData
    {
        /// <summary>
        /// name of the field
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// value of the field
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// whether or not this field should display inline
        /// </summary>
        public bool inline { get; set; }
    }
}
