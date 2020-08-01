using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI.Serialization.Payloads
{
    internal class ReadyData
    {
        /// <summary>
        /// 	gateway version
        /// </summary>
        public int v { get; set; }
        /// <summary>
        /// information about the user including email
        /// </summary>
        public UserData user { get; set; }
        /// <summary>
        /// the guilds the user is in
        /// </summary>
        public UnavailableGuildData[] guilds { get; set; }
        /// <summary>
        /// used for resuming connections
        /// </summary>
        public string session_id { get; set; }
        /// <summary>
        /// array of two integers (shard_id, num_shards)
        /// the shard information associated with this session, if sent when identifying
        /// </summary>
        public int[] shard { get; set; }
    }
}
