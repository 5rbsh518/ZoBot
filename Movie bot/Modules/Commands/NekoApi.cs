using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using NReco.ImageGenerator;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Movie_bot.Modules;
using Movie_bot.Core;
using Movie_bot.Core.GuildInfos;
using Discord.Rest;

namespace Movie_bot.Modules.Commands
{
    public class NekoApi : ModuleBase<SocketCommandContext>
    {
        [Command("lolice")]
        public async Task HugMember(SocketUser user)
        {
            string json = "";
            var embed = new EmbedBuilder();


            using(WebClient client = new WebClient())
            {
                json = client.DownloadString($"https://nekobot.xyz/api/imagegen?type=lolice&url={user.GetAvatarUrl()}");
            }
            var DataObject = JsonConvert.DeserializeObject<dynamic>(json);
            var hug = DataObject.message.ToString();

            embed.WithTitle($"Stay becareful");
            embed.WithImageUrl(hug);

            await Context.Channel.SendMessageAsync("",false,embed);
            
        }
        [Command("Clyde")]
        public async Task ClydeMessage([Remainder]string msg)
        {
            string json = "";
            var embed = new EmbedBuilder();


            using (WebClient client = new WebClient())
            {
                json = client.DownloadString($"https://nekobot.xyz/api/imagegen?type=clyde&text={msg}");
            }
            var DataObject = JsonConvert.DeserializeObject<dynamic>(json);
            var hug = DataObject.message.ToString();

            embed.WithTitle($"Look What Clyde Said");
            embed.WithImageUrl(hug);

            await Context.Channel.SendMessageAsync("", false, embed);

        }
        [Command("Fuck you")]
        [Alias("Fuckyou", "F you", "Fk you", "Fyou", "Fk", "f u", "f you")]
        public async Task Fuckyoutoo()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle($"Fuck you too");
            embed.WithImageUrl("https://memegenerator.net/img/instances/34633137.jpg");
            await Context.Channel.SendMessageAsync("", false, embed);

        }
    }
}
