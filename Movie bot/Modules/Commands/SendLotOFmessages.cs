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

namespace Movie_bot.Modules
{
    public class Send : ModuleBase<SocketCommandContext>
    {
        [Command("Send")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SendNumber(int MessageNumber)
        {
            int amount = 1;
            while(MessageNumber >= amount)
            {      
                await Context.Channel.SendMessageAsync(amount.ToString());
                amount += 1;
            }
        }
    }
}

