using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using DiscordAPI;
using DiscordAPI.Serialization.Data;
using DiscordAPI.Serialization.Payloads;
using DiscordAPI.Helpers;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using System.Threading;
using System.Globalization;

namespace DiscordAPI.Helpers
{
    internal class HTTPHelper
    {
        #region Init
        internal DiscordBot bot;
        internal RESTRequester requester;

        internal const string discordapiUrl = "https://discordapp.com/api";

        internal HTTPHelper(string token, DiscordBot bot)
        {
            this.bot = bot;

            requester = new RESTRequester(token);
        }
        #endregion

        #region Request

        private async Task Request(RequestType requestType, RouteParams route, byte[] content = null, string mediaType = "application/json")
        {
            RESTRequest request = new RESTRequest(requestType, route, content, mediaType);
            HttpResponseMessage response = await requester.Request(request).Task;
            response.Dispose();
        }

        private async Task<T> Request<T>(RequestType requestType, RouteParams route, byte[] content = null, string mediaType = "application/json")
        {
            RESTRequest request = new RESTRequest(requestType, route, content, mediaType);
            HttpResponseMessage response = await requester.Request(request).Task;

            if (response.IsSuccessStatusCode)
            {
                byte[] data = await response.Content.ReadAsByteArrayAsync();
                T d = JsonSerializer.Deserialize<T>(data);
                response.Dispose();
                return d;
            }
            response.Dispose();

            return default;
        }
        #endregion

        #region Channel

        internal async Task DeleteMessage(string channel_id, string message_id)
        {
            RouteParams route = new RouteParams()
            {
                url = $"/channels/{channel_id}/messages/{message_id}",
                route = $"{RequestType.DELETE}/channels/{channel_id}/messages",
                template = $"{RequestType.DELETE}/channels/[maj]/messages"
            };

            await Request(RequestType.DELETE, route);
        }

        internal async Task DeleteAllReactions(string channel_id, string message_id)
        {
            RouteParams route = new RouteParams()
            {
                url = $"/channels/{channel_id}/messages/{message_id}/reactions",
                route = $"{RequestType.DELETE}/channels/{channel_id}/messages/[min]/reactions",
                template = $"{RequestType.DELETE}/channels/[maj]/messages/[min]/reactions"
            };

            await Request(RequestType.DELETE, route);
        }

        internal async Task MessageCreateReaction(Message message, string emoji)
        {
            RouteParams route = new RouteParams()
            {
                url = $"/channels/{message.channel_id}/messages/{message.Id}/reactions/{HttpUtility.UrlEncode(emoji)}/@me",
                route = $"{RequestType.PUT}/channels/{message.channel_id}/messages/[min]/reactions",
                template = $"{RequestType.PUT}/channels/[maj]/messages/[min]/reactions"
            };
            
            await Request(RequestType.PUT, route);
        }

        internal async Task<Message> EditMessage(Message message, RichEmbed embed, string text)
        {
            RouteParams route = new RouteParams()
            {
                url = $"/channels/{message.channel_id}/messages/{message.Id}",
                route = $"{RequestType.PATCH}/channels/{message.channel_id}/messages",
                template = $"{RequestType.PATCH}/channels/[maj]/messages"
            };

            string jsonContent = "";

            if (embed != null)
            {
                SendingMessage mmm = new SendingMessage();
                if (text != null) mmm.content = text;
                else mmm.content = "";
                mmm.embed = embed;
                jsonContent = JsonSerializer.Serialize(mmm);
            }
            else if (text != null)
            {
                jsonContent = "{\"content\":" + JsonSerializer.Serialize(text) + "}";
            }
            else
            {
                Console.WriteLine("Ты ахуел? Нормально тебе null отправлять? Лови ответный, пидрила!");
                return null;
            }

            byte[] byteContent = Encoding.UTF8.GetBytes(jsonContent);
            
            var d = await Request<MessageData>(RequestType.PATCH, route, byteContent);
            if (d != null)
                return new Message(d);
            return null;
        }

        internal async Task<Message> SendMessage(string channel_id, RichEmbed embed, string text)
        {
            RouteParams route = new RouteParams()
            {
                url = $"/channels/{channel_id}/messages",
                route = $"{RequestType.POST}/channels/{channel_id}/messages",
                template = $"{RequestType.POST}/channels/[maj]/messages"
            };

            string jsonContent = "";

            if (embed != null)
            {
                SendingMessage mmm = new SendingMessage();
                if (text != null) mmm.content = text;
                else mmm.content = "";
                mmm.embed = embed;
                jsonContent = JsonSerializer.Serialize(mmm);
            }
            else if (text != null)
            {
                jsonContent = "{\"content\":" + JsonSerializer.Serialize(text) + "}";
            }
            else
            {
                Console.WriteLine("Ты ахуел? Нормально тебе null отправлять? Лови ответный null, пидрила!");
                return null;
            }

            byte[] byteContent = Encoding.UTF8.GetBytes(jsonContent);
            var d = await Request<MessageData>(RequestType.POST, route, byteContent);
            if (d != null)
                return new Message(d);
            return null;
        }

        #endregion
    }
}
