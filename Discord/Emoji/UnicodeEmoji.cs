using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI
{
    public class UnicodeEmoji : Emoji
    {
        public string Name { get; }

        internal UnicodeEmoji(EmojiData emojiData)
        {
            Name = emojiData.name;
            IsCustom = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
