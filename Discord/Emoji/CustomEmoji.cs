using System;
using System.Collections.Generic;
using System.Text;
using DiscordAPI.Serialization.Data;

namespace DiscordAPI
{
    public class CustomEmoji : Emoji
    {
        public string Id { get; }
        public string Name { get; }
        public bool IsAnimated { get; }

        private User creator;

        internal CustomEmoji(EmojiData emojiData)
        {
            Id = emojiData.id;
            Name = emojiData.name;
            if (emojiData.user != null)
                creator = new User(emojiData.user);
            else
                creator = null;
            IsAnimated = emojiData.animated;
            IsCustom = true;
        }

        public override string ToString()
        {
            string prefix = IsAnimated ? "a" : "";
            return $"<{prefix}:{Name}:{Id}>";
        }
    }
}
