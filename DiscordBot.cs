using System;
using System.Net.WebSockets;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using DiscordAPI.Serialization.Payloads;
using DiscordAPI.Serialization.Data;
using DiscordAPI.Helpers;
using DiscordAPI.Serialization.Data.Guild;
using System.Linq;

namespace DiscordAPI
{
    public class DiscordBot
    {
        internal HTTPHelper http_helper;
        internal WebSocketHelper websocket_helper;

        public User User { get; internal set; }
        public List<Guild> Guilds { get; internal set; }

        public delegate void MessageEvent(Message message);
        public delegate void ReactionEvent(string userId, string channelId, string messageId, Emoji emoji);
        public delegate void ChannelEvent(Channel channel);
        public delegate void ChannelPinsUpdateEvent(string guild_id, string channel_id, DateTime last_pin_timestamp);
        public delegate void GuildUpdateEvent(Guild guild);
        public delegate void GuildDeleteEvent(string guild_id);
        public delegate void GuildBanEvent(string guild_id, User user);
        public delegate void GuildEmojisUpdateEvent(string guild_id, CustomEmoji[] emojis);
        public delegate void GuildIntegrationsUpdateEvent(string guild_id);
        public delegate void GuildMemberAddEvent(Guild guild, GuildMember member);
        public delegate void GuildMemberRemoveEvent(Guild guild, GuildMember member);
        /// <summary>
        /// Sent when a new channel is created, relevant to the current user.
        /// </summary>
        public event ChannelEvent OnChannelCreate;
        /// <summary>
        /// Sent when a channel is updated.
        /// </summary>
        public event ChannelEvent OnChannelUpdate;
        /// <summary>
        /// Sent when a channel relevant to the current user is deleted.
        /// </summary>
        public event ChannelEvent OnChannelDelete;
        /// <summary>
        /// Sent when a message is pinned or unpinned in a text channel. This is not sent when a pinned message is deleted.
        /// </summary>
        public event ChannelPinsUpdateEvent OnChannelPinsUpdate;

        //GUILD_CREATE HERE

        /// <summary>
        /// Sent when a guild is updated.
        /// </summary>
        public event GuildUpdateEvent OnGuildUpdate;
        /// <summary>
        /// Sent when a guild becomes unavailable during a guild outage, or when the user leaves or is removed from a guild.
        /// </summary>
        public event GuildDeleteEvent OnGuildDelete;
        /// <summary>
        /// Sent when a user is banned from a guild.
        /// </summary>
        public event GuildBanEvent OnGuildBanAdd;
        /// <summary>
        /// Sent when a user is unbanned from a guild.
        /// </summary>
        public event GuildBanEvent OnGuildBanRemove;
        /// <summary>
        /// Sent when a guild's emojis have been updated.
        /// </summary>
        public event GuildEmojisUpdateEvent OnGuildEmojisUpdate;
        /// <summary>
        /// Sent when a guild integration is updated.
        /// </summary>
        public event GuildIntegrationsUpdateEvent OnGuildIntegrationsUpdate;
        /// <summary>
        /// Sent when a new user joins a guild.
        /// </summary>
        public event GuildMemberAddEvent OnGuildMemberAdd;
        /// <summary>
        /// Sent when a user is removed from a guild (leave/kick/ban).
        /// </summary>
        public event GuildMemberRemoveEvent OnGuildMemberRemove;


        public event MessageEvent OnMessageReceived;
        public event ReactionEvent OnReactionAdd;
        public event ReactionEvent OnReactionRemove;
        public event Action OnReady;
        public event Action OnReconnect;
        public event Action OnDisconnect;


        public DiscordBot()
        {
            Guilds = new List<Guild>();
        }

        public async void LoginAsync(string token)
        {
            http_helper = new HTTPHelper(token, this);
            websocket_helper = new WebSocketHelper(token, this);

            await websocket_helper.Initialize();
        }

        public async Task ConnectToVoice(string guild_id, string channel_id, bool mute = false, bool deaf = false)
        {
            await websocket_helper.ConnectToVoice(guild_id, channel_id, mute, deaf);
        }

        public async Task DeleteMessageAsync(Message message)
        {
            await http_helper.DeleteMessage(message.channel_id, message.Id);
        }

