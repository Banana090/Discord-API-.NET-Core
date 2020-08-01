using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI.Serialization.Data
{
    public enum IntegrationExpireBehavior : int
    {
        REMOVE_ROLE = 0,
        KICK = 1
    }
}
