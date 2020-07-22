using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord.Commands;
using System.Reflection;
using Discord.WebSocket;
using Discord.Net;
using Discord;
using Discord.Audio;

namespace Movie_bot
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            await _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(_client, msg);
            int argpos = 0;
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argpos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argpos))
            {
                var result = await _service.ExecuteAsync(context, argpos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                    string Dot = ".";
                    string comma = ",";
                    if (result.ErrorReason.ToString() == "The input text has too few parameters.")
                    {
                        var embed = new EmbedBuilder();

                        embed.WithTitle("Error");
                        embed.WithDescription($"{result.ErrorReason.ToString().Replace(Dot , comma)} you should try to check this `$help {context.Message.ToString().Remove(0 , 1)}`");
                        embed.WithColor(255, 0, 0);
                        embed.WithCurrentTimestamp();

                        await context.Channel.SendMessageAsync("", false, embed);
                    }
                    
                }
            }
        }
    }
}