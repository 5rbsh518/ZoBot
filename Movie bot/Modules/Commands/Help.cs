using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Movie_bot.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
        
    {
        [Command("help")]
        public async Task AllHelp()
        {
            Random random = new Random();
            SocketUser user = Context.User;
            var embed = new EmbedBuilder();

            embed.WithDescription("ZoBot commands");
            embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            embed.WithCurrentTimestamp();
            embed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
            embed.AddInlineField("Avatar","request user avatar");
            embed.AddInlineField("Cat", "Send random pic of a cat");
            embed.AddInlineField("bird", "Send photo of birds");
            embed.AddInlineField("Search", "Search for movie in IMDB");
            embed.AddInlineField("Add", "Add movie to the server movie list");
            embed.AddInlineField("Remove", "Remove item from the server movie list");
            embed.AddInlineField("Clear", "Clear the server movie list");
            embed.AddInlineField("List", "Send the server movie list");
            embed.AddInlineField("Admins", "Check for online and offline server administrator");
            embed.AddInlineField("OnlineAdmins", "Check for online server administrator");
            embed.AddInlineField("OfflineAdmins", "Check for offline server administrator");
            embed.AddInlineField("Channelkick", "Kick user from the voice channel");
            embed.AddInlineField("MyAdd", "Add movie to the user movie list");
            embed.AddInlineField("MyRemove", "Remove item from user movie list");
            embed.AddInlineField("MyClear", "Clear user movie list");
            embed.AddInlineField("MyList", "Send user movie list");

            await Context.User.SendMessageAsync("For more help type $help Command", false, embed);
        }
        [Command("help")]
        public async Task HelpCommand(string msg)
        {
            if (string.Equals(msg, "Avatar", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("Avatar");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("request user avatar");
                embed.AddField("Requirements", "Mentioned user");
                embed.AddField("Example", $"$Avatar {Context.Client.CurrentUser.Mention}");

                await Context.User.SendMessageAsync("", false, embed);

            }
            if (string.Equals(msg, "cat", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("cat");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Send photo of cat");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "bird", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("bird");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Send bird photo");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "Search", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("Search");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Search for movie in IMDB");
                embed.AddField("Requirements", "Movie name or IMDB Url");
                embed.AddInlineField("Example", "$search Men in Black");
                embed.AddInlineField("Example", "$search https://www.imdb.com/title/tt0119654/");
                    

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "Add", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("Add");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Add movie to the server movie list");
                embed.AddField("Requirements", "Movie name or IMDB Url");
                embed.AddField("!", "You can't use it in DMs");
                embed.AddInlineField("Example", "$add Men in Black");
                embed.AddInlineField("Example", "$add https://www.imdb.com/title/tt0119654/");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "Remove", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("Remove");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Remove 1 item for the server movie list");
                embed.AddField("Requirements", "Movie name or IMDB Url");
                embed.AddField("!", "You can't use it in DMs");
                embed.AddInlineField("Example", "$Remove Men in Black");
                embed.AddInlineField("Example", "$Remove https://www.imdb.com/title/tt0119654/");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "Clear", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("Clear");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Clear the server movie list");
                embed.AddField("!", "You can't use it in DMs");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "List", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("List");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Sends the server movie list");
                embed.AddField("!", "You can't use it in DMs");


                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "Admins", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("Admins");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Show you the online and offline administrator and the numbers ");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "OnlineAdmins", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("OnlineAdmins");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("show you the online administrator and the number of online administrator");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "OfflineAdmins", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("OfflineAdmins");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("show you the offline administrator and the number of offline administrator");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "Channelkick", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("Channelkick");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Kick user from the voice channel");
                embed.AddField("RequireUserPermission", "Kick Members");
                embed.AddField("RequireBotPermission", "Manage Channels, Move Members");
                embed.AddField("Requirements", "Mentioned User");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "MyAdd", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("MyAdd");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Add movie to the `user` movie list");
                embed.AddField("!", "Works in DM's");


                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "MyRemove", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("MyRemove");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Remove 1 item for the `user` movie list");
                embed.AddField("Requirements", "Movie name or IMDB Url");
                embed.AddField("!", "Works in DM's");
                embed.AddInlineField("Example", "$MyRemove Men in Black");
                embed.AddInlineField("Example", "$MyRemove https://www.imdb.com/title/tt0119654/");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "MyClear", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("MyClear");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Clear the `user` movie list");
                embed.AddField("!", "Works in DM's");

                await Context.User.SendMessageAsync("", false, embed);
            }
            if (string.Equals(msg, "MyList", StringComparison.OrdinalIgnoreCase))
            {
                var embed = new EmbedBuilder();
                Random random = new Random();

                embed.WithTitle("MyList");
                embed.WithCurrentTimestamp();
                embed.WithColor(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                embed.WithDescription("Sends the `user` movie list");
                embed.AddField("!", "Works in DM's");

                await Context.User.SendMessageAsync("", false, embed);
            }
        }
    }
}