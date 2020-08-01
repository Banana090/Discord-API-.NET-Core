using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI
{
    internal class DMChannel : TextChannel
    {
        internal DMChannel(ChannelData channelData) : base(channelData)
        {

        }
    }
}
