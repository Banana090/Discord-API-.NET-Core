using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI
{
    public class Channel
    {
        public string Id { get; set; }
        public ChannelType Type { get; set; }
    }
}
