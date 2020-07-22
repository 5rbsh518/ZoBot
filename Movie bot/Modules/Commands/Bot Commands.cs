using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Net;
using Newtonsoft.Json;
using Movie_bot.Modules;
using Discord.Rest;
using System.Threading;

namespace Movie_bot.Modules
{
    public class BotCommands : ModuleBase<SocketCommandContext>
    {
        [Command("SetGame")]
        [RequireOwner]
        public async Task SetGame([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            Random random = new Random();

            embed.WithTitle("Change bot game");
            embed.WithDescription($"The game has been changed to {message} ");
            embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

            await Context.Client.SetGameAsync(message);
            await Context.Channel.SendMessageAsync("", false, embed);
        }
        [Command("RemoveGame")]
        [RequireOwner]
        public async Task RemoveGame()
        {
            await Context.Client.SetGameAsync("");
        }
        [Command("Loopinggames")]
        [RequireOwner]
        public async Task Loopinggame([Remainder]string games)
        {
                Random random = new Random();
                string[] options = games.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                while (true)
                { 
                    string Seletion = options[random.Next(0, options.Length)]; 
                    await Context.Client.SetGameAsync($"{Seletion}", null, StreamType.NotStreaming);
                    Thread.Sleep(60000);
                }
        }
    }
}
