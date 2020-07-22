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
    public class TestChance : ModuleBase<SocketCommandContext>
    {
        [Command("Chance")]
        public async Task Chance(int Number)
        {
            string message = "";
            int comman = 0;
            int unique = 0;
            int rare = 0;
            int epic = 0;
            int times = 0;
            while(comman < 38)
            {
                message += "comman|";
                comman += 1;
            }
            while(unique < 20)
            {
                message += "unique|";
                unique += 1;
            }
            while (rare < 15)
            {
                message += "rare|";
                rare += 1;
            }
            while (epic < 2)
            {
                message += "epic|";
                epic += 1;
            }
            string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            while(times <= Number)
            {
                Random r = new Random();
                string Seletion = options[r.Next(0, options.Length)];
                await Context.Channel.SendMessageAsync(Seletion);
                times += 1;
            }
           
        }
    }
}
