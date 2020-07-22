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
        public async Task SetGame([Remainder]string message)
        {
            foreach (var user in Context.Guild.Users)
            {
                if (!message.Contains("<@"+user.Id+">"))
                    if (Context.User.Id == 222459221235597312)
                    {
                        var embed = new EmbedBuilder();
                        Random random = new Random();

                        embed.WithTitle("Change bot game");
                        embed.WithDescription($"The game has been changed to {message} ");
                        embed.WithColor(random.Next(0 , 256), random.Next(0, 256), random.Next(0, 256));

                        await Context.Client.SetGameAsync(message);
                        await Context.Channel.SendMessageAsync("", false, embed);
                        break;
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("لا يمكنك استخدام هذا الامر");
                    }
                else
                {
                    await Context.Channel.SendMessageAsync("لا يمكنك منشنت شخص");
                    break;
                }
            }
        }
        [Command("RemoveGame")]
        public async Task RemoveGame()
        {
            if (Context.User.Id == 222459221235597312)
            {
                await Context.Client.SetGameAsync("", null, StreamType.NotStreaming);
            }
            else
            {
                await Context.Channel.SendMessageAsync("You cannot use this command it's only owner command");
            }
        }
        [Command("Loopinggames")]
        public async Task Loopinggame([Remainder]string games)
        {
            if(Context.User.Id == 222459221235597312)
            {
                Random random = new Random();
                string[] options = games.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                while (0 > -1)
                { 
                    string Seletion = options[random.Next(0, options.Length)]; 
                    await Context.Client.SetGameAsync($"{Seletion}", null, StreamType.NotStreaming);
                    Thread.Sleep(60000);
                }
            }
        }
    }
}
