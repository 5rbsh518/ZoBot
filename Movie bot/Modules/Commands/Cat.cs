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
    public class RandomCatPhoto : ModuleBase<SocketCommandContext>
    {
        [Command("Cat")]
        [Alias("Cats", "kitty")]
        public async Task RandomBirdPhotoGenraitor()
        {
            Random r = new Random();
            string json = "";
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("https://api.thecatapi.com/v1/images/search");
            }

            var DataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string ImageName = DataObject[0].url;

            var embed = new EmbedBuilder();

            embed.WithTitle("Cat :cat: ");
            embed.WithImageUrl(ImageName);
            embed.WithColor(new Color(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));


            await Context.Channel.SendMessageAsync("", false, embed);
            

        }
    }
}
