using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Discord;
using Discord.WebSocket;
using System.Diagnostics;
using Movie_bot.Core.GuildInfos;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using Discord.Rest;

namespace Movie_bot
{
    class Program
    {
       
        DiscordSocketClient _client;
        CommandHandler _handler;


        static void Main(string[] args)
         => new Program().StartAsync().GetAwaiter().GetResult();

        async Task StartAsync()
        {
            if (Config.bot.token == "" || Config.bot.token == null) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            _client.ReactionAdded += OnReactionAdded;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            Global.Client = _client;
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await SetGame();
            //await Task.Delay(-1);
        }

        private async Task SetGame()
        {
            string ThePlayingStates = $"|$help|New command $checklist @user :D";
            string[] SplitedPlayingStates = ThePlayingStates.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            Random random = new Random();
            while (true)
            {
                string TheOne = SplitedPlayingStates[random.Next(0, SplitedPlayingStates.Length)];
                await _client.SetGameAsync(TheOne);

                Thread.Sleep(60000);
            }
        }

        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {

        }

        private static SocketTextChannel Channel;
        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}