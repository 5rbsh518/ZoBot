using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Net;
using Newtonsoft.Json;
using Discord.Rest;
using Movie_bot.Core.GuildInfos;

namespace Movie_bot.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("vote")]
        [RequireOwner]
        public async Task HandleReact()
        {
            var target = Context.Guild;
            GlobalVar.ServerID = Context.Guild;
            var getguild = GuildInfos.GetGuild(target);
            string Movies = getguild.movies;
            string votingMovies = getguild.Voting;
            getguild.Voting = Movies;
            GuildInfos.SaveGuildInfo();
            string[] VotingList = votingMovies.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            Emoji VoteUpEmoji = new Emoji("👍");
            Emoji VoteDownEmoji = new Emoji("👎");
            Emoji NextMovieEmoji = new Emoji("💘");
            string items = VotingList.FirstOrDefault();

            string thething = items.Remove(0, items.Length - 9);
            string json = "";
            using (WebClient Client = new WebClient())
            {
                json = Client.DownloadString($"http://www.omdbapi.com/?apikey=5bbab599&i={thething}");
            }
            var DataObject = JsonConvert.DeserializeObject<dynamic>(json);
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
            await msg.AddReactionAsync(VoteUpEmoji);
            await msg.AddReactionAsync(VoteDownEmoji);
            await msg.AddReactionAsync(NextMovieEmoji);

            GlobalVar.ID = msg.Id;
            GlobalVar.TheVotingNumber = 0;
            GlobalVar.TheMostVote = 0;
        }
    }
}
