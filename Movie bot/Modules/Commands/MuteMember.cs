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

namespace Movie_bot.Modules.Commands
{
    public class MuteMember : ModuleBase<SocketCommandContext>
    {
        private static System.Timers.Timer aTimer;
        [Command("Mute")]
        public async Task MuteTheMember(SocketGuildUser user, int Time,string Type,[Remainder]string Resaon)
        {
            if(Type.IndexOf("h",0,StringComparison.CurrentCultureIgnoreCase ) != -1|| Type.IndexOf("hour", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                Time = Time * 3600000;
            }
            if (Type.IndexOf("s", 0, StringComparison.CurrentCultureIgnoreCase) != -1|| Type.IndexOf("second", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                Time = Time * 1000;
            }
            if (Type.IndexOf("d", 0, StringComparison.CurrentCultureIgnoreCase) != -1 || Type.IndexOf("Day", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                Time = Time * 86400000;
            }
            if (Type.IndexOf("m", 0, StringComparison.CurrentCultureIgnoreCase) != -1 || Type.IndexOf("minute", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                Time = Time * 60000;
            }
        }
    }
}
