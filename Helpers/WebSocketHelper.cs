using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using DiscordAPI.Serialization.Payloads;
using DiscordAPI.Serialization.Data;
using DiscordAPI;
using System.Net;
using System.Web;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Linq;
using DiscordAPI.Serialization.Payloads.Data;
using DiscordAPI.Serialization.Data.Voice;

namespace DiscordAPI.Helpers
{
    internal class WebSocketHelper
    {
        internal DiscordBot bot;
        internal ClientWebSocket gatewaySocket;
        internal ClientWebSocket voiceSocket;
        internal string token;
        internal int sequence = 0;
        internal string voiceSessionId;
        internal string voiceEndpoint;
        internal string voiceToken;

        private CancellationTokenSource heartbeatTokenSource;
        private CancellationTokenSource gatewayReceiveTokenSource;
        private CancellationTokenSource voiceReceiveTokenSource;
        private string sessionId;

        private DateTime heartbeatTime;
        private bool heartbeatAckReceived;
        private bool isConnected;

        private List<UnavailableGuildData> waitingGuildsCreate;

        internal WebSocketHelper(string token, DiscordBot bot)
        {
            gatewaySocket = new ClientWebSocket();
            this.token = token;
            this.bot = bot;

            isConnected = false;
        }

        internal async Task Initialize()
        {
            heartbeatTokenSource = new CancellationTokenSource();
            gatewayReceiveTokenSource = new CancellationTokenSource();
            heartbeatAckReceived = true;

            var payload = new PayloadIdentify(token);

            byte[] data = JsonSerializer.SerializeToUtf8Bytes(payload);

            await gatewaySocket.ConnectAsync(new Uri("wss://gateway.discord.gg/?v=6&encoding=json"), CancellationToken.None);
            await gatewaySocket.SendAsync(data, WebSocketMessageType.Text, true, CancellationToken.None);
            StartReceiving(gatewaySocket, gatewayReceiveTokenSource.Token);
        }

