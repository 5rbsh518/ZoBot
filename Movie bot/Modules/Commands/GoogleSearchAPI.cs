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

namespace Movie_bot.Modules.Commands
{
    public class GoogleApis : ModuleBase<SocketCommandContext>
    {
        [Command("GS")]
        public async Task GoogleSearch([Remainder]string message)
        {
            string json = "";//
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString($"https://www.googleapis.com/customsearch/v1?key=AIzaSyC6I5CUTX2yNFUAQleHXHBuM46rqW_rL_M&cx=007665783094421850904:ytwzf3phpoe&q={message}");
            }
            var DataObject = JsonConvert.DeserializeObject<dynamic>(json);

            string SearchTitle = DataObject.queries.request[0].title.ToString();
            string TotalResult = DataObject.queries.request[0].totalResults.ToString();
            string items = DataObject.items[0].title.ToString();
            string MyBotName = DataObject.context.title.ToString();

            await Context.Channel.SendMessageAsync($"{MyBotName}");
        }
    }
}
