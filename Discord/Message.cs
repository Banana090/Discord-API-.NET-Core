using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;
using DiscordAPI;

namespace DiscordAPI
{
    public class Message
    {
        public string Id { get; }
        public string Content { get; }
        public string channel_id { get; }
        public string guild_id { get; }
        public User Author { get; }
        public MessageType type { get; }

        internal Message(MessageData messageData)
        {
            Id = messageData.id;
            Content = messageData.content;
            channel_id = messageData.channel_id;
            guild_id = messageData.guild_id;
            Author = new User(messageData.author);
            type = messageData.type;
        }
    }
}