        public async Task DeleteAllReactionsAsync(Message message)
        {
            await http_helper.DeleteAllReactions(message.channel_id, message.Id);
        }

        public async Task CreateReactionAsync(Message message, Emoji emoji)
        {
            if (emoji.IsCustom)
            {
                CustomEmoji e = emoji as CustomEmoji;
                string prefix = e.IsAnimated ? "a:" : "";
                await http_helper.MessageCreateReaction(message, $"{prefix}{e.Name}:{e.Id}");
            }
            else
            {
                await http_helper.MessageCreateReaction(message, emoji.ToString());
            }
        }
        public async Task CreateReactionAsync(Message message, string emoji)
        {
            await http_helper.MessageCreateReaction(message, emoji);
        }

        public async Task<Message> SendMessageAsync(string channel_id, string text) => await SendMessageAsync(channel_id, null, text);
        public async Task<Message> SendMessageAsync(string channel_id, RichEmbed embed) => await SendMessageAsync(channel_id, embed, null);
        public async Task<Message> SendMessageAsync(string channel_id, string text, RichEmbed embed) => await SendMessageAsync(channel_id, embed, text);
        public async Task<Message> SendMessageAsync(string channel_id, RichEmbed embed, string text)
        {
            return await http_helper.SendMessage(channel_id, embed, text);
        }

        public async Task<Message> EditMessageAsync(Message message, string text) => await EditMessageAsync(message, null, text);
        public async Task<Message> EditMessageAsync(Message message, RichEmbed embed) => await EditMessageAsync(message, embed, null);
        public async Task<Message> EditMessageAsync(Message message, string text, RichEmbed embed) => await EditMessageAsync(message, embed, text);
        public async Task<Message> EditMessageAsync(Message message, RichEmbed embed, string text)
        {
            return await http_helper.EditMessage(message, embed, text);
        }

