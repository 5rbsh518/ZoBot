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

namespace Movie_bot.Modules.Commands
{
    public class Avatar : ModuleBase<SocketCommandContext>
    {
        [Command("Avatar")]
        public async Task Commands(SocketGuildUser user)
        {
            var client = Global.Client;

            var embed = new EmbedBuilder();
            Random random = new Random();
            Console.WriteLine(client.Guilds.Count);
            embed.WithTitle($"{user.Nickname} Avatar");
            embed.WithImageUrl(user.GetAvatarUrl());
            embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            

            await Context.Channel.SendMessageAsync("",false,embed);
        }
        
    }
}
