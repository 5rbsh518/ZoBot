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
    public class RandomBirdPhoto : ModuleBase<SocketCommandContext>
    {
        [Command("Bird")]
        [Alias("Birb","Birds")]
        public async Task RandomBirdPhotoGenraitor()
        {
            Random r = new Random();
            string json = "";
            using (WebClient client = new WebClient())
            {
                    json = client.DownloadString("http://random.birb.pw/tweet.json/");
            }

            var DataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string ImageName = DataObject.file;
            string Image = "https://random.birb.pw/img/" + ImageName;

            var embed = new EmbedBuilder();

            embed.WithTitle("Birb :bird: :baby_chick: ");
            embed.WithImageUrl(Image);
            embed.WithColor(new Color(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));

            Console.WriteLine(embed);
            await Context.Channel.SendMessageAsync("", false, embed);

        }
    }
}