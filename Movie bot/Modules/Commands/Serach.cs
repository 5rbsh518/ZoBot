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

namespace ConsoleApp3.Modules
{
    public class Randomuser : ModuleBase<SocketCommandContext>
    {
        [Command("Search")]
        [Alias("MovieSearch","S")]
        public async Task SearchFormovie([Remainder]string message)
        { 
            string json = "";//5bbab599
            using (WebClient client = new WebClient())
            {
                if (!message.Contains("www.imdb.com"))
                {
                    json = client.DownloadString($"http://www.omdbapi.com/?apikey=5bbab599&t={message}");
                }
                else
                {
                    StringBuilder sb = new StringBuilder(message);
                    sb.Remove(0, 27);
                    message = sb.ToString();
                    StringBuilder sbb = new StringBuilder(message);
                    sbb.Remove(9, message.Length - 9);
                    message = sbb.ToString();
                    json = client.DownloadString($"http://www.omdbapi.com/?apikey=5bbab599&i={message}");
                }
               
            }

            var DataObject = JsonConvert.DeserializeObject<dynamic>(json);
            string Response = DataObject.Response.ToString();
            if (Response == "True")
            {
                string Name = DataObject.Title.ToString();
                string Year = DataObject.Year.ToString();
                string Runtime = DataObject.Runtime.ToString();
                string Genre = DataObject.Genre.ToString();
                string Country = DataObject.Country.ToString();
                string Poster = DataObject.Poster.ToString();
                string imdbRating = DataObject.imdbRating.ToString();
                string imdbVotes = DataObject.imdbVotes.ToString();
                string Type = DataObject.Type.ToString();
                string Plot = DataObject.Plot.ToString();
                string ImdbID = DataObject.imdbID.ToString();
                string Released = DataObject.Released.ToString();

                string Time = Runtime.Remove(Runtime.Length - 3);
                int thetimeinmin = Convert.ToInt32(Time);
                int moviehours = 0;
                int moviemin = 0;
                while (thetimeinmin != 0)
                {
                    if (thetimeinmin >= 60)
                    {
                        moviehours = moviehours + 1;
                        thetimeinmin = thetimeinmin - 60;
                    }
                    else
                    {
                        moviemin = thetimeinmin;
                        thetimeinmin = 0;
                    }
                }
                if (moviehours != 0)
                {
                    if (moviemin != 0)
                    {
                        Runtime = $"{moviehours} hour and {moviemin} min";
                    }
                    else
                    {
                        Runtime = $"{moviehours} hour ";
                    }
                }
                else
                {
                    if (moviemin != 0)
                    {
                        Runtime = $"{moviemin} min";
                    }
                    else
                    {
                        Runtime = $"There is no recorded Runtime ";
                    }
                }

                ImdbID = $"https://www.imdb.com/title/{ImdbID}/";
                Random random = new Random();
                var Embed = new EmbedBuilder();

                Embed.WithThumbnailUrl(Poster);
                Embed.AddInlineField("Name", Name);
                Embed.AddInlineField("Year", Year);
                Embed.AddInlineField("Released at", Released);
                Embed.AddInlineField("RunTime", Runtime);
                Embed.AddInlineField("Country", Country);
                Embed.AddField("Genre", Genre);
                Embed.AddInlineField("imdbRating", imdbRating);
                Embed.AddInlineField("imdbVotes", imdbVotes);
                Embed.AddInlineField("Type", Type);
                Embed.AddInlineField("Description", Plot);
                Embed.AddInlineField("ImdbUrl", ImdbID);
                Embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

                await Context.Channel.SendMessageAsync("", false, Embed);

            }
            else
            {
                await Context.Channel.SendMessageAsync("");

            }


        }
    }
}