        internal async Task ConnectToVoice(string guild_id, string channel_id, bool mute = false, bool deaf = false)
        {
            var payload = new Payload<VoiceStateUpdateData>();
            payload.opcode = Opcode.VOICE_STATE_UPDATE;
            payload.data = new VoiceStateUpdateData();
            payload.data.guild_id = guild_id;
            payload.data.channel_id = channel_id;
            payload.data.self_mute = mute;
            payload.data.self_deaf = deaf;

            byte[] data = JsonSerializer.SerializeToUtf8Bytes(payload);

            await gatewaySocket.SendAsync(data, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task Reconnect(bool hard_reset)
        {
            bot.InvokeDisconnect();
            Console.WriteLine("Don't panic, I'm trying to reconnect!");
            heartbeatTokenSource.Cancel();
            gatewayReceiveTokenSource.Cancel();
            await gatewaySocket.CloseAsync(WebSocketCloseStatus.Empty, null, CancellationToken.None);
            await Task.Delay(2300);
            heartbeatTokenSource.Dispose();
            gatewayReceiveTokenSource.Dispose();
            gatewaySocket.Dispose();

            Console.WriteLine("Closed connection, Disposed token sources and socket, creating resume payload...");

            gatewaySocket = new ClientWebSocket();
            heartbeatTokenSource = new CancellationTokenSource();
            gatewayReceiveTokenSource = new CancellationTokenSource();
            heartbeatAckReceived = true;

            byte[] data;

            if (hard_reset)
            {
                var payload = new PayloadIdentify(token);
                data = JsonSerializer.SerializeToUtf8Bytes(payload);
            }
            else
            {
                var payload = new PayloadResume(token, sessionId, sequence);
                data = JsonSerializer.SerializeToUtf8Bytes(payload);
            }

            Console.WriteLine("OK, Now trying to connect...");
            await gatewaySocket.ConnectAsync(new Uri("wss://gateway.discord.gg/?v=6&encoding=json"), CancellationToken.None);
            await gatewaySocket.SendAsync(data, WebSocketMessageType.Text, true, CancellationToken.None);
            Console.WriteLine("May be it's reconnected. May be it's not... I don't know, I've tried");
            StartReceiving(gatewaySocket, gatewayReceiveTokenSource.Token);
        }

        private async Task StartReceiving(ClientWebSocket socket, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8192]);
                WebSocketReceiveResult result = null;

                using (var ms = new MemoryStream())
                {
                    do
                    {
                        result = await socket.ReceiveAsync(buffer, cancellationToken);
                        ms.Write(buffer.Array, buffer.Offset, result.Count);
                    }
                    while (!result.EndOfMessage);

                    var res = ms.ToArray();

                    if (result.MessageType == WebSocketMessageType.Text)
                        HandleRecieved(res);
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine($"CLOSE STATUS RECEIVED!\n {result.CloseStatus}: " + result.CloseStatusDescription);
                        if ((int)result.CloseStatus.Value == 4004)
                        {
                            Console.WriteLine("Token is Invalid");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Trying to reconnect...");
                            Reconnect(false);
                            return;
                        }
                    }
                }
            }
        }

        private async Task StartHeartbeat(ClientWebSocket socket, int interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(interval);

                if (heartbeatAckReceived)
                {
                    heartbeatAckReceived = false;
                    var payload = new PayloadHeartbeat(sequence);
                    heartbeatTime = DateTime.UtcNow;
                    socket.SendAsync(JsonSerializer.SerializeToUtf8Bytes(payload), WebSocketMessageType.Text, true, CancellationToken.None);
                } 
                else
                {
                    Console.WriteLine("Failed to detect Opcode 11 on heartbeat, Connection defined as zombied, closing socket, trying to resume session...");
                    Reconnect(false);
                    return;
                }
            }
        }

        private void HandleRecieved(byte[] data)
        {
            Opcode opcode = JsonSerializer.Deserialize<Payload>(data).opcode;

            Console.WriteLine("OPCODE: " + opcode.ToString());
            Console.WriteLine(Encoding.UTF8.GetString(data));


            switch (opcode)
            {
                case Opcode.EVENT:
                    HandleEvent(data);
                    break;

                case Opcode.HELLO:
                    var helloPayload = JsonSerializer.Deserialize<PayloadHello>(data);
                    heartbeatTokenSource.Cancel();
                    heartbeatTokenSource.Dispose();
                    heartbeatTokenSource = new CancellationTokenSource();
                    StartHeartbeat(gatewaySocket, helloPayload.data.heartbeatInterval, heartbeatTokenSource.Token);
                    break;

                case Opcode.HEARTBEAT_ACK:
                    heartbeatAckReceived = true;
                    break;

                case Opcode.INVALID_SESSION:
                    Console.WriteLine("Got INVALID_SESSION code, panic please, while I'm trying to resend identify...");
                    Reconnect(true);
                    break;

                case Opcode.RECONNECT:
                    Console.WriteLine("Discord said we must reconnect with new session");
                    Reconnect(true);
                    break;
            }
        }

        private async void HandleEvent(byte[] data)
        {
            PayloadEvent pe = JsonSerializer.Deserialize<PayloadEvent>(data);

            if (sequence + 1 != pe.sequence) Console.WriteLine($"ERROR: Sequence {sequence + 1} expected, got {pe.sequence}!");
            sequence = pe.sequence;
            //Console.WriteLine("Send to bot handler");
            bot.HandleEvent(data, pe.eventName);

            switch (pe.eventName)
            {
                case "READY":
                    var readyData = JsonSerializer.Deserialize<PayloadEvent<ReadyData>>(data).data;
                    sessionId = readyData.session_id;
                    UserData u = readyData.user;
                    bot.User = new User(u);
                    if (readyData.guilds == null || readyData.guilds.Length == 0)
                    {
                        if (!isConnected)
                        {
                            Console.WriteLine("Bot Connected and Ready!");
                            bot.InvokeReady();
                            isConnected = true;
                        }
                        else
                        {
                            Console.WriteLine("Bot Reconnected!");
                            bot.InvokeReconnect();
                        }
                    }
                    else
                    {
                        waitingGuildsCreate = new List<UnavailableGuildData>();
                        for (int i = 0; i < readyData.guilds.Length; i++)
                            waitingGuildsCreate.Add(readyData.guilds[i]);
                    }
                    break;


                case "RESUMED":
                    Console.WriteLine("Bot Reconnected succesfully! Oh yes!");
                    bot.InvokeReconnect();
                    break;

                case "GUILD_CREATE":
                    var guildData = JsonSerializer.Deserialize<PayloadEvent<GuildCreateData>>(data).data;
                    if (waitingGuildsCreate != null)
                    {
                        var ugd = waitingGuildsCreate.First(x => x.id == guildData.id);
                        if (ugd != null)
                        {
                            waitingGuildsCreate.Remove(ugd);
                            bot.Guilds.Add(new Guild(guildData));
                        }
                        if (waitingGuildsCreate.Count <= 0)
                        {
                            waitingGuildsCreate = null;
                            if (!isConnected)
                            {
                                Console.WriteLine("Bot Connected and Ready!");
                                bot.InvokeReady();
                                isConnected = true;
                            }
                            else
                            {
                                Console.WriteLine("Bot Reconnected!");
                                bot.InvokeReconnect();
                            }
                        }
                    }
                    else
                    {
                        //Guild becomes available again! Send some events, update chache;
                    }
                    break;

                case "VOICE_STATE_UPDATE":
                    var voiceStateData = JsonSerializer.Deserialize<PayloadEvent<VoiceStateData>>(data);
                    if (voiceStateData.data.user_id == "508276696542085121")
                    {
                        Console.WriteLine("Voice state update received for self");
                        voiceSessionId = voiceStateData.data.session_id;
                    }
                    break;

                case "VOICE_SERVER_UPDATE":
                    Console.WriteLine("Voice server update received!");
                    var voiceServerUpdateData = JsonSerializer.Deserialize<PayloadEvent<VoiceServerUpdateData>>(data);

                    voiceEndpoint = voiceServerUpdateData.data.endpoint;
                    voiceToken = voiceServerUpdateData.data.token;

                    Console.WriteLine($"Ready to connect to voice!");
                    if (voiceSocket != null)
                    {
                        voiceSocket.CloseAsync(WebSocketCloseStatus.Empty, "OK", CancellationToken.None);
                        voiceSocket.Dispose();
                        voiceReceiveTokenSource.Cancel();
                        voiceReceiveTokenSource.Dispose();
                    }

                    voiceSocket = new ClientWebSocket();
                    voiceSocket.Options.AddSubProtocol("SSL");
                    voiceSocket.Options.AddSubProtocol("SSL3");
                    voiceSocket.Options.AddSubProtocol("TLS");
                    voiceReceiveTokenSource = new CancellationTokenSource();
                    Console.WriteLine(voiceSocket.SubProtocol);
                    await voiceSocket.ConnectAsync(new Uri($"wss://{voiceEndpoint}/?v=4"), CancellationToken.None);
                    StartReceiving(voiceSocket, voiceReceiveTokenSource.Token);

                    var voicePayload = new Payload<VoiceIdentifyData>();
                    voicePayload.opcode = Opcode.EVENT;
                    voicePayload.data = new VoiceIdentifyData();
                    voicePayload.data.server_id = "504617984594018325";
                    voicePayload.data.session_id = voiceSessionId;
                    voicePayload.data.user_id = "508276696542085121";
                    voicePayload.data.token = voiceToken;

                    await voiceSocket.SendAsync(JsonSerializer.SerializeToUtf8Bytes(voicePayload), WebSocketMessageType.Text, true, CancellationToken.None);
                    break;
            }
        }
    }
}