        internal void HandleEvent(byte[] data, string eventName)
        {
            switch (eventName)
            {
                case "CHANNEL_CREATE":
                    if (OnChannelCreate != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<ChannelData>>(data).data;
                        switch (d.type)
                        {
                            case ChannelType.DM:
                                OnChannelCreate.Invoke(new DMChannel(d));
                                break;
                            case ChannelType.GUILD_TEXT:
                                OnChannelCreate.Invoke(new TextChannel(d));
                                break;
                            case ChannelType.GUILD_VOICE:
                                OnChannelCreate.Invoke(new VoiceChannel(d));
                                break;
                        }
                    }
                    break;

                case "CHANNEL_UPDATE":
                    if (OnChannelUpdate != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<ChannelData>>(data).data;
                        switch (d.type)
                        {
                            case ChannelType.DM:
                                OnChannelUpdate.Invoke(new DMChannel(d));
                                break;
                            case ChannelType.GUILD_TEXT:
                                OnChannelUpdate.Invoke(new TextChannel(d));
                                break;
                            case ChannelType.GUILD_VOICE:
                                OnChannelUpdate.Invoke(new VoiceChannel(d));
                                break;
                        }
                    }
                    break;

                case "CHANNEL_DELETE":
                    if (OnChannelDelete != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<ChannelData>>(data).data;
                        switch (d.type)
                        {
                            case ChannelType.DM:
                                OnChannelDelete.Invoke(new DMChannel(d));
                                break;
                            case ChannelType.GUILD_TEXT:
                                OnChannelDelete.Invoke(new TextChannel(d));
                                break;
                            case ChannelType.GUILD_VOICE:
                                OnChannelDelete.Invoke(new VoiceChannel(d));
                                break;
                        }
                    }
                    break;

                case "CHANNEL_PINS_UPDATE":
                    if (OnChannelPinsUpdate != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<ChannelPinsUpdateEventData>>(data).data;
                        OnChannelPinsUpdate.Invoke(d.guild_id, d.channel_id, d.last_pin_timestamp);
                    }
                    break;

                case "GUILD_CREATE":

                    break;

                case "GUILD_UPDATE":
                    if (OnGuildUpdate != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<GuildData>>(data).data;
                        Guild g = Guilds.First(g => g.Id == d.id);
                        if (g != null)
                            g.Update(d);
                        OnGuildUpdate.Invoke(g);
                    }
                    break;

                case "GUILD_DELETE":
                    if (OnGuildDelete != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<UnavailableGuildData>>(data).data;
                        OnGuildDelete.Invoke(d.id);
                    }
                    break;

                case "GUILD_BAN_ADD":
                    if (OnGuildBanAdd != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<GuildBanEventData>>(data).data;
                        OnGuildBanAdd.Invoke(d.guild_id, new User(d.user));
                    }
                    break;

                case "GUILD_BAN_REMOVE":
                    if (OnGuildBanRemove != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<GuildBanEventData>>(data).data;
                        OnGuildBanRemove.Invoke(d.guild_id, new User(d.user));
                    }
                    break;

                case "GUILD_EMOJIS_UPDATE":
                    if (OnGuildEmojisUpdate != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<GuildEmojisUpdateEventData>>(data).data;
                        CustomEmoji[] e = new CustomEmoji[d.emojis.Length];
                        for (int i = 0; i < e.Length; i++)
                        {
                            e[i] = new CustomEmoji(d.emojis[i]);
                        }
                        OnGuildEmojisUpdate.Invoke(d.guild_id, e);
                    }
                    break;

                case "GUILD_INTEGRATIONS_UPDATE":
                    if (OnGuildIntegrationsUpdate != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<ExtraFieldGuildId>>(data).data;
                        OnGuildIntegrationsUpdate.Invoke(d.guild_id);
                    }
                    break;

                case "GUILD_MEMBER_ADD":
                    if (OnGuildMemberAdd != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<GuildMemberData>>(data).data;
                        string gid = JsonSerializer.Deserialize<PayloadEvent<ExtraFieldGuildId>>(data).data.guild_id;
                        Guild g = Guilds.First(g => g.Id == gid);
                        GuildMember mem = new GuildMember(g, d);
                        g.AddMember(mem);
                        OnGuildMemberAdd.Invoke(g, mem);
                    }
                    break;

                case "GUILD_MEMBER_REMOVE":
                    if (OnGuildMemberRemove != null)
                    {
                        var d = JsonSerializer.Deserialize<PayloadEvent<UserData>>(data).data;
                        string gid = JsonSerializer.Deserialize<PayloadEvent<ExtraFieldGuildId>>(data).data.guild_id;
                        Guild g = Guilds.First(g => g.Id == gid);
                        GuildMember m = g.RemoveMember(d.id);
                        OnGuildMemberRemove.Invoke(g, m);
                    }
                    break;


                    //ENDED HERE


                case "MESSAGE_CREATE":
                    if (OnMessageReceived != null)
                    {
                        MessageData md = JsonSerializer.Deserialize<PayloadEvent<MessageData>>(data).data;
                        OnMessageReceived.Invoke(new Message(md));
                    }
                    break;

                case "MESSAGE_REACTION_ADD":
                    if (OnReactionAdd != null)
                    {
                        MessageReactionAddData d = JsonSerializer.Deserialize<PayloadEvent<MessageReactionAddData>>(data).data;
                        if (d.emoji.id == null)
                            OnReactionAdd.Invoke(d.user_id, d.channel_id, d.message_id, new UnicodeEmoji(d.emoji));
                        else
                            OnReactionAdd.Invoke(d.user_id, d.channel_id, d.message_id, new CustomEmoji(d.emoji));
                    }
                    break;

                case "MESSAGE_REACTION_REMOVE":
                    if (OnReactionAdd != null)
                    {
                        MessageReactionRemoveData d = JsonSerializer.Deserialize<PayloadEvent<MessageReactionRemoveData>>(data).data;
                        if (d.emoji.id == null)
                            OnReactionRemove.Invoke(d.user_id, d.channel_id, d.message_id, new UnicodeEmoji(d.emoji));
                        else
                            OnReactionRemove.Invoke(d.user_id, d.channel_id, d.message_id, new CustomEmoji(d.emoji));
                    }
                    break;
            }
        }

        internal void InvokeReady()
        {
            if (OnReady != null) OnReady.Invoke();
        }

        internal void InvokeReconnect()
        {
            if (OnReconnect != null) OnReconnect.Invoke();
        }

        internal void InvokeDisconnect()
        {
            if (OnDisconnect != null) OnDisconnect.Invoke();
        }
    }
}