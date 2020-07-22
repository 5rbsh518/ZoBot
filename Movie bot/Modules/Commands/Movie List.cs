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

namespace ConsoleApp3.Modules
{
    public class AddTolist : ModuleBase<SocketCommandContext>
    {
        [Command("Add")]
        public async Task SearchFormovie([Remainder]string message)
        {
            var target = Context.Guild;
            var getguild = GuildInfos.GetGuild(target);
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

                getguild.movies += $"{ImdbID}|";
                GuildInfos.SaveGuildInfo();
                ImdbID = $"https://www.imdb.com/title/{ImdbID}/";
                Random random = new Random();
                var Embed = new EmbedBuilder();

                if(Poster != null)
                {
                    Embed.WithThumbnailUrl(Poster);
                }
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
                await Context.Channel.SendMessageAsync("Error, Please check the name.");
            }


        }
        [Command("List")]
        public async Task List()
        {
            var target = Context.Guild;
            var getguild = GuildInfos.GetGuild(target);
            string item = getguild.movies;
            string[] movies = item.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var myEmoji = new Emoji("👍");
            foreach (string items in movies)
            {
                string thething = items.Remove(0, items.Length - 9);
                string json = "";
                using(WebClient Client = new WebClient())
                {
                    json = Client.DownloadString($"http://www.omdbapi.com/?apikey=5bbab599&i={thething}");
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

                    RestUserMessage msg = await Context.Channel.SendMessageAsync("", false, Embed);
                    await msg.AddReactionAsync(myEmoji);

                }
                else
                {
                    await Context.Channel.SendMessageAsync("Error, Please check the name.");

                }

            }
        }
        [Command("Clear")]
        public async Task clearList()
        {
            var target = Context.Guild;
            var getguild = GuildInfos.GetGuild(target);

            getguild.movies = "";
            GuildInfos.SaveGuildInfo();
            Random random = new Random();

            var embed = new EmbedBuilder();
            embed.WithDescription($"The list have been cleared");
            embed.WithFooter(Context.User.Username);
            embed.WithCurrentTimestamp();
            embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            await Context.Channel.SendMessageAsync("", false, embed);
        }
        [Command("Remove")]
        public async Task Removeitem([Remainder]string message)
        {
            var target = Context.Guild;
            var getguild = GuildInfos.GetGuild(target);
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
                string ImdbID = DataObject.imdbID.ToString();
                string Title = DataObject.Title.ToString();

                string item = getguild.movies;
                string[] movies = item.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Random random = new Random();

                getguild.movies = "";
                foreach (var movie in movies)
                {
                    if (movie != ImdbID)
                    {
                        getguild.movies += movie + "|";
                    }
                }
                var embed = new EmbedBuilder();
                GuildInfos.SaveGuildInfo();

                embed.WithFooter(Context.User.Username);
                embed.WithCurrentTimestamp();
                embed.WithDescription($"{Title} has been removed from the list");
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

                await Context.Channel.SendMessageAsync("", false, embed);
            }
        }
    }
}