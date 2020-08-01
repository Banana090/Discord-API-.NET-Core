using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordAPI
{
    public class RichEmbed
    {
        public string title { get; private set; }
        public string type { get; private set; }
        public string description { get; private set; }
        public int color { get; private set; }
        public EmbedFooter footer { get; private set; }
        public EmbedAuthor author { get; private set; }
        public List<EmbedField> fields { get; private set; }
        public EmbedImage image { get; private set; }
        public EmbedThumbnail thumbnail { get; private set; }

        public RichEmbed()
        {
            type = "rich";
            title = "";
            description = "";
            //color = new Color(25, 25, 25).GetInt();
            //footer = new EmbedFooter("", "");
            //author = new EmbedAuthor("", "", "");
            //image = new EmbedImage("");
            fields = new List<EmbedField>();
        }

        public RichEmbed SetThumbnail(string url)
        {
            thumbnail = new EmbedThumbnail(url);
            return this;
        }

        public RichEmbed SetTitle(string title)
        {
            this.title = title;
            return this;
        }

        public RichEmbed SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public RichEmbed SetColor(int r, int g, int b)
        {
            this.color = new Color(r, g, b).GetInt();
            return this;
        }

        public RichEmbed SetImage(string url)
        {
            image = new EmbedImage(url);
            return this;
        }

        public RichEmbed SetFooter(string text, string icon_url)
        {
            footer = new EmbedFooter(text, icon_url);
            return this;
        }

        public RichEmbed SetAuthor(string name, string icon_url, string url)
        {
            author = new EmbedAuthor(name, icon_url, url);
            return this;
        }

        public RichEmbed AddField(string title, string text, bool inline)
        {
            fields.Add(new EmbedField(title, text, inline));
            return this;
        }

        public class EmbedThumbnail
        {
            public string url { get; set; }

            internal EmbedThumbnail(string url)
            {
                this.url = url;
            }

            public EmbedThumbnail() { }
        }

        public class EmbedFooter
        {
            public string text { get; set; }
            public string icon_url { get; set; }

            internal EmbedFooter(string text, string icon_url)
            {
                this.text = text;
                this.icon_url = icon_url;
            }

            public EmbedFooter() { }
        }

        public class EmbedAuthor
        {
            public string name { get; set; }
            public string url { get; set; }
            public string icon_url { get; set; }

            internal EmbedAuthor(string name, string icon_url, string url)
            {
                this.name = name;
                this.icon_url = icon_url;
                this.url = url;
            }

            public EmbedAuthor() { }
        }

        public class EmbedField
        {
            public string name { get; set; }
            public string value { get; set; }
            public bool inline { get; set; }

            internal EmbedField(string name, string value, bool inline)
            {
                this.name = name;
                this.value = value;
                this.inline = inline;
            }

            public EmbedField() { }
        }

        public class EmbedImage
        {
            public string url { get; set; }

            internal EmbedImage(string url)
            {
                this.url = url;
            }

            public EmbedImage() { }
        }
    }
}
