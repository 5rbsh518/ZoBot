using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Audio;
using Discord;


namespace Movie_bot.Modules.Commands
{
    public class Play : ModuleBase<SocketCommandContext>
    {
        [Command("play")]
        public async Task play([Remainder] string msg)
        {
        }
    }
}
