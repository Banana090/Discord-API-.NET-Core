using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    internal class ConnectionData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool revoked { get; set; }
        public IntegrationData[] integrations { get; set; }
        public bool verified { get; set; }
        public bool friend_sync { get; set; }
        public bool show_activity { get; set; }
        public VisibilityType visibility { get; set; }
    }
}
