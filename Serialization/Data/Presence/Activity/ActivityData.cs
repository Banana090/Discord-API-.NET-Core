using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ActivityData
    {
        /// <summary>
        /// the activity's name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 	activity type
        /// </summary>
        public ActivityType type { get; set; }
        /// <summary>
        /// stream url, is validated when type is 1
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// unix timestamp of when the activity was added to the user's session
        /// </summary>
        public ulong created_at { get; set; }
        /// <summary>
        /// unix timestamps for start and/or end of the game
        /// </summary>
        public ActivityTimestampsData timestamps { get; set; }
        /// <summary>
        /// application id for the game
        /// </summary>
        public string application_id { get; set; }
        /// <summary>
        /// what the player is currently doing
        /// </summary>
        public string details { get; set; }
        /// <summary>
        /// the user's current party status
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// the emoji used for a custom status
        /// </summary>
        public ActivityEmojiData emoji { get; set; }
        /// <summary>
        /// information for the current party of the player
        /// </summary>
        public ActivityPartyData party { get; set; }
        /// <summary>
        /// images for the presence and their hover texts
        /// </summary>
        public ActivityAssetsData assets { get; set; }
        /// <summary>
        /// secrets for Rich Presence joining and spectating
        /// </summary>
        public ActivitySecretsData secrets { get; set; }
        /// <summary>
        /// whether or not the activity is an instanced game session
        /// </summary>
        public bool instance { get; set; }
        /// <summary>
        /// activity flags ORd together, describes what the payload includes
        /// </summary>
        public int flags { get; set; }
    }
}
