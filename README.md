# Discord-API-.NET-Core
Simple Discord API wrapper for .NET Core

Example of basic bot implementation
```cs
public async Task Start()
        {
            bot = new DiscordBot();
            bot.OnReady += Ready;
            bot.OnMessageReceived += OnMessage;
            bot.LoginAsync("Your Token Here");

            await Task.Delay(-1);
        }

        private void OnMessage(Message message)
        {
            if (!message.Author.IsBot && message.Content == "!ping")
            {
                bot.SendMessageAsync(message.channel_id, "pong");
            }
        }

        private void Ready()
        {
            Console.WriteLine("Bot is ready to use now");
        }
```

So literally everything you can use is in `DiscrodBot` class. Enjoy xD
